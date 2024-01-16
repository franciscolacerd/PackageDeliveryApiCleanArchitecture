using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Constants.Structs;
using PackageDelivery.Domain.Models.Delivery;
using System.Security.Claims;

namespace PackageDelivery.Application.Tests.Common
{
    public class BaseTest
    {
        public BaseTest()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "TestUser"),
                new Claim(ClaimTypes.Email, "test@example.com"),
                new Claim(CustomClaims.UserId, "2")
            }));

            var httpContextAccessor = new HttpContextAccessor
            {
                HttpContext = httpContext
            };

            new ServiceCollection()
                .AddSingleton<IHttpContextAccessor>(httpContextAccessor)
                .BuildServiceProvider();
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
    }
}