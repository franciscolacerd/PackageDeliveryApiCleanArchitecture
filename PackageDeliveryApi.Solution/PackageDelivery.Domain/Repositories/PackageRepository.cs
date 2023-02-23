using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class PackageRepository : GenericRepository<Package, PackageDto>, IPackageRepository
    {
        public PackageRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}