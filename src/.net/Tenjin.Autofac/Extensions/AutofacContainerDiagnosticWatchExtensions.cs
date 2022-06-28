using Autofac;
using Tenjin.Implementations.Diagnostics;
using Tenjin.Interfaces.Diagnostics;

namespace Tenjin.Autofac.Extensions;

public static class AutofacContainerDiagnosticWatchExtensions
{
    public static void RegisterSystemClockProvider(this ContainerBuilder builder, bool useUct = true)
    {
        builder
            .Register(_ => new SystemClockProvider(useUct))
            .As<ISystemClockProvider>()
            .SingleInstance();
    }

    public static void RegisterDiagnosticsWatch(this ContainerBuilder builder, bool useUct = true)
    {
        builder.RegisterSystemClockProvider(useUct);

        builder
            .RegisterType<DiagnosticsStopwatch>()
            .As<IDiagnosticsStopwatch>()
            .InstancePerLifetimeScope();
    }
}