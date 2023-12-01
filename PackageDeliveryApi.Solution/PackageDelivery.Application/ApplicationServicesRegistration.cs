using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Validation.Delivery;
using System.Reflection;

namespace PackageDelivery.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<AttributesValidator>();
            services.AddScoped<DeliveryValidator>();
            services.AddScoped<DetailsValidator>();

            return services;
        }
    }
}