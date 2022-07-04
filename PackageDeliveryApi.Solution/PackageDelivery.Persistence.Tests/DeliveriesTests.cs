using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Persistence.Tests.Common;
using PackageDelivery.Persistence.Tests.Strapper;

namespace PackageDelivery.Persistence.Tests
{
    public class DeliveriesTests : BaseTest
    {
        private ServiceProvider _serviceProvider;

        private readonly string _receiverName = "francisco lacerda";

        [Test]
        public void Delivery_CreateDeliveryWithPackages_ReturnDelivery()
        {
            GetAndAssertDelivery();
        }

        [Test]
        public async Task Delivery_CreateDeliveryWithPackages_ReturnDeliveryAsync()
        {
            await GetAndAssertDeliveryAsync();
        }

        [Test]
        public void Delivery_CreateServicesWithTransaction_TransactionsSuccess()
        {
            _unitOfWork.BeginTransaction();

            var firstDelivery = _unitOfWork.DeliveryRepository.Add(Build());

            firstDelivery.Should().NotBeNull();

            var secondDelivery = _unitOfWork.DeliveryRepository.Add(Build());

            secondDelivery.Should().NotBeNull();

            _unitOfWork.CommitTransaction();

            _unitOfWork.Complete();

            var firstDeliveryCreated = _unitOfWork.DeliveryRepository.GetById(firstDelivery.Id);

            firstDeliveryCreated.Should().NotBeNull();

            var secondDeliveryCreated = _unitOfWork.DeliveryRepository.GetById(secondDelivery.Id);

            secondDeliveryCreated.Should().NotBeNull();
        }

        [Test]
        public async Task Delivery_CreateServicesWithTransaction_TransactionsSuccessAsync()
        {
            await _unitOfWork.BeginTransactionAsync();

            var firstDelivery = await _unitOfWork.DeliveryRepository.AddAsync(Build());

            firstDelivery.Should().NotBeNull();

            var secondDelivery = await _unitOfWork.DeliveryRepository.AddAsync(Build());

            secondDelivery.Should().NotBeNull();

            await _unitOfWork.CommitTransactionAsync();

            await _unitOfWork.CompleteAsync();

            var firstDeliveryCreated = await _unitOfWork.DeliveryRepository.GetByIdAsync(firstDelivery.Id);

            firstDeliveryCreated.Should().NotBeNull();

            var secondDeliveryCreated = await _unitOfWork.DeliveryRepository.GetByIdAsync(secondDelivery.Id);

            secondDeliveryCreated.Should().NotBeNull();
        }

        [Test]
        public void Delivery_DeleteDeliveryChangeDeliveryDate_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            _unitOfWork.DeliveryRepository.Delete(delivery.Id);

            _unitOfWork.SaveChanges();

            delivery = _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().BeNull();
        }

        [Test]
        public async Task Delivery_DeleteDeliveryChangeDeliveryDate_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            dummyDelivery.Should().NotBeNull();

            await _unitOfWork.DeliveryRepository.DeleteAsync(dummyDelivery.Id);

            await _unitOfWork.SaveChangesAsync();

