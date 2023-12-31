﻿using Identity.Application.Common.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Common.Identity.Services
{
    public interface IAuthService
    {
        ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails, CancellationToken cancellationToken = default);

        ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default);

        ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default);
    }
}
