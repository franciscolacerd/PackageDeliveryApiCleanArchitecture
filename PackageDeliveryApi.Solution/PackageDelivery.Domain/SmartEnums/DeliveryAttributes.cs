using PackageDelivery.Domain.Common;

namespace PackageDelivery.Domain.SmartEnums
{
    public class DeliveryAttributes : Enumeration
    {
        public static DeliveryAttributes Pod = new(1, nameof(Pod));
        public static DeliveryAttributes SameDay = new(2, nameof(SameDay));
        public static DeliveryAttributes CashOnDelivery = new(3, nameof(CashOnDelivery));

        public DeliveryAttributes(int id, string name)
            : base(id, name)
        {
        }
    }
}