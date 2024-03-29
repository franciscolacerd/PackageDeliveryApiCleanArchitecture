using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Persistence.Tests.Common;
using PackageDelivery.Persistence.Tests.Strapper;

namespace PackageDelivery.Persistence.Tests
{
    public class DeliveriesTests : BaseTest
    {
        private ServiceProvider _serviceProvider;

        private readonly string _receiverName = "francisco lacerda";

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
        public void Should_CreateDeliveryWithPackages_ReturnDelivery()
        {
            GetAndAssertDelivery();
        }

        [Test]
        public async Task Should_CreateDeliveryWithPackages_ReturnDeliveryAsync()
        {
            await GetAndAssertDeliveryAsync();
        }

        [Test]
        public void Should_CreateServicesWithTransaction_TransactionsSuccess()
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
        public async Task Should_CreateServicesWithTransaction_TransactionsSuccessAsync()
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
        public void Should_DeleteDeliveryChangeDeliveryDate_ReturnDelivery()
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
        public async Task Should_DeleteDeliveryChangeDeliveryDate_ReturnDeliveryAsync()
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
        public void Should_DeliveryGetByBarCode_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.QueryFirst(predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);
        }

        [Test]
        public async Task Should_DeliveryGetByBarCode_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.QueryFirstAsync(
                predicate: x => x.BarCode == dummyDelivery.BarCode);

            delivery.Should().NotBeNull();

            delivery.BarCode.Should().NotBeNull();

            delivery.BarCode.Should().BeEquivalentTo(dummyDelivery.BarCode);
        }

        [Test]
        public void Should_DeliveryGetByBarCodeIncludePackages_ReturnDeliveryWithPackages()
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
        public async Task Should_DeliveryGetByBarCodeIncludePackages_ReturnDeliveryWithPackagesAsync()
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
        public void Should_DeliveryGetByBarCodeIncludePackagesOrderBy_ReturnDeliveryWithPackages()
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
        public async Task Should_DeliveryGetByBarCodeIncludePackagesOrderBy_ReturnDeliveryWithPackagesAsync()
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
        public void Should_DeliveryGetById_ReturnDelivery()
        {
            var dummyDelivery = GetAndAssertDelivery();

            var delivery = _unitOfWork.DeliveryRepository.GetById(dummyDelivery.Id);

            delivery.Should().NotBeNull();
        }

        [Test]
        public async Task Should_DeliveryGetById_ReturnDeliveryAsync()
        {
            var dummyDelivery = await GetAndAssertDeliveryAsync();

            var delivery = await _unitOfWork.DeliveryRepository.GetByIdAsync(dummyDelivery.Id);

            delivery.Should().NotBeNull();
        }

        [Test]
        public void Should_DeliveryGetPagedListByName_ReturnDeliveryWithPackages()
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
        public async Task Should_DeliveryGetPagedListByName_ReturnDeliveryWithPackagesAsync()
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
        public void Should_DeliveryGetPagedListByNameIncludeChild_ReturnDeliveryWithPackages()
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
        public async Task Should_DeliveryGetPagedListByNameIncludeChild_ReturnDeliveryWithPackagesAsync()
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
        public void Should_DeliveryGetPagedListByNameIncludeChildOrderByCreateDateUtc_ReturnDeliveryWithPackages()
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
        public async Task Should_DeliveryGetPagedListByNameIncludeChildOrderByCreateDateUtc_ReturnDeliveryWithPackagesAsync()
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
    }
}