using AutoMapper;
using PackageDelivery.Domain.Common;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class DeliveryAttributeRepository : GenericRepository<DeliveryAttribute, DeliveryAttributeDto>, IDeliveryAttributeRepository
    {
        public DeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}