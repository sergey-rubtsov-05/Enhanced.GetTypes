using Enhanced.GetTypes.Annotation;
using FluentAssertions;

namespace Enhanced.GetTypes.Tests;

public class GetTypesTests
{
    [Fact]
    public void ShouldReturnAllTypes()
    {
        var interfaces = TypesSource.GetAllTypes().ToArray();

        interfaces.Should().Equal(
            typeof(PublicDerivedClass),
            typeof(InternalDerivedClass),
            typeof(PublicAbstractDerivedClass),
            typeof(InternalAbstractDerivedClass),
            typeof(IPublicDerivedInterface),
            typeof(IInternalDerivedInterface));
    }

    [Fact]
    public void ShouldReturnTypesWithAbstract()
    {
        var interfaces = TypesSource.GetTypesWithAbstract().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedClass), typeof(PublicAbstractDerivedClass));
    }

    [Fact]
    public void ShouldReturnTypesWithInterfaces()
    {
        var interfaces = TypesSource.GetTypesWithInterfaces().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedClass), typeof(IPublicDerivedInterface));
    }

    [Fact]
    public void ShouldReturnTypesWithInternal()
    {
        var interfaces = TypesSource.GetTypesWithInternal().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedClass), typeof(InternalDerivedClass));
    }
}

public static partial class TypesSource
{
    [DerivedTypes(typeof(IInterface), IncludeInterfaces = true, IncludeInternal = true, IncludeAbstract = true)]
    public static partial IEnumerable<Type> GetAllTypes();

    [DerivedTypes(typeof(IInterface), IncludeAbstract = true)]
    public static partial IEnumerable<Type> GetTypesWithAbstract();

    [DerivedTypes(typeof(IInterface), IncludeInterfaces = true)]
    public static partial IEnumerable<Type> GetTypesWithInterfaces();

    [DerivedTypes(typeof(IInterface), IncludeInternal = true)]
    public static partial IEnumerable<Type> GetTypesWithInternal();
}

public interface IInterface;

public class PublicDerivedClass : IInterface;

internal class InternalDerivedClass : IInterface;

public abstract class PublicAbstractDerivedClass : IInterface;

internal abstract class InternalAbstractDerivedClass : IInterface;

public interface IPublicDerivedInterface : IInterface;

internal interface IInternalDerivedInterface : IInterface;
