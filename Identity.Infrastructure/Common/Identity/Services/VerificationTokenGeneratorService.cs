using Identity.Application.Common.Enums;
using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Settings;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class VerificationTokenGeneratorService : IVerificationTokenGeneratorService
    {
        private readonly IDataProtector _dataProtector;
        private readonly VerificationTokenSettings _verificationTokenSettings;

        public VerificationTokenGeneratorService(IOptions<VerificationTokenSettings> verificationTokenSettings,
        IDataProtectionProvider dataProtectionProvider)
        {
            _verificationTokenSettings = verificationTokenSettings.Value;
            _dataProtector = dataProtectionProvider.CreateProtector(_verificationTokenSettings.IdentityVerificationTokenPurpose);
        }

        public (VerificationToken Token, bool IsValid) DecodeToken(string token)
        {
            if(string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            var unprotectedToken = _dataProtector.Unprotect(token);
            var verificationToken = JsonConvert.DeserializeObject<VerificationToken>(unprotectedToken) ??
                throw new ArgumentException("Invalid verification model", nameof(token));

            return (verificationToken, verificationToken.ExpiryTime > DateTimeOffset.UtcNow);
        }

        public string GenerateToken(VerificationType type, Guid userId)
        {
            var verificationToken = new VerificationToken
            {
                UserId = userId,
                Type = type,
                ExpiryTime = DateTimeOffset.UtcNow.AddMinutes(_verificationTokenSettings.IdentityVerificationExpirationDurationInMinutes)
            };

            return _dataProtector.Protect(JsonConvert.SerializeObject(verificationToken));
        }
    }
}
