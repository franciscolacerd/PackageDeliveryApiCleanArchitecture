using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class ExceptionLogRepository : GenericRepository<ExceptionLog, ExceptionLogDto>, IExceptionLogRepository
    {
        public ExceptionLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}