using Identity.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories
{
    public class EntityRepositoryBase<TEntity, TContext> where TEntity : class, IEntity where TContext : DbContext 
    {
        protected TContext DbContext => (TContext)_dbContext;

        private readonly DbContext _dbContext;

        protected EntityRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
        {
            var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

            if(predicate is not null) 
                initialQuery = initialQuery.Where(predicate);

            if(asNoTracking)
                initialQuery = initialQuery.AsNoTracking();

            return initialQuery;
        }

        public async ValueTask<TEntity?> GetByIdAsync(
            Guid id,
            bool asNoTracking = false,
            CancellationToken cancellationToken = default)
        {
            var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

            if (asNoTracking)
                initialQuery = initialQuery.AsNoTracking();

            return await initialQuery.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken : cancellationToken);

        }
       
    }
}
