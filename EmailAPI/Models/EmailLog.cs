using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmailAPI.Models
{
    public class EmailLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Log { get; set; }
        public DateTime EmailSent { get; set; }
    }
}
