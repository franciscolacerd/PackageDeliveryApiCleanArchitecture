using PackageDelivery.Persistence.Contracts.Persistence;

namespace PackageDelivery.Persistence.Common
{
    public abstract class BaseDomainEntity : IAudit, IIdentity
    {
        public int Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDateUtc { get; set; }
        public string? UpdatedBy { get; set; }
    }
}