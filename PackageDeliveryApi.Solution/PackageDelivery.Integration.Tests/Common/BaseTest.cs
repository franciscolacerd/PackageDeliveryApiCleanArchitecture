using FluentAssertions;
using Flurl.Http;
using PackageDelivery.Domain.Models.Delivery;

namespace PackageDelivery.Integration.Tests.Common
{
    public class BaseTest
    {
        public BaseTest()
        {
        }

        protected DeliveryModel Build()
        {
            return new DeliveryBuilder()
                          .WithDetail()
                          .WithSender()
                          .WithReceiver()
                          .WithAttributes()
                          .Build();
        }

        protected static async Task<string> GetTokenAsync(string baseUrl)
        {
            var token = await $"{baseUrl}/token"
                 .WithHeader("content-type", "application/x-www-form-urlencoded")
                 .PostUrlEncodedAsync(new
                 {
                     username = "test@test.com",
                     password = "P@ssw0rd123_",
                     grant_type = "password"
                 }).ReceiveJson<Token>();

            token.Should().NotBeNull();

            token.access_token.Should().NotBeNull();

            return token.access_token;
        }
    }
}