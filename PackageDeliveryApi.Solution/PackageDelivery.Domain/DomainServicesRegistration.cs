using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Builders;
using PackageDelivery.Domain.DomainModels.Delivery;
using PackageDelivery.Domain.Repositories;
using PackageDelivery.Persistence.Contracts.Persistence;
using System.Reflection;

namespace PackageDelivery.Domain;

public static class DomainServicesRegistration
{
    public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IDeliveryDomainModel, DeliveryDomainModel>();

        services.AddScoped<IDeliveryBuilder, DeliveryBuilder>();

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}