using Identity.Application.Common.Notifications.Services;
using Identity.Application.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Common.Notifications.Services
{
    public class EmailOrchestrationService : IEmailOrchestrationService
    {
        private readonly EmailSenderSetting _emailSenderSetting;

        public EmailOrchestrationService(IOptions<EmailSenderSetting> emailSenderSetting)
        {
            _emailSenderSetting = emailSenderSetting.Value;
        }

        public ValueTask<bool> SendAsync(string emailAddress, string message)
        {
            var mail = new MailMessage(_emailSenderSetting.CredentialAddress, emailAddress);
            mail.Subject = "You successfully registered";
            mail.Body = message;

            var smtpClient = new SmtpClient(_emailSenderSetting.Host, _emailSenderSetting.Port);
            smtpClient.Credentials = new NetworkCredential(_emailSenderSetting.CredentialAddress, _emailSenderSetting.Password);
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);

            return new(true);
        }
    }
}
