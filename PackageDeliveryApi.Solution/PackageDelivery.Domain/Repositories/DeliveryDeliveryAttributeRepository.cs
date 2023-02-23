using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class DeliveryDeliveryAttributeRepository : GenericRepository<DeliveryDeliveryAttribute, DeliveryDeliveryAttributeDto>, IDeliveryDeliveryAttributeRepository
    {
        public DeliveryDeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}