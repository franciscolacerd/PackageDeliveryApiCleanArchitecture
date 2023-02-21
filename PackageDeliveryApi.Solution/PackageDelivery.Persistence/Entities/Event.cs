using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public class Event : BaseDomainEntity
    {
        public int DeliveryId { get; set; }

        public int? PackageId { get; set; }

        public int EventTypeId { get; set; }

        public virtual Delivery Delivery { get; set; } = null!;

        public virtual Package? Package { get; set; }

        public virtual EventType EventType { get; set; } = null!;
    }
}