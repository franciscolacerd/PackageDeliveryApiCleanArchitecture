using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain.Entities;
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Delivery> Deliveries { get; set; } = null!;

        public DbSet<Package> Packages { get; set; } = null!;

        public DbSet<DeliveryDeliveryAttribute> DeliveryDeliveryAttributes { get; set; } = null!;

        public DbSet<DeliveryAttribute> DeliveryAttributes { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        public DbSet<EventType> EventTypes { get; set; } = null!;

        public DbSet<ExceptionLog> ExceptionLogs { get; set; } = null!;

        public DbSet<ApiLog> ApiLogs { get; set; } = null!;
    }
}