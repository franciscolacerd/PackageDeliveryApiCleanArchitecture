using AutoMapper;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Application.DTOs;
using PackageDelivery.Domain;

namespace PackageDelivery.Persistence.Repositories
{
    public class PackageRepository : GenericRepository<Package, PackageDto>, IPackageRepository
    {
        public PackageRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}