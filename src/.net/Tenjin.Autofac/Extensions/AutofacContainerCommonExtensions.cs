using Autofac;

namespace Tenjin.Autofac.Extensions;

public static class AutofacContainerCommonExtensions
{
    public static void RegisterSingleton(this ContainerBuilder container, object settings)
    {
        container
            .RegisterInstance(settings)
            .AsSelf()
            .SingleInstance();
    }
}