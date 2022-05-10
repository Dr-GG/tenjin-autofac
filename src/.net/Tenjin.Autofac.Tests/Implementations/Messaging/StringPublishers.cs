using Tenjin.Autofac.Tests.Constants;
using Tenjin.Implementations.Messaging.PublisherSubscriber;
using Tenjin.Interfaces.Messaging.PublishSubscriber;

namespace Tenjin.Autofac.Tests.Implementations.Messaging
{
    public class StringPublisherA : Publisher<object>, IDiscoverablePublisher<string, object>
    {
        public string Id => DiscoverablePublisherConstants.StringIds.A;
    }

    public class StringPublisherB : Publisher<object>, IDiscoverablePublisher<string, object>
    {
        public string Id => DiscoverablePublisherConstants.StringIds.B;
    }

    public class StringPublisherC : Publisher<object>, IDiscoverablePublisher<string, object>
    {
        public string Id => DiscoverablePublisherConstants.StringIds.C;
    }

    public class StringPublisherD : Publisher<object>, IDiscoverablePublisher<string, object>
    {
        public string Id => DiscoverablePublisherConstants.StringIds.D;
    }

    public class StringPublisherE : Publisher<object>, IDiscoverablePublisher<string, object>
    {
        public string Id => DiscoverablePublisherConstants.StringIds.E;
    }
}
