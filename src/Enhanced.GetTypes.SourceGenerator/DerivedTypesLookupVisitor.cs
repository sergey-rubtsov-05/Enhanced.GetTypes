namespace Enhanced.GetTypes.SourceGenerator;

internal class DerivedTypesLookupVisitor(DerivedTypesAttributeData attribute) : SymbolVisitor
{
    public List<INamedTypeSymbol> DerivedTypes { get; } = [];

    public override void VisitAssembly(IAssemblySymbol symbol)
    {
        symbol.GlobalNamespace.Accept(this);
    }

    public override void VisitNamespace(INamespaceSymbol symbol)
    {
        foreach (var member in symbol.GetMembers())
        {
            member.Accept(this);
        }
    }

    public override void VisitNamedType(INamedTypeSymbol symbol)
    {
        if (symbol.InheritsFrom(attribute.BaseType) && IsMatches(symbol))
        {
            DerivedTypes.Add(symbol);
        }

        foreach (var typeMembers in symbol.GetTypeMembers())
        {
            typeMembers.Accept(this);
        }
    }

    private bool IsMatches(INamedTypeSymbol symbol)
    {
        if (symbol.DeclaredAccessibility <= Accessibility.Private)
        {
            return false;
        }

        if (!attribute.IncludeInternal && symbol.DeclaredAccessibility == Accessibility.Internal)
        {
            return false;
        }

        if (!attribute.IncludeAbstract && symbol.IsAbstract)
        {
            return false;
        }

        if (!attribute.IncludeInterfaces && symbol.TypeKind == TypeKind.Interface)
        {
            return false;
        }

        return true;
    }
}
