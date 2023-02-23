namespace PackageDelivery.Domain.Models.Delivery
{
    public class SenderModel
    {
        public string Name { get; set; } = null!;
        public ContactModel Contact { get; set; } = null!;

        public AddressModel Address { get; set; } = null!;
    }
}