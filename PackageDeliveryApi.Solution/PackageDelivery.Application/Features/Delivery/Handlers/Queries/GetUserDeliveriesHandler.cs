using MediatR;
using PackageDelivery.Application.Features.Delivery.Requests.Queries;
using PackageDelivery.Application.Responses;

namespace PackageDelivery.Application.Features.Delivery.Handlers.Queries
{
    public class GetUserDeliveriesHandler : IRequestHandler<GetUserDeliveriesRequest, UserDeliveriesResponse>
    {
        public Task<UserDeliveriesResponse> Handle(GetUserDeliveriesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}