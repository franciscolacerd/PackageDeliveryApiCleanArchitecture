using AutoMapper;
using PackageDelivery.Domain.Common;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Persistence;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Repositories
{
    public class EventRepository : GenericRepository<Event, EventDto>, IEventRepository
    {
        public EventRepository(PackageDeliveryDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}