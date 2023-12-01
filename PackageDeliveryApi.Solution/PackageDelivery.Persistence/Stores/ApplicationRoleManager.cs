using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace PackageDelivery.Persistence.Stores
{
    public class ApplicationRoleManager : RoleManager<IdentityRole<int>>
    {
        public ApplicationRoleManager(
            IRoleStore<IdentityRole<int>> store,
            IEnumerable<IRoleValidator<IdentityRole<int>>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<IdentityRole<int>>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}