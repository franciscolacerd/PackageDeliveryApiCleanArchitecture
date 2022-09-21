using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class ApiLogRepository : GenericRepository<ApiLog, ApiLogDto>, IApiLogRepository
    {
        public ApiLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}