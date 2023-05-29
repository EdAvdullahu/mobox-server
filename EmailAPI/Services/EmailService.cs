using EmailAPI.Models;
using EmailAPI.Repository;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EmailAPI.Services
{
    public class EmailService : IEmailService {


        private readonly IConfiguration _config;
        private readonly IEmailRepository _repo;

        public EmailService(IConfiguration config, IEmailRepository repo)
        {
            _config = config;
            _repo = repo;
        }
        public async Task<bool> SendEmail(EmailLog request)
        {
                await _repo.CreateAsync(request);
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.Email));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailUsername").Value, _config.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
        }
    }
}

