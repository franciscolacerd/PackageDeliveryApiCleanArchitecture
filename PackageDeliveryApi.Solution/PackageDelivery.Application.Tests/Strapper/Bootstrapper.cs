using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain;
using PackageDelivery.Domain.Constants.Structs;
using PackageDelivery.Persistence;
using System.Security.Claims;

namespace PackageDelivery.Application.Tests.Strapper
{
    public static class Bootstrapper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static ServiceProvider Bind()
        {
            var services = new ServiceCollection();

            var httpContext = new DefaultHttpContext();
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, "TestUser"),
                new Claim(ClaimTypes.Email, "test@example.com"),
                new Claim(CustomClaims.UserId, "2")
            };

            var identity = new ClaimsIdentity(claims, "custom_authentication_type");

            httpContext.User = new ClaimsPrincipal(identity);

            var httpContextAccessor = new HttpContextAccessor
            {
                HttpContext = httpContext
            };

            services.AddOptions();

            services.AddLogging();

            var configurationRoot = GetIConfigurationRoot(TestContext.CurrentContext.TestDirectory);

            services.ConfigurePersistenceServices(configurationRoot);

            services.ConfigureDomainServices();

            services.ConfigureApplicationServices();

            services.AddSingleton<IConfiguration>(configurationRoot);

            services.AddSingleton<IHttpContextAccessor>(httpContextAccessor);

            return services.BuildServiceProvider();
        }
    }
}