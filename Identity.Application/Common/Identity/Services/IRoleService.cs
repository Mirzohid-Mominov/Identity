using Identity.Domain.Entities;
using Identity.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Identity.Services
{
    public interface IRoleService
    {
        ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking, CancellationToken cancellationToken = default);
    }
}
