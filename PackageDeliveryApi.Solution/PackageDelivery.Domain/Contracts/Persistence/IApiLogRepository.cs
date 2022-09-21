using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IApiLogRepository : IGenericRepository<ApiLog, ApiLogDto>
    {
    }
}