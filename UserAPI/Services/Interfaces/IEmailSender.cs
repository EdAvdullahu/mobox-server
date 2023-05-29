using UserAPI.RabbitMq.Models;

namespace UserAPI.Services.Interfaces
{
    public interface IEmailSender
    {
        public void SendEmail(EmailHeader email, string type);
    }
}
