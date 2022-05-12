using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using Tenjin.Autofac.Extensions;
using Tenjin.Autofac.Tests.Constants;
using Tenjin.Autofac.Tests.Utilities;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Tests.ExtensionsTests
{
    [TestFixture]
    public class AutofacContainerPublisherExtensionsTests
    {
        [Test]
        public void RegisterPublisherRegistry_WhenUsingStringPublishers_RegistersThePublishRegistryAndPublishers()
        {
            TestRegistry(DiscoverablePublisherConstants.StringIds.Ids);
        }

        [Test]
        public void RegisterPublisherRegistry_WhenUsingInt32Publishers_RegistersThePublishRegistryAndPublishers()
        {
            TestRegistry(DiscoverablePublisherConstants.Int32Ids.Ids);
        }

        [Test]
        public void RegisterPublisherRegistry_WhenUsingEnumPublishers_RegistersThePublishRegistryAndPublishers()
        {
            TestRegistry(DiscoverablePublisherConstants.EnumIds.Ids);
        }

        private static void TestRegistry<TKey>(IEnumerable<TKey> ids) where TKey : notnull
        {
            var builder = new ContainerBuilder();

            builder.RegisterPublisherRegistry<TKey, object>();

            PublishRegistryContainerUtilities.RegisterAllPublishers(builder);

            using var container = builder.Build();

            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in ids)
            {
                var publisher = registry[id];

                Assert.IsNotNull(publisher);
            }
        }
    }
}