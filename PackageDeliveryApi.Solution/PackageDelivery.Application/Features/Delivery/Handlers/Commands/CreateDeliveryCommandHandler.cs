using MediatR;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses.Common;

namespace PackageDelivery.Application.Features.Delivery.Handlers.Commands
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, BaseCommandResponse>
    {
        public Task<BaseCommandResponse> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}