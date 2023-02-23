using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Builders;

public interface IDeliveryBuilder
{
    DeliveryBuilder WithDetails(DetailsModel details);

    DeliveryBuilder WithSender(SenderModel sender);

    DeliveryBuilder WithReceiver(ReceiverModel receiver);

    DeliveryBuilder WithAttributes(AttributesModel attributes);

    Delivery Build();
}