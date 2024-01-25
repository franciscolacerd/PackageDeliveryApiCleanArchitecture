using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Persistence.Tests.Common;
using PackageDelivery.Persistence.Tests.Strapper;

namespace PackageDelivery.Persistence.Tests
{
    public class PackagesTests : BaseTest
    {
        private ServiceProvider _serviceProvider;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _serviceProvider.DisposeAsync();
        }

        [Test]
        public async Task Should_PackageGetById_ReturnPackageWithDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var package = await _unitOfWork.PackageRepository.QueryFirstAsync(x => x.DeliveryId == dummyDelivery.Id);

            package.Should().NotBeNull();
        }
    }
}