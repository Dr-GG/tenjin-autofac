using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Tenjin.Implementations.Mappers;
using Tenjin.Interfaces.Mappers;

namespace Tenjin.Autofac.Extensions;

/// <summary>
/// A collection of extension methods to register IUnaryMapper and IBinaryMapper instances.
/// </summary>
public static class AutofacContainerMapperExtensions
{
    /// <summary>
    /// Registers all instances from an Assembly that inherits the IUnaryMapper interface.
    /// </summary>
    public static void RegisterUnaryMappers(this ContainerBuilder container, Assembly assembly)
    {
        container
            .RegisterAssemblyTypes(assembly)
            .Where(t => Array.Exists(
                    t.GetInterfaces(), 
                    i => i.IsGenericType
                         && i.GetGenericTypeDefinition() == typeof(IUnaryMapper<,>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }

    /// <summary>
    /// Registers the default implementation of the IBinaryMapper.
    /// </summary>
    public static void RegisterBinaryMapper(this ContainerBuilder container)
    {
        container
            .RegisterGeneric(typeof(BinaryMapper<,>))
            .As(typeof(IBinaryMapper<,>))
            .InstancePerLifetimeScope();
    }

    /// <summary>
    /// Registers all instances from an Assembly that inherits the Tenjin mapper interfaces.
    /// </summary>
    public static void RegisterMappers(this ContainerBuilder container, Assembly assembly)
    {
        container.RegisterUnaryMappers(assembly);
        container.RegisterBinaryMapper();
    }
}