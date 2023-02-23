using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType, EventTypeDto>, IEventTypeRepository
    {
        public EventTypeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}