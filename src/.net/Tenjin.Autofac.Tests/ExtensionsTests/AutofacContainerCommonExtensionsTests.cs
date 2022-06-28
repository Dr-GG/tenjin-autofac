using Autofac;
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

        Assert.IsTrue(resolvedSettings.Equals(originalSettings));
        Assert.AreEqual(123, originalSettings.Property1);
        Assert.AreEqual("test this", originalSettings.Property2);
        Assert.AreEqual(123, resolvedSettings.Property1);
        Assert.AreEqual("test this", resolvedSettings.Property2);
    }
}