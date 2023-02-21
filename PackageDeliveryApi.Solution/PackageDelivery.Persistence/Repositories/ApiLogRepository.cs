using AutoMapper;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class ApiLogRepository : GenericRepository<ApiLog, ApiLogDto>, IApiLogRepository
    {
        public ApiLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}