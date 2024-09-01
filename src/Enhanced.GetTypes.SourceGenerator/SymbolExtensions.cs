namespace Enhanced.GetTypes.SourceGenerator;

internal static class SymbolExtensions
{
    public static bool InheritsFrom(this ITypeSymbol type, ITypeSymbol baseType)
    {
        return baseType.TypeKind == TypeKind.Interface
            ? type.AllInterfaces.Any(t =>
            {
                if (baseType is INamedTypeSymbol { IsUnboundGenericType: true })
                {
                    var unboundGenericType = t.ConstructUnboundGenericType();
                    return SymbolEqualityComparer.Default.Equals(unboundGenericType, baseType);
                }

                return SymbolEqualityComparer.Default.Equals(t, baseType);
            })
            : type.GetBaseTypes().Any(t => SymbolEqualityComparer.Default.Equals(t, baseType));
    }

    public static T? GetNamedArgumentValue<T>(this AttributeData attribute, string key, T? defaultValue = default)
    {
        var constant = attribute.NamedArguments
            .FirstOrDefault(namedArgument => namedArgument.Key == key)
            .Value;

        if (constant.Equals(default))
        {
            return defaultValue;
        }

        return (T?)constant.Value;
    }

    public static T? GetCtorArgumentValue<T>(this AttributeData attribute, int index, T? defaultValue = default)
    {
        var constant = attribute.ConstructorArguments
            .ElementAtOrDefault(index);

        if (constant.Equals(default))
        {
            return defaultValue;
        }

        return (T?)constant.Value;
    }

    public static AttributeData GetAttribute(this IMethodSymbol method, string attributeFullName) =>
        method.GetAttributes().First(attribute => attribute.AttributeClass?.ToDisplayString() == attributeFullName);

    private static IEnumerable<ITypeSymbol> GetBaseTypes(this ITypeSymbol type)
    {
        var current = type.BaseType;
        while (current != null)
        {
            yield return current;
            current = current.BaseType;
        }
    }
}
