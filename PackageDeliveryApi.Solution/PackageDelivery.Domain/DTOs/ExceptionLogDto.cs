using PackageDelivery.Domain.DTOs.Common;

namespace PackageDelivery.Domain.DTOs
{
    public class ExceptionLogDto : BaseLogDto
    {
        public string Exception { get; set; } = null!;
    }
}