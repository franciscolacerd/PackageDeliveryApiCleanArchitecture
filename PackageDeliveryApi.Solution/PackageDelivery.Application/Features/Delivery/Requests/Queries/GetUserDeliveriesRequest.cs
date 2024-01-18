using MediatR;
using PackageDelivery.Application.Responses;

namespace PackageDelivery.Application.Features.Delivery.Requests.Queries
{
    public class GetUserDeliveriesRequest : IRequest<UserDeliveriesResponse>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public GetUserDeliveriesRequest(int page, int pageSize)
        {
            this.Page = page;

            this.PageSize = pageSize;
        }
    }
}