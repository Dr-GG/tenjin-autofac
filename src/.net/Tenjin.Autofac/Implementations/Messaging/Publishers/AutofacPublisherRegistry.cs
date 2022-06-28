using System.Collections.Generic;
using Tenjin.Implementations.Messaging.Publishers;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Implementations.Messaging.Publishers;

public class AutofacPublisherRegistry<TKey, TData> : PublisherRegistry<TKey, TData> where TKey : notnull
{
    public AutofacPublisherRegistry(IEnumerable<IDiscoverablePublisher<TKey, TData>> publishers)
    {
        Register(publishers);
    }
}