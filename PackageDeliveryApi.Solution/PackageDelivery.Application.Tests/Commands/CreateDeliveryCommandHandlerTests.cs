using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Tests.Common;
using PackageDelivery.Application.Tests.Strapper;

namespace PackageDelivery.Application.Tests.Commands
{
    public class CreateDeliveryCommandHandlerTests : BaseTest
    {
        private ServiceProvider _serviceProvider;

        private IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse> _handler;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _handler = _serviceProvider.GetRequiredService<IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse>>();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _serviceProvider.DisposeAsync();
        }

        [Test]
        public async Task Should_CreateDelivery_ReturnSuccessTrue()
        {
            //arranje
            var delivery = Build();

            //act
            var result = await _handler.Handle(new CreateDeliveryCommand(delivery), CancellationToken.None);

            //assert

            result.Should().NotBeNull();

            result.Should().BeOfType<CreateDeliveryResponse>();

            result.Success.Should().BeTrue();
        }
    }
}