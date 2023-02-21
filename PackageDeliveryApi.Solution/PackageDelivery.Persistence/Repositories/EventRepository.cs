using AutoMapper;
using PackageDelivery.Persistence.Contracts.Persistence;
using PackageDelivery.Persistence.DTOs;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Repositories
{
    public class EventRepository : GenericRepository<Event, EventDto>, IEventRepository
    {
        public EventRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}