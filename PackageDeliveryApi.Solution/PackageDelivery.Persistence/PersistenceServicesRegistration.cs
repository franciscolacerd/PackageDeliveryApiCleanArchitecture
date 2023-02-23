﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackageDelivery.Persistence.Entities;
using System.Reflection;

namespace PackageDelivery.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddIdentity<User, IdentityRole<long>>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();

            services.AddDbContext<PackageDeliveryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbContext"),
                options => options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), null)));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}