using PackageDelivery.Domain.DTOs.Common;
using PackageDelivery.Domain.Entities;

namespace PackageDelivery.Domain.DTOs
{
    public partial class DeliveryDeliveryAttributeDto : BaseDto
    {
        public int DeliveryId { get; set; }
        public int DeliveryAttributeId { get; set; }

        public virtual Delivery Delivery { get; set; } = null!;
        public virtual DeliveryAttributeDto DeliveryAttribute { get; set; } = null!;
    }
}