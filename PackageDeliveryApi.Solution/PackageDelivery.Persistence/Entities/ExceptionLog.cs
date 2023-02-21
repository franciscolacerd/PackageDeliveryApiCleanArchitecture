using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence.Entities
{
    public class ExceptionLog : BaseDomainEntity
    {
        public string Exception { get; set; } = null!;
    }
}