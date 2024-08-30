using Enhanced.GetTypes.Annotation;
using SampleLib.ByInterface;

namespace SampleLib;

partial class GetTypes
{
    [DerivedTypes(typeof(IMarker), IncludeInternal = true, IncludeAbstract = true, IncludeInterfaces = true)]
    private partial IEnumerable<Type> ByInterface();
}
