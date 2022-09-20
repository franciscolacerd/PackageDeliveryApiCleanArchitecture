namespace PackageDelivery.Domain.DTOs.Common
{
    public abstract class BaseDomainDto
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDateUtc { get; set; }
        public string? UpdatedBy { get; set; }
    }
}