using System;
using Autofac;
using NUnit.Framework;
using Tenjin.Autofac.Extensions;
using Tenjin.Implementations.Diagnostics;
using Tenjin.Interfaces.Diagnostics;

namespace Tenjin.Autofac.Tests.ExtensionsTests
{
    [TestFixture]
    public class AutofacContainerDiagnosticWatchExtensionsTests
    {
        [Test]
        public void RegisterDiagnosticsWatch_WhenCalled_RegistersAISystemClockProviderInstance()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterDiagnosticsWatch();

            using var container = containerBuilder.Build();
            var clockProvider = container.Resolve<ISystemClockProvider>();

            Assert.IsNotNull(clockProvider);
            Assert.IsInstanceOf<ISystemClockProvider>(clockProvider);
            Assert.IsInstanceOf<SystemClockProvider>(clockProvider);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void RegisterSystemClockProvider_WhenCalled_RegistersAISystemClockProviderInstance(bool useUtc)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterSystemClockProvider(useUtc);

            using var container = containerBuilder.Build();
            var clockProvider = container.Resolve<ISystemClockProvider>();
            var now = useUtc ? DateTime.UtcNow : DateTime.Now;
            var providedNow = clockProvider.Now();
            var differenceSeconds = (providedNow - now).TotalMilliseconds;

            Assert.LessOrEqual(differenceSeconds, 1.0);
        }
    }
}