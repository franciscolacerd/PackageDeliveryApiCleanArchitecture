using AutoMapper;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class DeliveryAttributeRepository : GenericRepository<DeliveryAttribute, DeliveryAttributeDto>, IDeliveryAttributeRepository
    {
        public DeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}