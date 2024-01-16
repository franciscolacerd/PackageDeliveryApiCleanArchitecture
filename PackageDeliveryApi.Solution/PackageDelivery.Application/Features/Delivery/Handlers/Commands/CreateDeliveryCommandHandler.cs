using MediatR;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using PackageDelivery.Application.Validation.Delivery;
using PackageDelivery.Domain.Builders;
using PackageDelivery.Domain.Constants;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.Exceptions;

namespace PackageDelivery.Application.Features.Delivery.Handlers.Commands;

public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, CreateDeliveryResponse>
{
    private readonly IDeliveryBuilder _deliveryBuilder;

    private readonly DeliveryValidator _deliveryValidator;

    private readonly IUnitOfWork _unitOfWork;

    public CreateDeliveryCommandHandler(
        IDeliveryBuilder deliveryBuilder,
        DeliveryValidator deliveryValidator,
        IUnitOfWork unitOfWork)
    {
        this._deliveryBuilder = deliveryBuilder;

        this._deliveryValidator = deliveryValidator;

        this._unitOfWork = unitOfWork;
    }

    public async Task<CreateDeliveryResponse> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Delivery is null)
        {
            throw new NullCreateDeliverytRequestException(ApiResponses.CreateDeliveryRequestIsNull);
        }

        var delivery = request.Delivery;

        var validationResult = await this._deliveryValidator.ValidateAsync(delivery);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            return new CreateDeliveryResponse
            {
                Errors = errors,
                Success = false,
                Message = ApiResponses.DeliveryCreatedWithErrors
            };
        }

        var entity = this._deliveryBuilder
                          .WithDetails(delivery.Details)
                          .WithSender(delivery.Sender)
                          .WithReceiver(delivery.Receiver)
                          .WithAttributes(delivery.Attributes)
                          .Build();

        var result = await this._unitOfWork.DeliveryRepository.AddAsync(entity);

        await this._unitOfWork.SaveChangesAsync();

        return new CreateDeliveryResponse
        {
            BarCode = result.BarCode,
            Success = result.Id > 0,
            Message = ApiResponses.DeliveryCreatedWithSuccess
        };
    }
}