            var deletedDelivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode);

            deletedDelivery.Should().BeNull();
        }

        [Test]
        public void Delivery_DeliveryGetByBarCode_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);
        }

        [Test]
        public async Task Delivery_DeliveryGetByBarCode_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);
        }

        [Test]
        public void Delivery_DeliveryGetByBarCodeIncludePackages_ReturnDeliveryWithPackages()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(
                predicate: x => x.BarCode == dummyDelivery.BarCode,
                includes: x => x.Packages);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);

            delivery.Packages.Should().NotBeNull();

            delivery.Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public async Task Delivery_DeliveryGetByBarCodeIncludePackages_ReturnDeliveryWithPackagesAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode,
                includes: x => x.Packages);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);

            delivery.Packages.Should().NotBeNull();

            delivery.Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public void Delivery_DeliveryGetByBarCodeIncludePackagesOrderBy_ReturnDeliveryWithPackages()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(
                predicate: x => x.BarCode == dummyDelivery.BarCode,
                orderBy: x => x.OrderByDescending(y => y.CreatedDateUtc),
                includes: x => x.Packages);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);

            delivery.Packages.Should().NotBeNull();

            delivery.Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public async Task Delivery_DeliveryGetByBarCodeIncludePackagesOrderBy_ReturnDeliveryWithPackagesAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode,
                orderBy: x => x.OrderByDescending(y => y.CreatedDateUtc),
                includes: x => x.Packages);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);

            delivery.Packages.Should().NotBeNull();

            delivery.Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public void Delivery_DeliveryGetById_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.GetById(dummyDelivery.Id);

            delivery.Should().NotBeNull();
        }

        [Test]
        public async Task Delivery_DeliveryGetById_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.GetByIdAsync(dummyDelivery.Id);

            delivery.Should().NotBeNull();
        }

        [Test]
        public void Delivery_DeliveryGetPagedListByName_ReturnDeliveryWithPackages()
        {
            var pagedDeliveries = _unitOfWork.DeliveryRepository.Query(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);
        }

        [Test]
        public async Task Delivery_DeliveryGetPagedListByName_ReturnDeliveryWithPackagesAsync()
        {
            var pagedDeliveries = await _unitOfWork.DeliveryRepository.QueryAsync(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);
        }

        [Test]
        public void Delivery_DeliveryGetPagedListByNameIncludeChild_ReturnDeliveryWithPackages()
        {
            var pagedDeliveries = _unitOfWork.DeliveryRepository.Query(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName,
                includes: x => x.Packages);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);

            pagedDeliveries.Results.First().Packages.Should().NotBeNull();

            pagedDeliveries.Results.First().Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public async Task Delivery_DeliveryGetPagedListByNameIncludeChild_ReturnDeliveryWithPackagesAsync()
        {
            var pagedDeliveries = await _unitOfWork.DeliveryRepository.QueryAsync(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName,
                includes: x => x.Packages);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);

            pagedDeliveries.Results.First().Packages.Should().NotBeNull();

            pagedDeliveries.Results.First().Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public void Delivery_DeliveryGetPagedListByNameIncludeChildOrderByCreateDateUtc_ReturnDeliveryWithPackages()
        {
            var pagedDeliveries = _unitOfWork.DeliveryRepository.Query(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName,
                orderBy: x => x.OrderBy(y => y.CreatedDateUtc),
                includes: x => x.Packages);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);

            pagedDeliveries.Results.First().Packages.Should().NotBeNull();

            pagedDeliveries.Results.First().Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public async Task Delivery_DeliveryGetPagedListByNameIncludeChildOrderByCreateDateUtc_ReturnDeliveryWithPackagesAsync()
        {
            var pagedDeliveries = await _unitOfWork.DeliveryRepository.QueryAsync(
                page: 1,
                pageSize: 20,
                predicate: x => x.ReceiverName == _receiverName,
                orderBy: x => x.OrderBy(y => y.CreatedDateUtc),
                includes: x => x.Packages);

            pagedDeliveries.Should().NotBeNull();

            pagedDeliveries.Results.Should().HaveCountGreaterThan(0);

            pagedDeliveries.PageCount.Should().BeGreaterThan(0);

            pagedDeliveries.RowCount.Should().BeGreaterThan(0);

            pagedDeliveries.Results.First().Packages.Should().NotBeNull();

            pagedDeliveries.Results.First().Packages.Should().HaveCountGreaterThan(0);
        }

        [Test]
        public void Delivery_UpdateDeliveryChangeDeliveryDate_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var deliveryDate = DateTime.UtcNow.AddDays(2);

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.DeliveryDate = deliveryDate;

            _unitOfWork.DeliveryRepository.Update(delivery);

            _unitOfWork.SaveChanges();

            delivery =  _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.DeliveryDate.Should().Be(deliveryDate);
        }

        [Test]
        public async Task Delivery_UpdateDeliveryChangeDeliveryDate_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var deliveryDate = DateTime.UtcNow.AddDays(2);

            dummyDelivery.Should().NotBeNull();

            dummyDelivery.DeliveryDate = deliveryDate;

            await _unitOfWork.DeliveryRepository.UpdateAsync(dummyDelivery);

            await _unitOfWork.SaveChangesAsync();

            var updatedDelivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode);

            updatedDelivery.Should().NotBeNull();

            updatedDelivery.DeliveryDate.Should().Be(deliveryDate);
        }

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _unitOfWork = _serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}