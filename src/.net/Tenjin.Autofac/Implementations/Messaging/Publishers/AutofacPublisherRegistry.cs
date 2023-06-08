using System.Collections.Generic;
using Tenjin.Implementations.Messaging.Publishers;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Implementations.Messaging.Publishers;

/// <summary>
/// The extended PublisherRegistry meant for Autofac.
/// </summary>
public class AutofacPublisherRegistry<TKey, TData> : PublisherRegistry<TKey, TData> where TKey : notnull
{
    /// <summary>
    /// Creates a new instance with all IDiscoverablePublisher interface implementations.
    /// </summary>
    public AutofacPublisherRegistry(IEnumerable<IDiscoverablePublisher<TKey, TData>> publishers)
    {
        Register(publishers);
    }
}