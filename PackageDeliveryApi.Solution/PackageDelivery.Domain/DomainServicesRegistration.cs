using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Builders;
using PackageDelivery.Domain.DomainModels.Delivery;
using System.Reflection;

namespace PackageDelivery.Domain;

public static class DomainServicesRegistration
{
    public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IDeliveryDomainModel, DeliveryDomainModel>();

        services.AddScoped<IDeliveryBuilder, DeliveryBuilder>();

        return services;
    }
}