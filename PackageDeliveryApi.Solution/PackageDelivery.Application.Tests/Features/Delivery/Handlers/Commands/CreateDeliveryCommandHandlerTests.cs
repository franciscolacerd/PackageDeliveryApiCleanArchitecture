using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Tests.Strapper;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Tests.Features.Delivery.Handlers.Commands;

[TestFixture]
public class CreateDeliveryCommandHandlerTests
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
        CreateDeliveryCommand request = new CreateDeliveryCommand(new DeliveryModel
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
        });

        CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

        // Act
        var result = await this._handler.Handle(
            request,
            cancellationToken);

        // Assert
        Assert.Fail();
    }
}