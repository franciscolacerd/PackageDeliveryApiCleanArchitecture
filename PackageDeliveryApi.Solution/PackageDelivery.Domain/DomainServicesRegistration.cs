using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Domain.Builders;
using PackageDelivery.Domain.Common;
using PackageDelivery.Domain.Contracts.Persistence;
using PackageDelivery.Domain.DomainModels.Delivery;
using PackageDelivery.Domain.Repositories;
using System.Reflection;

namespace PackageDelivery.Domain
{
    public static class DomainServicesRegistration
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IDeliveryDomainModel, DeliveryDomainModel>();

            services.AddScoped<IDeliveryBuilder, DeliveryBuilder>();

            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            services.AddScoped<IApiLogRepository, ApiLogRepository>();

            services.AddScoped<IDeliveryAttributeRepository, DeliveryAttributeRepository>();

            services.AddScoped<IDeliveryDeliveryAttributeRepository, DeliveryDeliveryAttributeRepository>();

            services.AddScoped<IDeliveryRepository, DeliveryRepository>();

            services.AddScoped<IEventRepository, EventRepository>();

            services.AddScoped<IEventTypeRepository, EventTypeRepository>();

            services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();

            services.AddScoped<IPackageRepository, PackageRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}