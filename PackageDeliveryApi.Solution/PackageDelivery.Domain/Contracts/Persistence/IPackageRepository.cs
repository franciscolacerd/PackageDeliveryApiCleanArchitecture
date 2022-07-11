using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Domain.Contracts.Persistence
{
    public interface IPackageRepository : IGenericRepository<Package, PackageDto>
    {
    }
}