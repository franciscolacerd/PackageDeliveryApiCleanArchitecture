using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Requests.Queries;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Tests.Strapper;

namespace PackageDelivery.Application.Tests.Queries
{
    public class GetUserDeliveriesHandlerTests
    {
        private ServiceProvider _serviceProvider;

        private IRequestHandler<GetUserDeliveriesRequest, UserDeliveriesResponse> _handler;

        [SetUp]
        public void Setup()
        {
            _serviceProvider = Bootstrapper.Bind();

            _handler = _serviceProvider.GetRequiredService<IRequestHandler<GetUserDeliveriesRequest, UserDeliveriesResponse>>();
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
            var request = new GetUserDeliveriesRequest(1);

            //act
            var result = await _handler.Handle(request, CancellationToken.None);

            //assert

            result.Should().NotBeNull();

            result.Should().BeOfType<UserDeliveriesResponse>();

            result.Success.Should().BeTrue();
        }
    }
}