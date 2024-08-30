namespace Enhanced.GetTypes.SourceGenerator;

internal class DerivedTypesAttributeData(
    INamedTypeSymbol baseType,
    bool includeInterfaces,
    bool includeInternal,
    bool includeAbstract)
{
    public INamedTypeSymbol BaseType { get; } = baseType;
    public bool IncludeInterfaces { get; } = includeInterfaces;
    public bool IncludeInternal { get; } = includeInternal;
    public bool IncludeAbstract { get; } = includeAbstract;

    public static DerivedTypesAttributeData? FromAttribute(AttributeData attribute)
    {
        var baseTypeSymbol = attribute.GetCtorArgumentValue<INamedTypeSymbol>(0);

        if (baseTypeSymbol == null)
        {
            return null;
        }

        var includeInterfaces = attribute.GetNamedArgumentValue<bool>(DerivedTypesAttributeMetadata.IncludeInterfacesPropertyName);
        var includeInternal = attribute.GetNamedArgumentValue<bool>(DerivedTypesAttributeMetadata.IncludeInternalPropertyName);
        var includeAbstract = attribute.GetNamedArgumentValue<bool>(DerivedTypesAttributeMetadata.IncludeAbstractPropertyName);

        return new DerivedTypesAttributeData(baseTypeSymbol, includeInterfaces, includeInternal, includeAbstract);
    }
}
