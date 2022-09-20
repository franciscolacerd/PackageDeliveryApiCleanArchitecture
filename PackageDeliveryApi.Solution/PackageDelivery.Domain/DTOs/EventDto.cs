using PackageDelivery.Domain.DTOs.Common;

namespace PackageDelivery.Domain.DTOs
{
    public class EventDto : BaseDomainDto
    {
        public int DeliveryId { get; set; }

        public int? PackageId { get; set; }

        public int EventTypeId { get; set; }

        public virtual DeliveryDto Delivery { get; set; } = null!;

        public virtual PackageDto? Package { get; set; }

        public virtual EventTypeDto EventType { get; set; } = null!;
    }
}