using Autofac;
using Tenjin.Implementations.Diagnostics;
using Tenjin.Interfaces.Diagnostics;

namespace Tenjin.Autofac.Extensions;

/// <summary>
/// A collection of extension methods for registering the DiagnosticsLapStopwatch instance.
/// </summary>
public static class AutofacContainerDiagnosticsLapStopwatchExtensions
{
    /// <summary>
    /// Registers the ISystemClockProvider.
    /// </summary>
    public static void RegisterSystemClockProvider(this ContainerBuilder builder, bool useUct = true)
    {
        builder
            .Register(_ => new SystemClockProvider(useUct))
            .As<ISystemClockProvider>()
            .SingleInstance();
    }

    /// <summary>
    /// Registers teh DiagnosticsLapStopwatch.
    /// </summary>
    public static void RegisterDiagnosticsWatch(this ContainerBuilder builder, bool useUct = true)
    {
        builder.RegisterSystemClockProvider(useUct);

        builder
            .RegisterType<DiagnosticsLapStopwatch>()
            .As<DiagnosticsLapStopwatch>()
            .InstancePerLifetimeScope();
    }
}