using MediatR;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Validation.Delivery;
using PackageDelivery.Domain.Builders;
using PackageDelivery.Domain.Exceptions;
using PackageDelivery.Persistence.Contracts.Persistence;

namespace PackageDelivery.Application.Features.Delivery.Handlers.Commands;

public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse>
{
    private readonly IDeliveryBuilder _deliveryBuilder;

    private readonly DeliveryValidator _deliveryValidator;

    private readonly IDeliveryRepository _deliveryRepository;

    public CreateDeliveryCommandHandler(
        IDeliveryBuilder deliveryBuilder,
        DeliveryValidator deliveryValidator,
        IDeliveryRepository deliveryRepository)
    {
        this._deliveryBuilder = deliveryBuilder;

        this._deliveryValidator = deliveryValidator;

        this._deliveryRepository = deliveryRepository;
    }

    public async Task<CreateDeliveryResponse> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
    {
        if (request == null || request.Delivery == null)
        {
            throw new NullCreateDeliverytRequestException($"CreateDelivery request is null.");
        }

        var delivery = request.Delivery;

        var validationResult = await this._deliveryValidator.ValidateAsync(delivery);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            return new CreateDeliveryResponse { Errors = errors, Success = false, Message = "Delivery created with errors." };
        }

        var entity = this._deliveryBuilder
                          .WithUser(request.Username)
                          .WithDetails(delivery.Details)
                          .WithSender(delivery.Sender)
                          .WithReceiver(delivery.Receiver)
                          .WithAttributes(delivery.Attributes)
                          .Build();

        var result = await this._deliveryRepository.AddAsync(entity);

        return new CreateDeliveryResponse { BarCode = result.BarCode, Success = result.Id > 0, Message = "Delivery created with success." };
    }
}