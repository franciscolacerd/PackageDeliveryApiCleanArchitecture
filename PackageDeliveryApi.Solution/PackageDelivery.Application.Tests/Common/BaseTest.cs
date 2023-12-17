using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Application.Tests.Common
{
    public class BaseTest
    {
        protected DeliveryModel Build()
        {
            return new DeliveryBuilder()
                          .WithDetail()
                          .WithSender()
                          .WithReceiver()
                          .WithAttributes()
                          .Build();
        }
    }
}