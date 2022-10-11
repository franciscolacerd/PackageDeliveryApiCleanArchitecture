using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses.Common;
using PackageDelivery.Application.Tests.Strapper;
using PackageDelivery.Domain.Aggregates.DeliveryAggregate;

namespace PackageDelivery.Application.Tests.Commands
{
    public class CreateDeliveryCommandHandlerTests
    {
        private ServiceProvider _serviceProvider;

        private IRequestHandler<CreateDeliveryCommand, BaseCommandResponse> _handler;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _handler = _serviceProvider.GetRequiredService<IRequestHandler<CreateDeliveryCommand, BaseCommandResponse>>();
        }

        [Test]
        public async Task Should_CreateDelivery_ReturnSuccessTrue()
        {
            //arranje
            var delivery = new Delivery();

            //act
            var result = await _handler.Handle(new CreateDeliveryCommand(delivery), CancellationToken.None);

            //assert

            result.Should().NotBeNull();

            result.Should().BeOfType<BaseCommandResponse>();

            result.Success.Should().BeTrue();
        }
    }
}