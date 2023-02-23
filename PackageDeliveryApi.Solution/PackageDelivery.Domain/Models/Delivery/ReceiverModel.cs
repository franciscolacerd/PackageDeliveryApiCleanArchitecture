namespace PackageDelivery.Domain.Models.Delivery
{
    public class ReceiverModel
    {
        public string Name { get; set; } = null!;
        public ContactModel Contact { get; set; } = null!;

        public AddressModel Address { get; set; } = null!;
    }
}