using AutoMapper;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Repositories;

namespace PackageDelivery.Domain.Repositories
{
    public class ApiLogRepository : GenericRepository<ApiLog, ApiLogDto>, IApiLogRepository
    {
        public ApiLogRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}