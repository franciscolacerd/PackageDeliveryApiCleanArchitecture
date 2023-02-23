using PackageDelivery.Domain.DTOs.Common;

namespace PackageDelivery.Domain.DTOs
{
    public class ExceptionLogDto : BaseDomainDto
    {
        public string Exception { get; set; } = null!;
    }
}