using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public class EventType : BaseDomainEntity
    {
        public string EventTypeENG { get; set; } = null!;
        public string EventTypeES { get; set; } = null!;
        public string EventTypePT { get; set; } = null!;
        public virtual ICollection<Event> Events { get; set; } = null!;
    }
}