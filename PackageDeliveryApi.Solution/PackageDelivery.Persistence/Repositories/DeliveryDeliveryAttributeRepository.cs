using AutoMapper;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Domain;

namespace PackageDelivery.Persistence.Repositories
{
    public class DeliveryDeliveryAttributeRepository : GenericRepository<DeliveryDeliveryAttribute, DeliveryDeliveryAttributeDto>, IDeliveryDeliveryAttributeRepository
    {
        public DeliveryDeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}