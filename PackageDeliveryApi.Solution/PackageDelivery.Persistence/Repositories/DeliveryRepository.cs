using AutoMapper;
using PackageDelivery.Application.Contracts.Persistence;
using PackageDelivery.Application.DTOs;
using PackageDelivery.Domain;

namespace PackageDelivery.Persistence.Repositories
{
    public class DeliveryRepository : GenericRepository<Delivery, DeliveryDto>, IDeliveryRepository
    {
        public DeliveryRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}