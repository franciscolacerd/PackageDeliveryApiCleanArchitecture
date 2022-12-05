using PackageDelivery.Domain.SmartEnums;

namespace PackageDelivery.Domain.Models.Delivery
{
    public class DeliveryModel
    {
        public DeliveryDetailsModel DeliveryDetails { get; set; } = null!;

        public SenderModel Sender { get; set; } = null!;

        public ReceiverModel Receiver { get; set; } = null!;

        public List<DeliveryAttributes> DeliveryAttributes { get; set; } = null!;
    }
}