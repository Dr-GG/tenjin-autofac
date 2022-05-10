using Autofac;
using Tenjin.Autofac.Extensions;
using Tenjin.Autofac.Tests.Enums;
using Tenjin.Autofac.Tests.Implementations.Messaging;
using Tenjin.Interfaces.Messaging.PublishSubscriber;

namespace Tenjin.Autofac.Tests.Utilities
{
    public static class PublishRegistryContainerUtilities
    {
        public static IContainer CreatePublisherRegistriesContainer()
        {
            var builder = new ContainerBuilder();

            RegisterPublisherRegistries(builder);

            return builder.Build();
        }

        public static void RegisterAllPublishers(ContainerBuilder builder)
        {
            RegisterStringPublishers(builder);
            RegisterInt32Publishers(builder);
            RegisterEnumPublishers(builder);
        }

        public static void RegisterPublisherRegistries(ContainerBuilder builder)
        {
            RegisterStringPublisherRegistry(builder);
            RegisterInt32PublisherRegistry(builder);
            RegisterEnumPublisherRegistry(builder);
        }

        public static void RegisterStringPublisherRegistry(ContainerBuilder builder)
        {
            builder.RegisterPublisherRegistry<string, object>();

            RegisterStringPublishers(builder);
        }

        public static void RegisterStringPublishers(ContainerBuilder builder)
        {
            builder
                .RegisterType<StringPublisherA>()
                .As<IDiscoverablePublisher<string, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<StringPublisherB>()
                .As<IDiscoverablePublisher<string, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<StringPublisherC>()
                .As<IDiscoverablePublisher<string, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<StringPublisherD>()
                .As<IDiscoverablePublisher<string, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<StringPublisherE>()
                .As<IDiscoverablePublisher<string, object>>()
                .InstancePerLifetimeScope();
        }

        public static void RegisterInt32PublisherRegistry(ContainerBuilder builder)
        {
            builder.RegisterPublisherRegistry<int, object>();

            RegisterInt32Publishers(builder);
        }

        public static void RegisterInt32Publishers(ContainerBuilder builder)
        {
            builder
                .RegisterType<Int32Publisher1>()
                .As<IDiscoverablePublisher<int, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Int32Publisher2>()
                .As<IDiscoverablePublisher<int, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Int32Publisher3>()
                .As<IDiscoverablePublisher<int, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Int32Publisher4>()
                .As<IDiscoverablePublisher<int, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<Int32Publisher5>()
                .As<IDiscoverablePublisher<int, object>>()
                .InstancePerLifetimeScope();
        }

        public static void RegisterEnumPublisherRegistry(ContainerBuilder builder)
        {
            builder.RegisterPublisherRegistry<TestPublisherType, object>();

            RegisterEnumPublishers(builder);
        }

        public static void RegisterEnumPublishers(ContainerBuilder builder)
        {
            builder
                .RegisterType<EnumPublisherDecimal>()
                .As<IDiscoverablePublisher<TestPublisherType, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EnumPublisherDouble>()
                .As<IDiscoverablePublisher<TestPublisherType, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EnumPublisherInt16>()
                .As<IDiscoverablePublisher<TestPublisherType, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EnumPublisherInt32>()
                .As<IDiscoverablePublisher<TestPublisherType, object>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<EnumPublisherInt64>()
                .As<IDiscoverablePublisher<TestPublisherType, object>>()
                .InstancePerLifetimeScope();
        }
    }
}
