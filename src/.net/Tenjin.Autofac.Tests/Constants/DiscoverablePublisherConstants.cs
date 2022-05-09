using System.Collections.Generic;
using Tenjin.Autofac.Tests.Enums;

namespace Tenjin.Autofac.Tests.Constants
{
    public static class DiscoverablePublisherConstants
    {
        public static class StringIds
        {
            public const string A = "A";
            public const string B = "B";
            public const string C = "C";
            public const string D = "D";
            public const string E = "E";

            public static IEnumerable<string> Ids = new[]
            {
                A, B, C, D, E
            };
        }

        public static class Int32Ids
        {
            public const int _1 = 1;
            public const int _2 = 2;
            public const int _3 = 3;
            public const int _4 = 4;
            public const int _5 = 5;

            public static IEnumerable<int> Ids = new[]
            {
                _1, _2, _3, _4, _5
            };
        }

        public static class EnumIds
        {
            public const int _1 = 1;
            public const int _2 = 2;
            public const int _3 = 3;
            public const int _4 = 4;
            public const int _5 = 5;

            public static IEnumerable<TestPublisherType> Ids = new[]
            {
                TestPublisherType.Decimal,
                TestPublisherType.Double,
                TestPublisherType.Int16,
                TestPublisherType.Int32,
                TestPublisherType.Int64
            };
        }
    }
}
