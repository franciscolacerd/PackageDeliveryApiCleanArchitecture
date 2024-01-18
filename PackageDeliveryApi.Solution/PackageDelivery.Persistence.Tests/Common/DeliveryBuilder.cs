using Bogus;
using PackageDelivery.Domain.SmartEnums;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Tests.Common
{
    public class DeliveryBuilder
    {
        private Delivery _delivery;
        private string _barcode;
        private decimal _totalWeight;

        public DeliveryBuilder()
        {
            this._delivery = new Delivery();
        }

        public DeliveryBuilder WithBarcode(string barcode)
        {
            this._barcode = barcode;
            return this;
        }

        public DeliveryBuilder WithWeight(decimal totalWeight)
        {
            this._totalWeight = totalWeight;
            return this;
        }

        public DeliveryBuilder WithOneDelivery()
        {
            _delivery = new Faker<Delivery>()
                .RuleFor(d => d.Amount, f => f.Random.Decimal())
                .RuleFor(d => d.ClientReference, f => f.Company.CompanyName())
                .RuleFor(d => d.Eta, f => f.Date.FutureOffset().ToString("yyyy-MM-ddTHH:mm:ss"))
                .RuleFor(d => d.Instructions, f => f.Lorem.Sentence())
                .RuleFor(d => d.NumberOfVolumes, f => f.Random.Number(1, 5))
                .RuleFor(d => d.PreferentialPeriod, f => f.Random.Bool() ? f.PickRandom(new[] { "Morning", "Afternoon", "Evening" }) : null)
                .RuleFor(d => d.ReceiverAddress, f => f.Address.StreetAddress())
                .RuleFor(d => d.ReceiverAddressCountryCode, f => f.Address.CountryCode())
                .RuleFor(d => d.ReceiverAddressPlace, f => f.Address.City())
                .RuleFor(d => d.ReceiverAddressZipCode, f => f.Address.ZipCode())
                .RuleFor(d => d.ReceiverAddressZipCodePlace, f => f.Address.City())
                .RuleFor(d => d.ReceiverClientCode, f => f.Random.AlphaNumeric(8))
                .RuleFor(d => d.ReceiverContactEmail, f => f.Person.Email)
                .RuleFor(d => d.ReceiverContactName, f => f.Person.FullName)
                .RuleFor(d => d.ReceiverContactPhoneNumber, f => f.Person.Phone)
                .RuleFor(d => d.ReceiverFixedInstructions, f => f.Lorem.Sentence())
                .RuleFor(d => d.ReceiverName, f => f.Person.FullName)
                .RuleFor(d => d.SenderAddress, f => f.Address.StreetAddress())
                .RuleFor(d => d.SenderAddressCountryCode, f => f.Address.CountryCode())
                .RuleFor(d => d.SenderAddressPlace, f => f.Address.City())
                .RuleFor(d => d.SenderAddressZipCode, f => f.Address.ZipCode())
                .RuleFor(d => d.SenderAddressZipCodePlace, f => f.Address.City())
                .RuleFor(d => d.SenderClientCode, f => f.Random.AlphaNumeric(8))
                .RuleFor(d => d.SenderContactEmail, f => f.Person.Email)
                .RuleFor(d => d.SenderContactName, f => f.Person.FullName)
                .RuleFor(d => d.SenderContactPhoneNumber, f => f.Person.Phone)
                .RuleFor(d => d.SenderName, f => f.Person.FullName)
                .RuleFor(d => d.BarCode, f => _barcode)
                .RuleFor(d => d.TotalWeightOfVolumes, f => _totalWeight)
                .RuleFor(d => d.UserId, f => 2)
                .Generate();

            return this;
        }

        public DeliveryBuilder WithTwoPackages()
        {
            _delivery.Packages = new Faker<Package>()
                .RuleFor(p => p.Height, f => 2)
                .RuleFor(p => p.Length, f => 2)
                .RuleFor(p => p.PackageBarCode, f => $"{_barcode}{f.Random.Number(1, 999):D3}")
                .RuleFor(p => p.PackageNumber, f => f.UniqueIndex + 1)
                .RuleFor(p => p.Weight, f => _totalWeight / 2)
                .RuleFor(p => p.Width, f => 2)
                .Generate(2);

            return this;
        }

        public DeliveryBuilder WithPod()
        {
            if (_delivery.DeliveryDeliveryAttributes is null)
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
            if (_delivery.DeliveryDeliveryAttributes is null)
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
            if (_delivery.DeliveryDeliveryAttributes is null)
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