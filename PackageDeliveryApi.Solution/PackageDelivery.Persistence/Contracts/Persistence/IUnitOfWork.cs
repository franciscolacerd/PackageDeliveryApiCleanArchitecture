namespace PackageDelivery.Persistence.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IApiLogRepository ApiLogRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IDeliveryDeliveryAttributeRepository DeliveryDeliveryAttributeRepository { get; }
        IDeliveryAttributeRepository DeliveryAttributeRepository { get; }
        IEventRepository EventRepository { get; }
        IEventTypeRepository EventTypeRepository { get; }
        IExceptionLogRepository ExceptionLogRepository { get; }
        IPackageRepository PackageRepository { get; }

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