using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public partial class Package : BaseDomainEntity
    {
        public int DeliveryId { get; set; }
        public string PackageBarCode { get; set; } = null!;
        public int PackageNumber { get; set; }
        public decimal Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public virtual Delivery Delivery { get; set; } = null!;
        public virtual ICollection<Event>? Events { get; set; }
    }
}