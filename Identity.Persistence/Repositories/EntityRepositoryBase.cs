using Identity.Domain.Common;
using Identity.Domain.Entities;
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

        public async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
        )
        {
            var initialQuery = DbContext.Set<TEntity>().Where(entity => true);

            if(asNoTracking)
                initialQuery = initialQuery.AsNoTracking();

            return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
        }


        public async ValueTask<TEntity> CreateAsync(
            TEntity entity,
            bool saveChanges, 
            CancellationToken cancellationToken)
        {
            await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

            if (saveChanges)
                await DbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        internal async ValueTask<TEntity> UpdateAsync(
            TEntity entity,
            bool saveChanges,
            CancellationToken cancellationToken)
        {
            var type = typeof(TEntity);

            DbContext.Set<TEntity>().Update(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async ValueTask<TEntity?> DeleteAsync(
            TEntity entity, 
            bool saveChanges = true,
            CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().Remove(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async ValueTask<TEntity> DeleteByIdAsync(
            Guid id,
            bool saveChanges = true,
            CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
                throw new InvalidOperationException();

            DbContext.Set<TEntity>().Remove(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
