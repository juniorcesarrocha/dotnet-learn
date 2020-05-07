using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using EstoqueProduto.Configuration;
using Microsoft.Extensions.Options;

namespace EstoqueProduto.Infra.Http
{
    public class Email : IEmail
    {
        private readonly SmtpSettings _smtpSettings;        
        public Email(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_smtpSettings.FromAddress)
            };

            mail.To.Add(new MailAddress(email));

            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using (SmtpClient smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
            {
                smtp.Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}