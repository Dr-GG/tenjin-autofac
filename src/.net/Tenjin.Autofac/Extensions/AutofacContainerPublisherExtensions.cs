using Autofac;
using Tenjin.Autofac.Implementations.Messaging.Publishers;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Extensions;

/// <summary>
/// A collection of extension methods for Autofac containers and IPublisher instances.
/// </summary>
public static class AutofacContainerPublisherExtensions
{
    /// <summary>
    /// Registers the default implementation of the IPublisherRegistry for Autofac.
    /// </summary>
    public static void RegisterPublisherRegistry<TKey, TData>(
        this ContainerBuilder container) where TKey : notnull
    {
        container
            .RegisterType<AutofacPublisherRegistry<TKey, TData>>()
            .As<IPublisherRegistry<TKey, TData>>()
            .SingleInstance();
    }
}