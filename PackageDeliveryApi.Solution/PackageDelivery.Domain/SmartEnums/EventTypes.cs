using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Domain.SmartEnums
{
    public class EventTypes : Enumeration
    {
        public static EventTypes CreatedDelivery = new(1, nameof(CreatedDelivery));
        public static EventTypes PickedupByCarrier = new(2, nameof(PickedupByCarrier));
        public static EventTypes InTransit = new(3, nameof(InTransit));
        public static EventTypes DeliveredToReceiver = new(4, nameof(DeliveredToReceiver));
        public static EventTypes UnableToMakePickup = new(5, nameof(UnableToMakePickup));
        public static EventTypes UnableToMakeDelivery = new(6, nameof(UnableToMakeDelivery));
        public static EventTypes ReturnedToSender = new(7, nameof(ReturnedToSender));

        public EventTypes(int id, string name)
            : base(id, name)
        {
        }
    }
}