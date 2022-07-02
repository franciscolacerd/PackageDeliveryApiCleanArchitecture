using AutoMapper;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Domain;

namespace PackageDelivery.Persistence.Repositories
{
    public class DeliveryAttributeRepository : GenericRepository<DeliveryAttribute, DeliveryAttributeDto>, IDeliveryAttributeRepository
    {
        public DeliveryAttributeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}