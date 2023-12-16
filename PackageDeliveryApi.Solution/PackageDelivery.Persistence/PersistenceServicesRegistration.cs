using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Persistence.Entities;
using PackageDelivery.Persistence.Stores;
using System.Reflection;

namespace PackageDelivery.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services
                .AddIdentityApiEndpoints<User>()
                .AddUserManager<ApplicationUserManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddEntityFrameworkStores<PackageDeliveryDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<PackageDeliveryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbContext"),
                options => options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), null)));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}