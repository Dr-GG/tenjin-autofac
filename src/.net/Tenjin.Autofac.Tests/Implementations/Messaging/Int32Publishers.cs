using Tenjin.Autofac.Tests.Constants;
using Tenjin.Implementations.Messaging.PublisherSubscriber;
using Tenjin.Interfaces.Messaging.PublishSubscriber;

namespace Tenjin.Autofac.Tests.Implementations.Messaging
{
    public class Int32Publisher1 : Publisher<object>, IDiscoverablePublisher<int, object>
    {
        public int Id => DiscoverablePublisherConstants.Int32Ids._1;
    }

    public class Int32Publisher2 : Publisher<object>, IDiscoverablePublisher<int, object>
    {
        public int Id => DiscoverablePublisherConstants.Int32Ids._2;
    }

    public class Int32Publisher3 : Publisher<object>, IDiscoverablePublisher<int, object>
    {
        public int Id => DiscoverablePublisherConstants.Int32Ids._3;
    }

    public class Int32Publisher4 : Publisher<object>, IDiscoverablePublisher<int, object>
    {
        public int Id => DiscoverablePublisherConstants.Int32Ids._4;
    }

    public class Int32Publisher5 : Publisher<object>, IDiscoverablePublisher<int, object>
    {
        public int Id => DiscoverablePublisherConstants.Int32Ids._5;
    }
}
