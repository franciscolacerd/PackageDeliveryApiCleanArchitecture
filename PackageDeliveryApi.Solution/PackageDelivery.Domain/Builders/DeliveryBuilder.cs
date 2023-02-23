using PackageDelivery.Domain.DomainModels.Delivery;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Domain.Builders;

public class DeliveryBuilder : IDeliveryBuilder
{
    private Delivery _delivery;
    private IDeliveryDomainModel _deliveryDomainModel;

    public DeliveryBuilder(IDeliveryDomainModel deliveryDomainModel)
    {
        this._delivery = new Delivery();
        this._deliveryDomainModel = deliveryDomainModel;
    }

    public DeliveryBuilder WithDetails(DetailsModel details)
    {
        this._deliveryDomainModel.AddDetails(this._delivery, details);
        return this;
    }

    public DeliveryBuilder WithSender(SenderModel sender)
    {
        this._deliveryDomainModel.AddSender(this._delivery, sender);
        return this;
    }

    public DeliveryBuilder WithReceiver(ReceiverModel receiver)
    {
        this._deliveryDomainModel.AddReceiver(this._delivery, receiver);
        return this;
    }

    public DeliveryBuilder WithAttributes(AttributesModel attributes)
    {
        this._deliveryDomainModel.AddAttributes(this._delivery, attributes);
        return this;
    }

    public Delivery Build()
    {
        this._deliveryDomainModel.AddBarcode(this._delivery);
        this._deliveryDomainModel.AddVolumes(this._delivery);
        this._deliveryDomainModel.AddCreatedInSystemEvent(this._delivery);

        return this._delivery;
    }
}