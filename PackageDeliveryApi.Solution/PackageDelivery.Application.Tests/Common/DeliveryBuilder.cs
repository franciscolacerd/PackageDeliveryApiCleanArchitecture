using Bogus;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Tests.Common
{
    public class DeliveryBuilder
    {
        private DeliveryModel _deliveryModel;

        private Faker _faker;

        public DeliveryBuilder()
        {
            this._deliveryModel = new DeliveryModel();
            this._faker = new Faker();
        }

        public DeliveryBuilder WithDetail()
        {
            this._deliveryModel.Details = new DetailsModel
            {
                ClientReference = this._faker.Random.AlphaNumeric(6),
                NumberOfVolumes = this._faker.Random.Number(1, 5),
                TotalWeightOfVolumes = this._faker.Random.Decimal(1, 50),
                Amount = this._faker.Random.Decimal(50, 200),
                Instructions = this._faker.Lorem.Sentence(),
                PreferentialPeriod = this._faker.PickRandom(new[] { "Morning", "Afternoon", "Evening" })
            };

            return this;
        }

        public DeliveryBuilder WithSender()
        {
            this._deliveryModel.Sender = new SenderModel
            {
                Name = this._faker.Person.FullName,
                Contact = new ContactModel
                {
                    Name = this._faker.Person.FullName,
                    PhoneNumber = this._faker.Person.Phone,
                    Email = this._faker.Person.Email
                },
                Address = new AddressModel
                {
                    AddressLine = this._faker.Address.StreetAddress(),
                    Place = this._faker.Address.City(),
                    ZipCode = this._faker.Address.ZipCode(),
                    ZipCodePlace = this._faker.Address.City(),
                    CountryCode = this._faker.Address.CountryCode()
                }
            };

            return this;
        }

        public DeliveryBuilder WithReceiver()
        {
            this._deliveryModel.Receiver = new ReceiverModel
            {
                Name = this._faker.Person.FullName,
                Contact = new ContactModel
                {
                    Name = this._faker.Person.FullName,
                    PhoneNumber = this._faker.Person.Phone,
                    Email = this._faker.Person.Email
                },
                Address = new AddressModel
                {
                    AddressLine = this._faker.Address.StreetAddress(),
                    Place = this._faker.Address.City(),
                    ZipCode = this._faker.Address.ZipCode(),
                    ZipCodePlace = this._faker.Address.City(),
                    CountryCode = this._faker.Address.CountryCode()
                }
            };

            return this;
        }

        public DeliveryBuilder WithAttributes()
        {
            this._deliveryModel.Attributes =  new AttributesModel
            {
                Pod = this._faker.Random.Bool(),
                SameDay = this._faker.Random.Bool(),
                CashOnDelivery = this._faker.Random.Bool()
            };

            return this;
        }

        public DeliveryModel Build()
        {
            return _deliveryModel;
        }
    }
}