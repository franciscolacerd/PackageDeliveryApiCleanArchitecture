using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PackageDelivery.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}