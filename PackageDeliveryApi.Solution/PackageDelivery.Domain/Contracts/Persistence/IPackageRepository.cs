using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IPackageRepository : IGenericRepository<Package, PackageDto>
    {
    }
}