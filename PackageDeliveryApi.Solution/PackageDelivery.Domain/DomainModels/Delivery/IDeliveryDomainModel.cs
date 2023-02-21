using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Domain.DomainModels.Delivery;

public interface IDeliveryDomainModel
{
    void AddAttributes(Persistence.Entities.Delivery delivery, AttributesModel attributes);

    Task AddBarcodeAsync(Persistence.Entities.Delivery delivery);

    void AddDetails(Persistence.Entities.Delivery delivery, DetailsModel details);

    void AddReceiver(Persistence.Entities.Delivery delivery, ReceiverModel receiver);

    void AddSender(Persistence.Entities.Delivery delivery, SenderModel sender);
}