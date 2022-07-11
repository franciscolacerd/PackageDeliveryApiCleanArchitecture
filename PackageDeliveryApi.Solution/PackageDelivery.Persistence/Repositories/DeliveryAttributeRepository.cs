using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class DeliveryAttributeRepository : GenericRepository<DeliveryAttribute, DeliveryAttributeDto>, IDeliveryAttributeRepository
    {
        public DeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}