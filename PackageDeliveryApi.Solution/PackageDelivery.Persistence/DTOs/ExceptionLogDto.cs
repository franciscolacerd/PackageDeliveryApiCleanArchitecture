using PackageDelivery.Persistence.DTOs.Common;

namespace PackageDelivery.Persistence.DTOs
{
    public class ExceptionLogDto : BaseDomainDto
    {
        public string Exception { get; set; } = null!;
    }
}