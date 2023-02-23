using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class ApiLogRepository : GenericRepository<ApiLog, ApiLogDto>, IApiLogRepository
    {
        public ApiLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}