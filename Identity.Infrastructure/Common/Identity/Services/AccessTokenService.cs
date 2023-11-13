using Identity.Application.Common.Identity.Services;
using Identity.Domain.Entities;
using Identity.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly IAccessTokenRepository _accessTokenRepository;

        public AccessTokenService(IAccessTokenRepository accessTokenRepository)
        {
            _accessTokenRepository = accessTokenRepository;
        }

        public ValueTask<AccessToken> CreateAsync(
            AccessToken token,
            bool saveChangesAsync = true,
            CancellationToken cancellationToken = default)
        {
            return _accessTokenRepository.CreateAsync(token, saveChangesAsync, cancellationToken);
        }

        public async ValueTask<AccessToken> CreateAsync(
            Guid userId, 
            string value, 
            bool saveChanges = true, 
            CancellationToken cancellationToken = default)
        {
            var accessToken = new AccessToken
            {
                UserId = userId,
                Value = value,
                CreatedTime = DateTime.UtcNow,
            };

            await _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);

            return accessToken;
        }
    }
}
