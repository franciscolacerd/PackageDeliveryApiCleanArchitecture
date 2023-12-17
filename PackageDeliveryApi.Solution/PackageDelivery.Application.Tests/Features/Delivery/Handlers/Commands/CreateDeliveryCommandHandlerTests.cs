using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Tests.Common;
using PackageDelivery.Application.Tests.Strapper;

namespace PackageDelivery.Application.Tests.Features.Delivery.Handlers.Commands;

[TestFixture]
public class CreateDeliveryCommandHandlerTests : BaseTest
{
    private ServiceProvider _serviceProvider;

    private IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse> _handler;

    public CreateDeliveryCommandHandlerTests()
    {
        this._serviceProvider = Bootstrapper.Bind();

        this._handler = this._serviceProvider.GetRequiredService<IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse>>();
    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        await _serviceProvider.DisposeAsync();
    }

    [Test]
    public async Task Handle_StateUnderTest_ExpectedBehavior()
    {
        // Arrange

        var request = new CreateDeliveryCommand(Build());

        var cancellationToken = default(CancellationToken);

        // Act
        var result = await this._handler.Handle(request, cancellationToken);

        // Assert
        result.Success.Should().BeTrue();
    }
}