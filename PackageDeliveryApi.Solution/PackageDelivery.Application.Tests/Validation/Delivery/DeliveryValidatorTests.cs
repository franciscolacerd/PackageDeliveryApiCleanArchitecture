using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Tests.Common;
using PackageDelivery.Application.Tests.Strapper;
using PackageDelivery.Application.Validation.Delivery;

namespace PackageDelivery.Application.Tests.Validation.Delivery
{
    [TestFixture]
    public class DeliveryValidatorTests : BaseTest
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
            var shipment = Build();

            // Act
            var validationResult = await this._validator.ValidateAsync(shipment);

            // Assert
            validationResult.IsValid.Should().BeTrue();
        }
    }
}