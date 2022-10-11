using MediatR;
using PackageDelivery.Application.Responses.Common;

namespace PackageDelivery.Application.Features.Delivery.Requests.Commands
{
    public class CreateDeliveryCommand : IRequest<BaseCommandResponse>
    {
        public CreateDeliveryCommand(Domain.Aggregates.DeliveryAggregate.Delivery delivery)
        {
            Delivery = delivery;
        }

        public Domain.Aggregates.DeliveryAggregate.Delivery Delivery { get; }
    }
}