using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Application.Features.Delivery.Handlers.Commands;
using PackageDelivery.Application.Validation.Delivery;

namespace PackageDelivery.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDeliveryCommandHandler).Assembly));

            services.AddScoped<AttributesValidator>();
            services.AddScoped<DeliveryValidator>();
            services.AddScoped<DetailsValidator>();

            return services;
        }
    }
}