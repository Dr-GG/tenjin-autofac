using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using Tenjin.Autofac.Tests.Constants;
using Tenjin.Autofac.Tests.Enums;
using Tenjin.Autofac.Tests.Models.Messaging;
using Tenjin.Autofac.Tests.Utilities;
using Tenjin.Interfaces.Messaging;

namespace Tenjin.Autofac.Tests.ImplementationsTests.MessagingTests
{
    [TestFixture]
    public class AutofacPublisherRegistryTests
    {
        private static readonly TestPublisherRegistryData<string> StringDiscoverablePublishersData = new()
        {
            TestExistingPublisherIds = DiscoverablePublisherConstants.StringIds.Ids,
            NonExistingPublisherIds = new[]
            {
                "X",
                "Y",
                "Z",
                "1",
                "2",
                "3"
            }
        };

        private static readonly TestPublisherRegistryData<int> Int32DiscoverablePublishersData = new()
        {
            TestExistingPublisherIds = DiscoverablePublisherConstants.Int32Ids.Ids,
            NonExistingPublisherIds = new[]
            {
                10,
                20,
                30,
                100,
                200,
                300
            }
        };

        private static readonly TestPublisherRegistryData<TestPublisherType> EnumDiscoverablePublishersData = new()
        {
            TestExistingPublisherIds = DiscoverablePublisherConstants.EnumIds.Ids,
            NonExistingPublisherIds = new[]
            {
                (TestPublisherType)10,
                (TestPublisherType)20,
                (TestPublisherType)30,
                (TestPublisherType)40,
                (TestPublisherType)50,
            }
        };

        [Test]
        public void GetString_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            Get_WhenProvidedTheCorrectKey_ReturnsThePublisher(StringDiscoverablePublishersData);
        }

        [Test]
        public void GetString_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            Get_WhenProvidedTheIncorrectKey_ThrowsAnError(StringDiscoverablePublishersData);
        }

        [Test]
        public void TryGetString_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            TryGet_WhenProvidedTheCorrectKey_ReturnsThePublisher(StringDiscoverablePublishersData);
        }

        [Test]
        public void TryGetString_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            TryGet_WhenProvidedTheIncorrectKey_ReturnsThePublisher(StringDiscoverablePublishersData);
        }

        [Test]
        public void ThisIndexString_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            ThisIndex_WhenProvidedTheCorrectKey_ReturnsThePublisher(StringDiscoverablePublishersData);
        }

        [Test]
        public void ThisIndexString_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            ThisIndex_WhenProvidedTheIncorrectKey_ThrowsAnError(StringDiscoverablePublishersData);
        }

        [Test]
        public void GetInt32_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            Get_WhenProvidedTheCorrectKey_ReturnsThePublisher(Int32DiscoverablePublishersData);
        }

        [Test]
        public void GetInt32_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            Get_WhenProvidedTheIncorrectKey_ThrowsAnError(Int32DiscoverablePublishersData);
        }

        [Test]
        public void TryGetInt32_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            TryGet_WhenProvidedTheCorrectKey_ReturnsThePublisher(Int32DiscoverablePublishersData);
        }

        [Test]
        public void TryGetInt32_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            TryGet_WhenProvidedTheIncorrectKey_ReturnsThePublisher(Int32DiscoverablePublishersData);
        }

        [Test]
        public void ThisIndexInt32_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            ThisIndex_WhenProvidedTheCorrectKey_ReturnsThePublisher(Int32DiscoverablePublishersData);
        }

        [Test]
        public void ThisIndexInt32_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            ThisIndex_WhenProvidedTheIncorrectKey_ThrowsAnError(Int32DiscoverablePublishersData);
        }

        [Test]
        public void GetEnum_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            Get_WhenProvidedTheCorrectKey_ReturnsThePublisher(EnumDiscoverablePublishersData);
        }

        [Test]
        public void GetEnum_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            Get_WhenProvidedTheIncorrectKey_ThrowsAnError(EnumDiscoverablePublishersData);
        }

        [Test]
        public void TryGetEnum_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            TryGet_WhenProvidedTheCorrectKey_ReturnsThePublisher(EnumDiscoverablePublishersData);
        }

        [Test]
        public void TryGetEnum_WhenProvidedTheIncorrectKey_ThrowsAnError()
        {
            TryGet_WhenProvidedTheIncorrectKey_ReturnsThePublisher(EnumDiscoverablePublishersData);
        }

        [Test]
        public void ThisIndexEnum_WhenProvidedTheCorrectKey_ReturnsThePublisher()
        {
            ThisIndex_WhenProvidedTheCorrectKey_ReturnsThePublisher(EnumDiscoverablePublishersData);
        }

        private static void TryGet_WhenProvidedTheCorrectKey_ReturnsThePublisher<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.TestExistingPublisherIds)
            {
                var gotPublisher = registry.TryGet(id, out var publisher);

                Assert.IsTrue(gotPublisher);
                Assert.IsNotNull(publisher);
                Assert.AreEqual(id, ((IDiscoverablePublisher<TKey, object>)publisher!).Id);
            }
        }

        private static void TryGet_WhenProvidedTheIncorrectKey_ReturnsThePublisher<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.NonExistingPublisherIds)
            {
                var gotPublisher = registry.TryGet(id, out var publisher);

                Assert.IsFalse(gotPublisher);
                Assert.IsNull(publisher);
            }
        }

        private static void Get_WhenProvidedTheCorrectKey_ReturnsThePublisher<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.TestExistingPublisherIds)
            {
                var publisher = registry.Get(id);

                Assert.IsNotNull(publisher);
                Assert.AreEqual(id, ((IDiscoverablePublisher<TKey, object>)publisher).Id);
            }
        }

        private static void Get_WhenProvidedTheIncorrectKey_ThrowsAnError<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.NonExistingPublisherIds)
            {
                Assert.Throws<KeyNotFoundException>(() => registry.Get(id));
            }
        }

        private static void ThisIndex_WhenProvidedTheCorrectKey_ReturnsThePublisher<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.TestExistingPublisherIds)
            {
                var publisher = registry[id];

                Assert.IsNotNull(publisher);
                Assert.AreEqual(id, ((IDiscoverablePublisher<TKey, object>)publisher).Id);
            }
        }

        private static void ThisIndex_WhenProvidedTheIncorrectKey_ThrowsAnError<TKey>(TestPublisherRegistryData<TKey> data) where TKey : notnull
        {
            using var container = PublishRegistryContainerUtilities.CreatePublisherRegistriesContainer();
            var registry = container.Resolve<IPublisherRegistry<TKey, object>>();

            foreach (var id in data.NonExistingPublisherIds)
            {
                Assert.Throws<KeyNotFoundException>(() => registry[id].Dispose());
            }
        }
    }
}
