namespace PackageDelivery.Domain.Models.Delivery;

public class DetailsModel
{
    public string? ClientReference { get; set; }
    public int NumberOfVolumes { get; set; }
    public decimal TotalWeightOfVolumes { get; set; }
    public decimal? Amount { get; set; }
    public string? Instructions { get; set; }
    public string? PreferentialPeriod { get; set; }
}