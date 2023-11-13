using Identity.Domain.Entities;
using Identity.Persistence.DataContexts;
using Identity.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories
{
    public class RoleRepository : EntityRepositoryBase<Role, IdentityDbContext>, IRoleRepository
    {
        public RoleRepository(IdentityDbContext context) : base(context)
        {

        }

        public new IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false)
        {
            return base.Get(predicate, asNoTracking);
        }
    }
}
