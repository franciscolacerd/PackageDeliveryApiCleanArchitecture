using MediatR;
using PackageDelivery.Application.Responses;

namespace PackageDelivery.Application.Features.Delivery.Requests.Queries
{
    public class GetUserDeliveriesRequest : IRequest<UserDeliveriesResponse>
    {
        //TODO: implement pagination
        public GetUserDeliveriesRequest()
        {
        }
    }
}