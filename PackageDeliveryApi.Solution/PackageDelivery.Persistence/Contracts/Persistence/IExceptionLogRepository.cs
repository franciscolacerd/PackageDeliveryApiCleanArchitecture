using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Contracts.Persistence
{
    public interface IExceptionLogRepository : IGenericRepository<ExceptionLog, ExceptionLogDto>
    {
    }
}