using System.Collections.Generic;
using Tenjin.Implementations.Messaging.PublisherSubscriber;
using Tenjin.Interfaces.Messaging.PublishSubscriber;

namespace Tenjin.Autofac.Implementations.Messaging.PublisherSubscriber
{
    public class AutofacPublisherRegistry<TKey, TData> : PublisherRegistry<TKey, TData> where TKey : notnull
    {
        public AutofacPublisherRegistry(IEnumerable<IDiscoverablePublisher<TKey, TData>> publishers)
        {
            Register(publishers);
        }
    }
}
