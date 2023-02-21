using PackageDelivery.Persistence.DTOs.Common;

namespace PackageDelivery.Persistence.DTOs
{
    public class ApiLogDto : BaseDomainDto
    {
        public string? Scheme { get; set; }

        public string? Host { get; set; }

        public string? Path { get; set; }

        public string? QueryString { get; set; }

        public string? RequestBody { get; set; }

        public string? ResponseBody { get; set; }
    }
}