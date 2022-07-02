using PackageDelivery.Application.DTOs.Common;

namespace PackageDelivery.Domain
{
    public partial class DeliveryDeliveryAttributeDto : BaseDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryAttributeId { get; set; }

        public virtual Delivery Delivery { get; set; } = null!;
        public virtual DeliveryAttributeDto DeliveryAttribute { get; set; } = null!;
    }
}