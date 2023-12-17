using PackageDelivery.Domain.Extensions;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Application.Tests.Common
{
    public class BaseTest
    {
        protected Delivery Build()
        {
            return new DeliveryBuilder()
                          .WithBarcode(15.ToRandomStringOfInts())
                          .WithWeight(2.ToRandomDecimal())
                          .WithOneDelivery()
                          .WithTwoPackages()
                          .WithPod()
                          .WithCashOnDelivery()
                          .Build();
        }
    }
}