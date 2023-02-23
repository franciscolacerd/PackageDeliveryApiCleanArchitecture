using PackageDelivery.Domain.DTOs.Common;

namespace PackageDelivery.Domain.DTOs
{
    public partial class DeliveryDeliveryAttributeDto : BaseDomainDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryAttributeId { get; set; }

        public virtual DeliveryDto Delivery { get; set; } = null!;
        public virtual DeliveryAttributeDto DeliveryAttribute { get; set; } = null!;
    }
}