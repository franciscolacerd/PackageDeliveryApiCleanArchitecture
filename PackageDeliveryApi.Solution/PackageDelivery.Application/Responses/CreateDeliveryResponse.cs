using PackageDelivery.Application.Responses.Common;

namespace PackageDelivery.Application.Responses
{
    public class CreateDeliveryResponse : BaseCommandResponse
    {
        public string? BarCode { get; set; }
    }
}