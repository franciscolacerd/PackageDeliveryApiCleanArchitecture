using AutoMapper;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType, EventTypeDto>, IEventTypeRepository
    {
        public EventTypeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}