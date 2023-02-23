using AutoMapper;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Repositories;

namespace PackageDelivery.Domain.Repositories
{
    public class DeliveryDeliveryAttributeRepository : GenericRepository<DeliveryDeliveryAttribute, DeliveryDeliveryAttributeDto>, IDeliveryDeliveryAttributeRepository
    {
        public DeliveryDeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}