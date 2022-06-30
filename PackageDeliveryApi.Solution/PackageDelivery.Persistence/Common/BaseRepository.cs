using Microsoft.EntityFrameworkCore;
using PackageDelivery.Domain.Common;
using System.Linq.Expressions;

namespace PackageDelivery.Persistence.Common
{
    public class BaseRepository<TEntity>
           where TEntity : BaseDomainEntity
    {
        private readonly PackageDeliveryDbContext _dbContext;

        public BaseRepository(PackageDeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> SetFiltersToQuery(
            TrackChanges trackChanges,
            Expression<Func<TEntity, bool>>? predicate)
        {
            return SetFiltersToQuery(trackChanges, predicate, null);
        }

        public IQueryable<TEntity> SetFiltersToQuery(
             TrackChanges trackChanges,
             Expression<Func<TEntity, bool>>? predicate,
             Expression<Func<TEntity, object>>[]? includes)
        {
            return SetFiltersToQuery(trackChanges, predicate, includes, null);
        }

        public IQueryable<TEntity> SetFiltersToQuery(
             TrackChanges trackChanges,
             Expression<Func<TEntity, bool>>? predicate,
             Expression<Func<TEntity, object>>[]? includes,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var dbSet = _dbContext.Set<TEntity>();

            IQueryable<TEntity> _query = dbSet;

            if (trackChanges == TrackChanges.AsNoTracking)
                _query = _query.AsNoTracking();

            if (predicate != null)
                _query = _query.Where(predicate);

            if (includes != null)
                _query = includes.Aggregate(_query, (current, include) => current.Include(include));

            if (orderBy != null)
                return orderBy(_query);

            return _query;
        }
    }
}