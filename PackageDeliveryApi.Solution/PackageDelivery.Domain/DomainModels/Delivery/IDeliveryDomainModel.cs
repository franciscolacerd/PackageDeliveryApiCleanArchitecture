using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Domain.DomainModels.Delivery;

public interface IDeliveryDomainModel
{
    void AddUser(string user);

    void AddAttributes(Persistence.Entities.Delivery delivery, AttributesModel attributes);

    void AddBarcode(Persistence.Entities.Delivery delivery);

    void AddDetails(Persistence.Entities.Delivery delivery, DetailsModel details);

    void AddReceiver(Persistence.Entities.Delivery delivery, ReceiverModel receiver);

    void AddSender(Persistence.Entities.Delivery delivery, SenderModel sender);

    void AddVolumes(Persistence.Entities.Delivery delivery);

    void AddCreatedInSystemEvent(Persistence.Entities.Delivery delivery);
}