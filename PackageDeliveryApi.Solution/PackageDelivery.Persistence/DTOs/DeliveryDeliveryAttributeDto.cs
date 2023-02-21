using PackageDelivery.Persistence.DTOs.Common;

namespace PackageDelivery.Persistence.DTOs
{
    public partial class DeliveryDeliveryAttributeDto : BaseDomainDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryAttributeId { get; set; }

        public virtual DeliveryDto Delivery { get; set; } = null!;
        public virtual DeliveryAttributeDto DeliveryAttribute { get; set; } = null!;
    }
}