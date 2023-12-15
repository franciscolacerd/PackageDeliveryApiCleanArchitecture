using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Persistence;
using System.Security.Claims;

namespace PackageDelivery.Domain.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;

        private readonly PackageDeliveryDbContext _context;

        private IDbContextTransaction _transaction;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private IApiLogRepository _apiLogRepository;

        private IDeliveryRepository _deliveryRepository;

        private IDeliveryDeliveryAttributeRepository _deliveryDeliveryAttributeRepository;

        private IDeliveryAttributeRepository _deliveryAttributeRepository;

        private IEventRepository _eventRepository;

        private IEventTypeRepository _eventTypeRepository;

        private IExceptionLogRepository _exceptionLogRepository;

        private IPackageRepository _packageRepository;

        public UnitOfWork(PackageDeliveryDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IApiLogRepository ApiLogRepository => _apiLogRepository ??= new ApiLogRepository(_context, _mapper);

        public IDeliveryRepository DeliveryRepository => _deliveryRepository ??= new DeliveryRepository(_context, _mapper);

        public IDeliveryDeliveryAttributeRepository DeliveryDeliveryAttributeRepository => _deliveryDeliveryAttributeRepository ??= new DeliveryDeliveryAttributeRepository(_context, _mapper);

        public IDeliveryAttributeRepository DeliveryAttributeRepository => _deliveryAttributeRepository ??= new DeliveryAttributeRepository(_context, _mapper);

        public IEventRepository EventRepository => _eventRepository ??= new EventRepository(_context, _mapper);

        public IEventTypeRepository EventTypeRepository => _eventTypeRepository ??= new EventTypeRepository(_context, _mapper);

        public IExceptionLogRepository ExceptionLogRepository => _exceptionLogRepository ??= new ExceptionLogRepository(_context, _mapper);

        public IPackageRepository PackageRepository => _packageRepository ??= new PackageRepository(_context, _mapper);

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _transaction =  _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            var username = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            return await _context.SaveChangesAsync(username!, cancellationToken);
        }

        public int Complete()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            return _context.SaveChanges(username!);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await CompleteAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return Complete();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _transaction?.Dispose();
                _context.Dispose();
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}