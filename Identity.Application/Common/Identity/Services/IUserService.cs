using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Identity.Services
{
    public interface IUserService
    {
        ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false,  CancellationToken cancellationToken = default);

        ValueTask<User?> GetByEmailAdddressAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default);
        
        ValueTask<User> Create(User user, CancellationToken cancellationToken = default);
    }
}
