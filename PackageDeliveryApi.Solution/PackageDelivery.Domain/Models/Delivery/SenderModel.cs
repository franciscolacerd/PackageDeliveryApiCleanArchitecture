namespace PackageDelivery.Domain.Models.Delivery
{
    public class SenderModel
    {
        public string SenderName { get; set; } = null!;
        public ContactModel Contact { get; set; } = null!;

        public AddressModel Address { get; set; } = null!;
    }
}