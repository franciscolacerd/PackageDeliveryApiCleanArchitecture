using AutoMapper;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class ExceptionLogRepository : GenericRepository<ExceptionLog, ExceptionLogDto>, IExceptionLogRepository
    {
        public ExceptionLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}