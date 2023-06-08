using Autofac;

namespace Tenjin.Autofac.Extensions;

/// <summary>
/// A collection of extension methods for Autofac containers.
/// </summary>
public static class AutofacContainerCommonExtensions
{
    /// <summary>
    /// Registers an object instance as a singleton.
    /// </summary>
    public static void RegisterSingleton(this ContainerBuilder container, object settings)
    {
        container
            .RegisterInstance(settings)
            .AsSelf()
            .SingleInstance();
    }
}