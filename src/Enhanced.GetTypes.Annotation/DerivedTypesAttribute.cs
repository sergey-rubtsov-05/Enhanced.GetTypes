namespace Enhanced.GetTypes.Annotation;

[AttributeUsage(AttributeTargets.Method)]
public class DerivedTypesAttribute(Type baseType) : Attribute
{
    public Type BaseType { get; } = baseType;

    public bool IncludeInterfaces { get; set; }

    public bool IncludeInternal { get; set; }

    public bool IncludeAbstract { get; set; }
}
