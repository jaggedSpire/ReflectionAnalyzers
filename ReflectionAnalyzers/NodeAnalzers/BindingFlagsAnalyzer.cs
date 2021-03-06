namespace ReflectionAnalyzers
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Gu.Roslyn.AnalyzerExtensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    internal class BindingFlagsAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            REFL007BindingFlagsOrder.Descriptor,
            REFL011DuplicateBindingFlags.Descriptor);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();
            context.RegisterSyntaxNodeAction(Handle, SyntaxKind.BitwiseOrExpression);
        }

        private static void Handle(SyntaxNodeAnalysisContext context)
        {
            if (!context.IsExcludedFromAnalysis() &&
                TryGetFlags(context, out var flags))
            {
                if (BindingFlagsWalker.HasWrongOrder(flags, out var expectedFlags))
                {
                    context.ReportDiagnostic(
                        Diagnostic.Create(
                            REFL007BindingFlagsOrder.Descriptor,
                            flags.GetLocation(),
                            ImmutableDictionary<string, string>.Empty.Add(nameof(ArgumentSyntax), expectedFlags),
                            $" Expected: {expectedFlags}."));
                }

                if (BindingFlagsWalker.HasDuplicate(flags, out var dupe, out expectedFlags))
                {
                    context.ReportDiagnostic(
                        Diagnostic.Create(
                            REFL011DuplicateBindingFlags.Descriptor,
                            dupe.GetLocation(),
                            ImmutableDictionary<string, string>.Empty.Add(nameof(ArgumentSyntax), expectedFlags),
                            $" Expected: {expectedFlags}."));
                }
            }
        }

        private static bool TryGetFlags(SyntaxNodeAnalysisContext context, out BinaryExpressionSyntax flags)
        {
            flags = context.Node as BinaryExpressionSyntax;
            return flags?.Parent is ArgumentSyntax &&
                   context.SemanticModel.TryGetType(flags, context.CancellationToken, out var type) &&
                   type == KnownSymbol.BindingFlags;
        }

        private class BindingFlagsWalker : PooledWalker<BindingFlagsWalker>
        {
            private readonly List<IdentifierNameSyntax> flags = new List<IdentifierNameSyntax>();
            private IdentifierNameSyntax duplicate;
            private bool isUnHandled;

            /// <inheritdoc />
            public override void Visit(SyntaxNode node)
            {
                if (!this.isUnHandled)
                {
                    switch (node)
                    {
                        case BinaryExpressionSyntax binary when binary.IsKind(SyntaxKind.BitwiseOrExpression):
                        case MemberAccessExpressionSyntax _:
                            base.Visit(node);
                            break;
                        case IdentifierNameSyntax identifierName when (identifierName.Parent is MemberAccessExpressionSyntax memberAccess &&
                                                                       !(memberAccess.Parent is MemberAccessExpressionSyntax) &&
                                                                       memberAccess.Name == identifierName) ||
                                                                      identifierName.Parent is BinaryExpressionSyntax:
                            if (this.duplicate == null &&
                                this.flags.TryFirst(x => x.Identifier.ValueText == identifierName.Identifier.ValueText, out _))
                            {
                                this.duplicate = identifierName;
                            }

                            this.flags.Add(identifierName);

                            break;
                        case IdentifierNameSyntax _:
                            break;
                        default:
                            this.isUnHandled = true;
                            break;
                    }
                }
            }

            internal static bool HasWrongOrder(BinaryExpressionSyntax flags, out string inExpectedOrder)
            {
                inExpectedOrder = null;
                if (flags == null)
                {
                    return false;
                }

                using (var walker = Borrow(flags))
                {
                    var current = 0;
                    foreach (var flag in walker.flags)
                    {
                        var index = Index(flag);
                        if (index == -1)
                        {
                            return false;
                        }

                        current = index < current ? int.MaxValue : index;
                    }

                    if (current == int.MaxValue)
                    {
                        walker.flags.Sort((x, y) => Index(x)
                                              .CompareTo(Index(y)));
                        inExpectedOrder = Format(walker.flags);
                        return true;
                    }

                    return false;
                }

                int Index(IdentifierNameSyntax identifierName)
                {
                    switch (identifierName.Identifier.ValueText)
                    {
                        case nameof(BindingFlags.Public):
                            return 0;
                        case nameof(BindingFlags.NonPublic):
                            return 1;
                        case nameof(BindingFlags.Static):
                            return 2;
                        case nameof(BindingFlags.Instance):
                            return 3;
                        case nameof(BindingFlags.DeclaredOnly):
                            return 4;
                        case nameof(BindingFlags.FlattenHierarchy):
                            return 5;
                        case nameof(BindingFlags.IgnoreCase):
                            return 6;
                        default:
                            // We don't support stuff like BindingFlags.GetProperty
                            return -1;
                    }
                }
            }

            internal static bool HasDuplicate(BinaryExpressionSyntax flags, out IdentifierNameSyntax dupe, out string expectedFlags)
            {
                expectedFlags = null;
                dupe = null;
                if (flags == null)
                {
                    return false;
                }

                using (var walker = Borrow(flags))
                {
                    if (!walker.isUnHandled &&
                        walker.duplicate != null)
                    {
                        dupe = walker.duplicate;
                        walker.flags.RemoveAt(walker.flags.LastIndexOf(dupe));
                        expectedFlags = Format(walker.flags);
                        return true;
                    }
                }

                return false;
            }

            protected override void Clear()
            {
                this.flags.Clear();
                this.duplicate = null;
                this.isUnHandled = false;
            }

            private static BindingFlagsWalker Borrow(BinaryExpressionSyntax flags) => BorrowAndVisit(flags, () => new BindingFlagsWalker());

            private static string Format(IReadOnlyList<IdentifierNameSyntax> flags)
            {
                var builder = StringBuilderPool.Borrow();
                for (var i = 0; i < flags.Count; i++)
                {
                    if (i > 0)
                    {
                        _ = builder.Append(" | ");
                    }

                    ExpressionSyntax flag = flags[i];
                    while (flag.Parent is MemberAccessExpressionSyntax memberAccess)
                    {
                        flag = memberAccess;
                    }

                    _ = builder.Append(flag);
                }

                return builder.Return();
            }
        }
    }
}
