using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.Tests.Common;
using PackageDelivery.Persistence.Tests.Strapper;

namespace PackageDelivery.Persistence.Tests
{
    public class PackagesTests : BaseTest
    {
        private ServiceProvider _serviceProvider;

        [Test]
        public async Task Package_PackageGetById_ReturnPackageWithDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var package = await _unitOfWork.PackageRepository.QueryFirstAsync(x => x.DeliveryId == dummyDelivery.Id);

            package.Should().NotBeNull();
        }

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}