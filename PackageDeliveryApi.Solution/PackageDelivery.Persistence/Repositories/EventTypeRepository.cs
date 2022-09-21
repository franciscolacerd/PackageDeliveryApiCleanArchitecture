using AutoMapper;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType, EventTypeDto>, IEventTypeRepository
    {
        public EventTypeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}