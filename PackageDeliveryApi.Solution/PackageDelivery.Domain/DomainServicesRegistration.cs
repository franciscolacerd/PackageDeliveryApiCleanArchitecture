using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PackageDelivery.Domain
{
    public static class DomainServicesRegistration
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}