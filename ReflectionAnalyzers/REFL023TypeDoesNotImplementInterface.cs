namespace ReflectionAnalyzers
{
    using Microsoft.CodeAnalysis;

    internal static class REFL023TypeDoesNotImplementInterface
    {
        public const string DiagnosticId = "REFL023";

        internal static readonly DiagnosticDescriptor Descriptor = new DiagnosticDescriptor(
            id: DiagnosticId,
            title: "The type does not implement the interface.",
            messageFormat: "The type does not implement the interface.",
            category: AnalyzerCategory.SystemReflection,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "The type does not implement the interface.",
            helpLinkUri: HelpLink.ForId(DiagnosticId));
    }
}
