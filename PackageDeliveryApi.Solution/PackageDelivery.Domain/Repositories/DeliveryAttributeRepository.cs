using AutoMapper;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Repositories;

namespace PackageDelivery.Domain.Repositories
{
    public class DeliveryAttributeRepository : GenericRepository<DeliveryAttribute, DeliveryAttributeDto>, IDeliveryAttributeRepository
    {
        public DeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}