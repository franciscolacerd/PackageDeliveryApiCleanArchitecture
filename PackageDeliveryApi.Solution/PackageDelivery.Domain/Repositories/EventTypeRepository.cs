using AutoMapper;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Repositories;

namespace PackageDelivery.Domain.Repositories
{
    public class EventTypeRepository : GenericRepository<EventType, EventTypeDto>, IEventTypeRepository
    {
        public EventTypeRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}