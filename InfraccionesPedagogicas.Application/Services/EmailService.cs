using InfraccionesPedagogicas.Application.Interfaces.Services;
using InfraccionesPedagogicas.Application.Models;
using InfraccionesPedagogicas.Core.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace InfraccionesPedagogicas.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationEmail(Asistencia registroAsistencia)
        {
            var emailInfo = _configuration.GetSection("MailSettings").Get<MailSettings>();

            var builder = new BodyBuilder
            {
                HtmlBody = "Testing email for infractor"
            };

            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(emailInfo.Mail),
                Subject = "Testing",
                Body = builder.ToMessageBody()
            };
            email.To.Add(MailboxAddress.Parse("acsm2411@gmail.com"));

            using var smtp = new SmtpClient();
            smtp.Connect(emailInfo.Host, emailInfo.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailInfo.Mail, emailInfo.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
