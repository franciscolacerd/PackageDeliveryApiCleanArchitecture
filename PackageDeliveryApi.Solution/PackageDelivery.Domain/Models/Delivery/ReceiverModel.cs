namespace PackageDelivery.Domain.Models.Delivery
{
    public class ReceiverModel
    {
        public string ReceiverName { get; set; } = null!;
        public ContactModel Contact { get; set; } = null!;

        public AddressModel Address { get; set; } = null!;
    }
}