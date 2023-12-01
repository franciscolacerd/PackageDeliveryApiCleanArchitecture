using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PackageDelivery.Persistence.Entities;

namespace PackageDelivery.Persistence.Stores
{
    public class ApplicationUserStore : UserStore<User, IdentityRole<int>, PackageDeliveryDbContext, int>
    {
        public ApplicationUserStore(PackageDeliveryDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
        {
        }
    }
}