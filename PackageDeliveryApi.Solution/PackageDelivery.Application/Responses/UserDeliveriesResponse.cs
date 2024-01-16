using PackageDelivery.Application.Responses.Common;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Application.Responses;

public class UserDeliveriesResponse : BaseCommandResponse
{
    public IReadOnlyList<Delivery> Deliveries { get; set; }
}