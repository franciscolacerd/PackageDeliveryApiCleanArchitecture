using PackageDelivery.Persistence.DTOs.Common;

namespace PackageDelivery.Persistence.DTOs
{
    public partial class PackageDto : BaseDomainDto
    {
        public int DeliveryId { get; set; }
        public string PackageBarCode { get; set; } = null!;
        public int PackageNumber { get; set; }
        public decimal Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public virtual DeliveryDto Delivery { get; set; } = null!;
    }
}