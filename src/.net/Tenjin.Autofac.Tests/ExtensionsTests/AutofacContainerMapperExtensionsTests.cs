using Autofac;
using FluentAssertions;
using NUnit.Framework;
using Tenjin.Autofac.Extensions;
using Tenjin.Autofac.Tests.Models.Mappers;
using Tenjin.Interfaces.Mappers;

namespace Tenjin.Autofac.Tests.ExtensionsTests;

[TestFixture, Parallelizable(ParallelScope.Children)]
public class AutofacContainerMapperExtensionsTests
{
    [Test]
    public void RegisterMappers_WhenGivenAnAssembly_RegistersAllMappers()
    {
        using var container = GetDefaultContainer();
        using var scope = container.BeginLifetimeScope();
        var leftToRightMapper = scope.Resolve<IUnaryMapper<LeftModel, RightModel>>();
        var rightToLeftMapper = scope.Resolve<IUnaryMapper<RightModel, LeftModel>>();
        var binaryMapper1 = scope.Resolve<IBinaryMapper<LeftModel, RightModel>>();
        var binaryMapper2 = scope.Resolve<IBinaryMapper<RightModel, LeftModel>>();

        leftToRightMapper.Should().NotBeNull();
        rightToLeftMapper.Should().NotBeNull();
        binaryMapper1.Should().NotBeNull();
        binaryMapper2.Should().NotBeNull();

        leftToRightMapper.Should().BeAssignableTo<IUnaryMapper<LeftModel, RightModel>>();
        rightToLeftMapper.Should().BeAssignableTo<IUnaryMapper<RightModel, LeftModel>>();
        binaryMapper1.Should().BeAssignableTo<IBinaryMapper<LeftModel, RightModel>>();
        binaryMapper2.Should().BeAssignableTo<IBinaryMapper<RightModel, LeftModel>>();
    }

    [Test]
    public void RegisterMappers_WhenGivenAnAssembly_RegistersMappersAndWorkAsExpected()
    {
        using var container = GetDefaultContainer();
        using var scope = container.BeginLifetimeScope();
        var leftToRightMapper = scope.Resolve<IUnaryMapper<LeftModel, RightModel>>();
        var rightToLeftMapper = scope.Resolve<IUnaryMapper<RightModel, LeftModel>>();
        var binaryMapper1 = scope.Resolve<IBinaryMapper<LeftModel, RightModel>>();
        var binaryMapper2 = scope.Resolve<IBinaryMapper<RightModel, LeftModel>>();
        var leftInput = GetLeftInputModel();
        var rightInput = GetRightInputModel();
        var rightOutput1 = leftToRightMapper.Map(leftInput);
        var rightOutput2 = binaryMapper1.Map(leftInput);
        var rightOutput3 = binaryMapper2.Map(leftInput);
        var leftOutput1 = rightToLeftMapper.Map(rightInput);
        var leftOutput2 = binaryMapper1.Map(rightInput);
        var leftOutput3 = binaryMapper2.Map(rightInput);

        AssertOutput(rightOutput1);
        AssertOutput(rightOutput2);
        AssertOutput(rightOutput3);
        AssertOutput(leftOutput1);
        AssertOutput(leftOutput2);
        AssertOutput(leftOutput3);
    }

    private static LeftModel GetLeftInputModel()
    {
        return new LeftModel
        {
            Property1 = 1,
            Property2 = "left"
        };
    }

    private static RightModel GetRightInputModel()
    {
        return new RightModel
        {
            Property1 = 2,
            Property2 = "right"
        };
    }

    private static void AssertOutput(LeftModel model)
    {
        model.Property1.Should().Be(2);
        model.Property2.Should().Be("right");
    }

    private static void AssertOutput(RightModel model)
    {
        model.Property1.Should().Be(1);
        model.Property2.Should().Be("left");
    }

    private static IContainer GetDefaultContainer()
    {
        var assembly = typeof(AutofacContainerMapperExtensionsTests).Assembly;
        var container = new ContainerBuilder();

        /*
         * Different assemblies will be calling RegisterMappers multiple times,
         * causing multiple registrations of binary mapper.
         *
         * Make sure that this does not cause any issues/exceptions.
         */
        for (var i = 0; i < 10; i++)
        {
            container.RegisterMappers(assembly);
        }

        return container.Build();
    }
}