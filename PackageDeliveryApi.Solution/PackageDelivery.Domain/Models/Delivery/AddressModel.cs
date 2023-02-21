namespace PackageDelivery.Domain.Models.Delivery;

public class AddressModel
{
    public string AddressLine { get; set; } = null!;

    public string? Place { get; set; }

    public string ZipCode { get; set; } = null!;

    public string ZipCodePlace { get; set; } = null!;
    public string? CountryCode { get; set; }
}