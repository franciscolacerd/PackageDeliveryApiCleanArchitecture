using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PackageDelivery.Persistence
{
    public class PackageDeliveryDbContextFactory : IDesignTimeDbContextFactory<PackageDeliveryDbContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PackageDeliveryDbContextFactory()
        {
        }

        public PackageDeliveryDbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public PackageDeliveryDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PackageDeliveryDbContext>();
            var connectionString = configuration.GetConnectionString("DbContext");

            builder.UseSqlServer(connectionString);

            return new PackageDeliveryDbContext(builder.Options, this._httpContextAccessor);
        }
    }
}