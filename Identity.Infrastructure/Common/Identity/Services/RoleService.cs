using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Identity.Domain.Enums;
using Identity.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public async ValueTask<Role?> GetByTypeAsync(RoleType roleType, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            var typeOfRole = await _roleRepository.Get(asNoTracking : asNoTracking)
                .SingleOrDefaultAsync(role => role.Type == roleType, cancellationToken);

            return typeOfRole;
        }
    }
}
