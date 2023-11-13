using Identity.Domain.Entities;
using Identity.Persistence.DataContexts;
using Identity.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories
{
    public class UserRepository : EntityRepositoryBase<User, IdentityDbContext>, IUserRepository
    {
        public UserRepository(IdentityDbContext context) : base(context)
        {

        }

        public ValueTask<User?> GetByIdAsync(Guid userId, bool asNotracking = false, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(userId, asNotracking, cancellationToken);
        }

        public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(user, saveChanges, cancellationToken);
        }
        
        public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(user, saveChanges, cancellationToken);
        }
    }
}
