using PackageDelivery.Persistence.Repositories.Models.Pagination.Common;

namespace PackageDelivery.Persistence.Repositories.Models.Pagination
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}