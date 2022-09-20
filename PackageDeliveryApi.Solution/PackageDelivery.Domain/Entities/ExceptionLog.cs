using PackageDelivery.Domain.Common;

namespace PackageDelivery.Domain.Entities
{
    public class ExceptionLog : BaseLog
    {
        public string Exception { get; set; } = null!;
    }
}