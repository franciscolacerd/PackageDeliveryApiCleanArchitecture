using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Domain.DomainModels.Delivery;

public class DeliveryDomainModel : IDeliveryDomainModel
{
    public void AddAttributes(Persistence.Entities.Delivery delivery, AttributesModel attributes)
    {
        throw new NotImplementedException();
    }

    public Task AddBarcodeAsync(Persistence.Entities.Delivery delivery)
    {
        throw new NotImplementedException();
    }

    public void AddDetails(Persistence.Entities.Delivery delivery, DetailsModel details)
    {
        throw new NotImplementedException();
    }

    public void AddReceiver(Persistence.Entities.Delivery delivery, ReceiverModel receiver)
    {
        throw new NotImplementedException();
    }

    public void AddSender(Persistence.Entities.Delivery delivery, SenderModel sender)
    {
        throw new NotImplementedException();
    }
}