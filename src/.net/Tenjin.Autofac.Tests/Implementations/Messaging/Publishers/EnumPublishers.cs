﻿using Tenjin.Autofac.Tests.Enums;
using Tenjin.Implementations.Messaging.Publishers;
using Tenjin.Interfaces.Messaging.Publishers;

namespace Tenjin.Autofac.Tests.Implementations.Messaging.Publishers;

public class EnumPublisherDecimal : Publisher<object>, IDiscoverablePublisher<TestPublisherType, object>
{
    public TestPublisherType Id => TestPublisherType.Decimal;
}

public class EnumPublisherDouble : Publisher<object>, IDiscoverablePublisher<TestPublisherType, object>
{
    public TestPublisherType Id => TestPublisherType.Double;
}

public class EnumPublisherInt16 : Publisher<object>, IDiscoverablePublisher<TestPublisherType, object>
{
    public TestPublisherType Id => TestPublisherType.Int16;
}

public class EnumPublisherInt32 : Publisher<object>, IDiscoverablePublisher<TestPublisherType, object>
{
    public TestPublisherType Id => TestPublisherType.Int32;
}

public class EnumPublisherInt64 : Publisher<object>, IDiscoverablePublisher<TestPublisherType, object>
{
    public TestPublisherType Id => TestPublisherType.Int64;
}