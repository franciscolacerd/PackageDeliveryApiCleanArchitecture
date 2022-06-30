using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain;
using PackageDelivery.Persistence.Common;

namespace PackageDelivery.Persistence
{
    public class PackageDeliveryDbContext : BaseDbContext
    {
        public PackageDeliveryDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PackageDeliveryDbContext).Assembly);
        }

        public DbSet<Delivery> Deliveries { get; set; } = null!;

        public DbSet<Package> Packages { get; set; } = null!;
    }
}