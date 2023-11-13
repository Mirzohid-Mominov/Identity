using Identity.Application.Common.Constants;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Identity.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class TokenGeneratorService : ITokenGeneratorService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenGeneratorService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public List<Claim> GetClaims(User user)
        {
            return new List<Claim>()
            {
                new(ClaimTypes.Email, user.EmailAddress),
                new(ClaimTypes.Role, user.Role.Type.ToString()),
                new(ClaimConstants.UserId, user.Id.ToString()),
            };
        }

        public JwtSecurityToken GetJwtToken(User user)
        {
            var claims = GetClaims(user);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: _jwtSettings.ValidIsUser,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
                signingCredentials: credentials
                );
        }

        public string GetToken(User user)
        {
            var jwtToken = GetJwtToken(user);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var test = new JwtSecurityTokenHandler();

            return token;
        }
    }
}
