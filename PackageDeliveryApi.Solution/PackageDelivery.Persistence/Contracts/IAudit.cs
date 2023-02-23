namespace PackageDelivery.Persistence.Contracts
{
    public interface IAudit
    {
        DateTime CreatedDateUtc { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDateUtc { get; set; }
        string? UpdatedBy { get; set; }
    }
}