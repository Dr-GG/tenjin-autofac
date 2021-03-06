using Autofac;
using Tenjin.Autofac.Implementations.Messaging.Publishers;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Extensions;

public static class AutofacContainerPublisherExtensions
{
    public static void RegisterPublisherRegistry<TKey, TData>(
        this ContainerBuilder container) where TKey : notnull
    {
        container
            .RegisterType<AutofacPublisherRegistry<TKey, TData>>()
            .As<IPublisherRegistry<TKey, TData>>()
            .SingleInstance();
    }
}