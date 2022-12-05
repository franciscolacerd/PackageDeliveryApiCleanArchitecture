namespace PackageDelivery.Domain.Models.Delivery
{
    public class ContactModel
    {
        public string Name { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }
    }
}