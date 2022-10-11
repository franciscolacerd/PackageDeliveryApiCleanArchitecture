using MediatR;
using PackageDelivery.Application.Responses;

namespace PackageDelivery.Application.Features.Delivery.Requests.Queries
{
    public class GetUserDeliveriesRequest : IRequest<UserDeliveriesResponse>
    {
        public GetUserDeliveriesRequest(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}