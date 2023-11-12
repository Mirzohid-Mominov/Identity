using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repositories.Interfaces
{
    public interface IAccessTokenRepository
    {
        ValueTask<AccessToken> CreateAsync(
            AccessToken token,
            bool saveChanges = true,
            CancellationToken cancellationToken = default);
    }
}
