using PackageDelivery.Domain.Common;

namespace PackageDelivery.Domain.Entities
{
    public class ExceptionLog : BaseDomainEntity
    {
        public string Exception { get; set; } = null!;
    }
}