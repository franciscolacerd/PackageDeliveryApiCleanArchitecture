using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Common
{
    public class BaseDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        private const string defaultUsername = "SYSTEM";

        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public virtual int SaveChanges(string username = defaultUsername)
        {
            if (string.IsNullOrEmpty(username)) { username = defaultUsername; }

            Save(username);

            return base.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync(string username = defaultUsername)
        {
            if (string.IsNullOrEmpty(username)) { username = defaultUsername; }

            Save(username);

            return await base.SaveChangesAsync();
        }

        public virtual async Task<int> SaveChangesAsync(string username = defaultUsername, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(username)) { username = defaultUsername; }

            Save(username);

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void Save(string username)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseDomainEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedDateUtc = DateTime.UtcNow;
                entry.Entity.UpdatedBy = username;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDateUtc = DateTime.UtcNow;
                    entry.Entity.CreatedBy = username;
                }
            }
        }
    }
}