using Identity.Application.Common.Enums;
using Identity.Application.Common.Identity.Services;
using Identity.Application.Common.Notifications.Services;
using Identity.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
        private readonly IUserService _userService;
        private readonly IEmailOrchestrationService _emailOrchestrationService;

        public AccountService(
            IVerificationTokenGeneratorService verificationTokenGeneratorService, 
            IUserService userService, 
            IEmailOrchestrationService emailOrchestrationService)
        {
            _verificationTokenGeneratorService = verificationTokenGeneratorService;
            _userService = userService;
            _emailOrchestrationService = emailOrchestrationService;
        }

        public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid verification token", nameof(token));

            var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

            if (!verificationTokenResult.IsValid)
                throw new InvalidOperationException("Invalid verification token");

            var result = verificationTokenResult.Token.Type switch
            {
                VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
                _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
            };

            return result;
        }
       
        public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            var createdUser = await _userService.CreateAsync(user, true,  cancellationToken);
            
            var verificationToken = 
                _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, createdUser.Id);

            var verificationEmaildResult = await _emailOrchestrationService.SendAsync(createdUser.EmailAddress,
                $"Welcome to System - {verificationToken}");

            var result = verificationEmaildResult;
            return result;
        }

        public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
        {
            return new(true);
        }
    }
}
