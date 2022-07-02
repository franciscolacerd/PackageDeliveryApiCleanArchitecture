namespace PackageDelivery.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDeliveryRepository DeliveryRepository { get; }
        IPackageRepository PackageRepository { get; }
        IDeliveryDeliveryAttributeRepository DeliveryDeliveryAttributeRepository { get; }
        IDeliveryAttributeRepository DeliveryAttributeRepository { get; }

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> CompleteAsync(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void BeginTransaction();

        void CommitTransaction();

        int Complete();

        int SaveChanges();
    }
}