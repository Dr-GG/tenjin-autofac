﻿using System.Collections.Generic;
using Tenjin.Implementations.Messaging;
using Tenjin.Interfaces.Messaging;

namespace Tenjin.Autofac.Implementations.Messaging
{
    public class AutofacPublisherRegistry<TKey, TData> : PublisherRegistry<TKey, TData> where TKey : notnull
    {
        public AutofacPublisherRegistry(IEnumerable<IDiscoverablePublisher<TKey, TData>> publishers)
        {
            Register(publishers);
        }
    }
}
