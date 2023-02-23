namespace PackageDelivery.Domain.Models.Delivery
{
    public class DeliveryModel
    {
        public DetailsModel Details { get; set; } = null!;

        public SenderModel Sender { get; set; } = null!;

        public ReceiverModel Receiver { get; set; } = null!;

        public AttributesModel Attributes { get; set; } = null!;
    }
}