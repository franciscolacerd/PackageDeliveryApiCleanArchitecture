using PackageDelivery.Persistence.Contracts;

namespace PackageDelivery.Persistence.Entities
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser<int>, IAudit
    {
        public DateTime CreatedDateUtc { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedDateUtc { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; } = null!;
    }
}