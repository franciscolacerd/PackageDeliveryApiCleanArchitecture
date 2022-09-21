using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class ExceptionLogRepository : GenericRepository<ExceptionLog, ExceptionLogDto>, IExceptionLogRepository
    {
        public ExceptionLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}