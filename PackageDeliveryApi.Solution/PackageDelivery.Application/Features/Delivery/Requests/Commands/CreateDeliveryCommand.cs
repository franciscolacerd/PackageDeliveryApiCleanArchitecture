using MediatR;
using PackageDelivery.Application.Responses.Common;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Features.Delivery.Requests.Commands
{
    public class CreateDeliveryCommand : IRequest<BaseCommandResponse>
    {
        public CreateDeliveryCommand(DeliveryModel delivery)
        {
            Delivery = delivery;
        }

        public DeliveryModel Delivery { get; }
    }
}