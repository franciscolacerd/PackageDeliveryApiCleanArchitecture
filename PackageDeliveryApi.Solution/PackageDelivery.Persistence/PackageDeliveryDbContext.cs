using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PackageDelivery.Persistence.Common;
using PackageDelivery.Persistence.Contracts;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence
{
    public class PackageDeliveryDbContext : BaseDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PackageDeliveryDbContext()
        {
        }

        public PackageDeliveryDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PackageDeliveryDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(x => x.Entity is IAudit && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((IAudit)entry.Entity).CreatedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "Anonymous";
                    ((IAudit)entry.Entity).CreatedDateUtc = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    ((IAudit)entry.Entity).UpdatedBy = this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "Anonymous";
                    ((IAudit)entry.Entity).UpdatedDateUtc = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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