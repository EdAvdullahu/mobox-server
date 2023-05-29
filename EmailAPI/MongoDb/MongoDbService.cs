using EmailAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EmailAPI.MongoDb
{
    public class MongoDbService
    {
        private readonly IMongoCollection<EmailLog> _emails;
        public MongoDbService(IOptions<MongoDbSettings> mongoSettings)
        {
            MongoClient client = new MongoClient(mongoSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _emails = database.GetCollection<EmailLog>(mongoSettings.Value.CollectionName);
        }
        public async Task<List<EmailLog>> GetAsync() =>
        await _emails.Find(_ => true).ToListAsync();

        public async Task<EmailLog?> GetAsync(string id) =>
            await _emails.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<EmailLog?>> GetByUserAsync(Guid id) =>
            await _emails.Find(x => x.UserId == id).ToListAsync();

        public async Task CreateAsync(EmailLog newEmail)
        {
            newEmail.Id = null;
            await _emails.InsertOneAsync(newEmail);
        }

        public async Task RemoveAsync(string id) =>
            await _emails.DeleteOneAsync(x => x.Id == id);
    }
}
