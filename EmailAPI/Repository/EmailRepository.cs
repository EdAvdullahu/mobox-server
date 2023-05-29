using EmailAPI.Models;
using EmailAPI.MongoDb;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EmailAPI.Repository
{
    public class EmailRepository:IEmailRepository
    {
        private readonly MongoDbService _service;
        public EmailRepository(MongoDbService service)
        {
            _service = service;
        }

        public async Task<List<EmailLog>> GetAsync() =>
        await _service.GetAsync();

        public async Task<EmailLog?> GetAsync(string id) =>
            await _service.GetAsync(id);

        public async Task<List<EmailLog?>> GetByUserAsync(Guid id) =>
            await _service.GetByUserAsync(id);

        public async Task CreateAsync(EmailLog newEmail) =>
            await _service.CreateAsync(newEmail);


    }
}
