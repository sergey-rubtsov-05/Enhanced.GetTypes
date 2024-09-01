using Enhanced.GetTypes.Annotation;
using FluentAssertions;

namespace Enhanced.GetTypes.Tests;

public class GetGenericTypesTests
{
    [Fact]
    public void ShouldReturnAllTypes()
    {
        var interfaces = GenericTypesSource.GetAllTypes().ToArray();

        interfaces.Should().Equal(
            typeof(PublicDerivedGenericClass<>),
            typeof(InternalDerivedGenericClass<>),
            typeof(PublicAbstractDerivedGenericClass<>),
            typeof(InternalAbstractDerivedGenericClass<>),
            typeof(IPublicDerivedGenericInterface<>),
            typeof(IInternalDerivedGenericInterface<>));
    }

    [Fact]
    public void ShouldReturnTypesWithAbstract()
    {
        var interfaces = GenericTypesSource.GetTypesWithAbstract().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedGenericClass<>), typeof(PublicAbstractDerivedGenericClass<>));
    }

    [Fact]
    public void ShouldReturnTypesWithInterfaces()
    {
        var interfaces = GenericTypesSource.GetTypesWithInterfaces().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedGenericClass<>), typeof(IPublicDerivedGenericInterface<>));
    }

    [Fact]
    public void ShouldReturnTypesWithInternal()
    {
        var interfaces = GenericTypesSource.GetTypesWithInternal().ToArray();

        interfaces.Should().Equal(typeof(PublicDerivedGenericClass<>), typeof(InternalDerivedGenericClass<>));
    }
}

public static partial class GenericTypesSource
{
    [DerivedTypes(typeof(IGenericInterface<>), IncludeInterfaces = true, IncludeInternal = true, IncludeAbstract = true)]
    public static partial IEnumerable<Type> GetAllTypes();

    [DerivedTypes(typeof(IGenericInterface<>), IncludeAbstract = true)]
    public static partial IEnumerable<Type> GetTypesWithAbstract();

    [DerivedTypes(typeof(IGenericInterface<>), IncludeInterfaces = true)]
    public static partial IEnumerable<Type> GetTypesWithInterfaces();

    [DerivedTypes(typeof(IGenericInterface<>), IncludeInternal = true)]
    public static partial IEnumerable<Type> GetTypesWithInternal();
}

// ReSharper disable once UnusedTypeParameter
public interface IGenericInterface<T>;

public class PublicDerivedGenericClass<T> : IGenericInterface<T>;

internal class InternalDerivedGenericClass<T> : IGenericInterface<T>;

public abstract class PublicAbstractDerivedGenericClass<T> : IGenericInterface<T>;

internal abstract class InternalAbstractDerivedGenericClass<T> : IGenericInterface<T>;

public interface IPublicDerivedGenericInterface<T> : IGenericInterface<T>;

internal interface IInternalDerivedGenericInterface<T> : IGenericInterface<T>;
