namespace ReflectionAnalyzers
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;

    internal static class SymbolExt
    {
        internal static bool IsGenericDefinition(this ISymbol symbol)
        {
            switch (symbol)
            {
                case INamedTypeSymbol type:
                    return IsGenericDefinition(type.TypeArguments);
                case IMethodSymbol method:
                    return IsGenericDefinition(method.TypeArguments);
                default:
                    return false;
            }
        }

        internal static bool IsGenericDefinition(this INamedTypeSymbol symbol)
        {
            return symbol != null && IsGenericDefinition(symbol.TypeArguments);
        }

        internal static bool IsGenericDefinition(this IMethodSymbol symbol)
        {
            return symbol != null && IsGenericDefinition(symbol.TypeArguments);
        }

        private static bool IsGenericDefinition(ImmutableArray<ITypeSymbol> arguments)
        {
            if (arguments.Length == 0)
            {
                return false;
            }

            foreach (var argument in arguments)
            {
                if (!(argument is ITypeParameterSymbol) &&
                    !(argument is IErrorTypeSymbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
