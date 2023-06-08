using Autofac;
using FluentAssertions;
using NUnit.Framework;
using Tenjin.Autofac.Extensions;
using Tenjin.Autofac.Tests.Models.Settings;

namespace Tenjin.Autofac.Tests.ExtensionsTests;

[TestFixture]
public class AutofacContainerCommonExtensionsTests
{
    [Test]
    public void RegisterSingleton_WhenRegisteringASingleton_ReturnsTheSameObject()
    {
        var containerBuilder = new ContainerBuilder();
        var originalSettings = new TestSettings
        {
            Property1 = 123,
            Property2 = "test this"
        };

        containerBuilder.RegisterSingleton(originalSettings);

        var container = containerBuilder.Build();
        var resolvedSettings = container.Resolve<TestSettings>();

        resolvedSettings.Should().Be(originalSettings);
        originalSettings.Property1.Should().Be(123);
        originalSettings.Property2.Should().Be("test this");
        resolvedSettings.Property1.Should().Be(123);
        resolvedSettings.Property2.Should().Be("test this");
    }
}