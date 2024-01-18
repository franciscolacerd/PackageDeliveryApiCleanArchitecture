using MediatR;
using Microsoft.AspNetCore.Http;
using PackageDelivery.Application.Features.Delivery.Requests.Queries;
using PackageDelivery.Application.Responses;
using PackageDelivery.Domain.Common;
using PackageDelivery.Domain.Constants;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.Exceptions;

namespace PackageDelivery.Application.Features.Delivery.Handlers.Queries
{
    public class GetUserDeliveriesHandler : BaseIdentityProvider, IRequestHandler<GetUserDeliveriesRequest, UserDeliveriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserDeliveriesHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserDeliveriesResponse> Handle(GetUserDeliveriesRequest request, CancellationToken cancellationToken)
        {
            var result = await this._unitOfWork.DeliveryRepository.QueryAsync(request.Page, request.PageSize, x => x.UserId == this.UserId);

            if (result is null)
                throw new WithoutDeliveriesExceptions(string.Format(ExceptionMessages.WithoutDeliveriesExceptions, this.UserId));

            return new UserDeliveriesResponse
            {
                Success = true,
                Deliveries = result
            };
        }
    }
}