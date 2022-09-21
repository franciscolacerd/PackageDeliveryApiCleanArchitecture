using PackageDelivery.Domain.Common;

namespace PackageDelivery.Domain.Entities
{
    public class ApiLog : BaseDomainEntity
    {
        public string? Scheme { get; set; }

        public string? Host { get; set; }

        public string? Path { get; set; }

        public string? QueryString { get; set; }

        public string? RequestBody { get; set; }

        public string? ResponseBody { get; set; }
    }
}