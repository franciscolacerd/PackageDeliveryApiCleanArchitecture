using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PackageDelivery.Persistence
{
    public class PackageDeliveryDbContextFactory : IDesignTimeDbContextFactory<PackageDeliveryDbContext>
    {
        public PackageDeliveryDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PackageDeliveryDbContext>();
            var connectionString = configuration.GetConnectionString("DbContext");

            builder.UseSqlServer(connectionString);

            return new PackageDeliveryDbContext(builder.Options);
        }
    }
}