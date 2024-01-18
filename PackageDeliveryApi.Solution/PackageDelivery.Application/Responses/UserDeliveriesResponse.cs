using PackageDelivery.Application.Responses.Common;
using PackageDelivery.Domain.DTOs;
using PackageDelivery.Domain.Models.Pagination;

namespace PackageDelivery.Application.Responses;

public class UserDeliveriesResponse : BaseCommandResponse
{
    public PagedResult<DeliveryDto> Deliveries { get; set; }
}