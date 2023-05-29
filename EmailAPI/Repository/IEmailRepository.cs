using EmailAPI.Models;

namespace EmailAPI.Repository
{
    public interface IEmailRepository
    {
        Task<List<EmailLog>> GetAsync();
        Task<EmailLog?> GetAsync(string id);
        Task<List<EmailLog?>> GetByUserAsync(Guid id);
        Task CreateAsync(EmailLog newEmail);
    }
}
