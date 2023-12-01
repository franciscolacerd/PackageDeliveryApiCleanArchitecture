using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Tests.Strapper;
using PackageDelivery.Application.Validation.Delivery;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Tests.Validation.Delivery
{
    [TestFixture]
    public class DeliveryValidatorTests
    {
        private ServiceProvider _serviceProvider;

        private DeliveryValidator _validator;

        [SetUp]
        public void Setup()
        {
            this._serviceProvider = Bootstrapper.Bind();

            this._validator = this._serviceProvider.GetRequiredService<DeliveryValidator>();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _serviceProvider.DisposeAsync();
        }

        [Test]
        public async Task Should_ValidateDelivery_ReturnTrue()
        {
            // Arrange
            var shipment = new DeliveryModel
            {
                Details = new DetailsModel
                {
                    ClientReference = "ABC123",
                    NumberOfVolumes = 2,
                    TotalWeightOfVolumes = 12.5m,
                    Amount = 100.00m,
                    Instructions = "Handle with care",
                    PreferentialPeriod = "Morning"
                },
                Sender = new SenderModel
                {
                    Name = "John Smith",
                    Contact = new ContactModel
                    {
                        Name = "John Smith",
                        PhoneNumber = "555-555-5555",
                        Email = "john.smith@example.com"
                    },
                    Address = new AddressModel
                    {
                        AddressLine = "123 Main St",
                        Place = "Anytown",
                        ZipCode = "2795-084",
                        ZipCodePlace = "Anytown",
                        CountryCode = "PT"
                    }
                },
                Receiver = new ReceiverModel
                {
                    Name = "Jane Doe",
                    Contact = new ContactModel
                    {
                        Name = "Jane Doe",
                        PhoneNumber = "555-555-5556",
                        Email = "jane.doe@example.com"
                    },
                    Address = new AddressModel
                    {
                        AddressLine = "456 Oak St",
                        Place = "Othertown",
                        ZipCode = "4000-231",
                        ZipCodePlace = "Othertown",
                        CountryCode = "PT"
                    }
                },
                Attributes = new AttributesModel
                {
                    Pod = true,
                    SameDay = false,
                    CashOnDelivery = true
                }
            };

            // Act
            var validationResult = await this._validator.ValidateAsync(shipment);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }
    }
}