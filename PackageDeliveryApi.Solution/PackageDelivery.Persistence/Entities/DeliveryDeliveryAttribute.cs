using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public partial class DeliveryDeliveryAttribute : BaseDomainEntity
    {
        public int DeliveryId { get; set; }
        public int DeliveryAttributeId { get; set; }

        public virtual Delivery Delivery { get; set; } = null!;
        public virtual DeliveryAttribute DeliveryAttribute { get; set; } = null!;
    }
}