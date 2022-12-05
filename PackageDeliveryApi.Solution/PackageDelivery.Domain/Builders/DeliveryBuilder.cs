using PackageDelivery.Domain.Entities;
using PackageDelivery.Domain.Models.Delivery;
using PackageDelivery.Domain.SmartEnums;

namespace PackageDelivery.Domain.Builders
{
    public class DeliveryBuilder
    {
        private Delivery _delivery;
        private string _barcode;

        public DeliveryBuilder() => this._delivery = new Delivery();

        public DeliveryBuilder WithBarcode(string barcode)
        {
            this._barcode = barcode;
            return this;
        }

        public DeliveryBuilder WithDelivery(DeliveryModel delivery)
        {
            return this;
        }

        public DeliveryBuilder WithPod()
        {
            if (_delivery.DeliveryDeliveryAttributes == null)
            {
                _delivery.DeliveryDeliveryAttributes = new List<DeliveryDeliveryAttribute>();
            }

            _delivery.DeliveryDeliveryAttributes.Add(new DeliveryDeliveryAttribute
            {
                DeliveryAttributeId = DeliveryAttributes.Pod.Id
            });
            return this;
        }

        public DeliveryBuilder WithSameDay()
        {
            if (_delivery.DeliveryDeliveryAttributes == null)
            {
                _delivery.DeliveryDeliveryAttributes = new List<DeliveryDeliveryAttribute>();
            }

            _delivery.DeliveryDeliveryAttributes.Add(new DeliveryDeliveryAttribute
            {
                DeliveryAttributeId = DeliveryAttributes.SameDay.Id
            });
            return this;
        }

        public DeliveryBuilder WithCashOnDelivery()
        {
            if (_delivery.DeliveryDeliveryAttributes == null)
            {
                _delivery.DeliveryDeliveryAttributes = new List<DeliveryDeliveryAttribute>();
            }

            _delivery.DeliveryDeliveryAttributes.Add(new DeliveryDeliveryAttribute
            {
                DeliveryAttributeId = DeliveryAttributes.CashOnDelivery.Id
            });
            return this;
        }

        public Delivery Build()
        {
            return _delivery;
        }
    }
}