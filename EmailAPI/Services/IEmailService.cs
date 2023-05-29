using EmailAPI.Models;

namespace EmailAPI.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailLog request);
    }
}
