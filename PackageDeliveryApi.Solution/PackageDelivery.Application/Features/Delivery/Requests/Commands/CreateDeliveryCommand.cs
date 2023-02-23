using MediatR;
using PackageDelivery.Application.Responses;
using PackageDelivery.Domain.Models.Delivery;
using System.Text.Json.Serialization;

namespace PackageDelivery.Application.Features.Delivery.Requests.Commands;

public class CreateDeliveryCommand : IRequest<CreateDeliveryResponse>
{
    public CreateDeliveryCommand(DeliveryModel delivery)
    {
        Delivery = delivery;
    }

    public DeliveryModel Delivery { get; set; }

    [JsonIgnore]
    public string? Username { get; set; }
}