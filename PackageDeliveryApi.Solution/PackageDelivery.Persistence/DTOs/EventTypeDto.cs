using PackageDelivery.Persistence.DTOs.Common;

namespace PackageDelivery.Persistence.DTOs
{
    public class EventTypeDto : BaseDomainDto
    {
        public string EventTypeENG { get; set; } = null!;
        public string EventTypeES { get; set; } = null!;
        public string EventTypePT { get; set; } = null!;
        public virtual ICollection<EventDto> Events { get; set; } = null!;
    }
}