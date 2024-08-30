namespace Enhanced.GetTypes.Annotation;

/// <summary>
///     Attribute to specify the base type to get derived types from.
/// </summary>
/// <param name="baseType">
///     The base type to get derived types from.
/// </param>
[AttributeUsage(AttributeTargets.Method)]
public class DerivedTypesAttribute(Type baseType) : Attribute
{
    /// <summary>
    ///     The base type to get derived types from.
    /// </summary>
    public Type BaseType { get; } = baseType;

    /// <summary>
    ///     Whether to include interfaces.
    /// </summary>
    public bool IncludeInterfaces { get; set; }

    /// <summary>
    ///     Whether to include internal types.
    /// </summary>
    public bool IncludeInternal { get; set; }

    /// <summary>
    ///     Whether to include abstract types.
    /// </summary>
    public bool IncludeAbstract { get; set; }
}
