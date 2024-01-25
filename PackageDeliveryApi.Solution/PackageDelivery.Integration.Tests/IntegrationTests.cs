using FluentAssertions;
using Flurl.Http;
using PackageDelivery.Application.Responses;
using PackageDelivery.Integration.Tests.Common;

namespace PackageDelivery.Integration.Tests
{
    public class IntegrationTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private const string BaseUrl = "https://localhost:7093/api";

        [Test]
        public async Task Should_GetToken_ReturnBeSuccessful()
        {
            var token = await GetTokenAsync(BaseUrl);

            token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task Should_GetserDeliveries_ReturnBeSuccessful()
        {
            var token = await GetTokenAsync(BaseUrl);

            var result = await $"{BaseUrl}/Delivery?page=1&pageSize=10"
                .WithOAuthBearerToken(token)
                .GetAsync()
                .ReceiveJson<UserDeliveriesResponse>();

            result.Should().NotBeNull();

            result.Success.Should().BeTrue();
        }

        [Test]
        public async Task Should_CreateService_ReturnBeSuccessful()
        {
            var delivery = this.Build();

            var token = await GetTokenAsync(BaseUrl);

            var result = await $"{BaseUrl}/Delivery"
                .WithOAuthBearerToken(token)
                .SendJsonAsync(HttpMethod.Post, delivery)
                .ReceiveJson<CreateDeliveryResponse>();

            result.Should().NotBeNull();

            result.Success.Should().BeTrue();
        }
    }
}