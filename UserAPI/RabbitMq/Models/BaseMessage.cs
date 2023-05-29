namespace UserAPI.RabbitMq.Models
{
    public class BaseMessage
    {
        public int Id { get; set; }
        public DateTime MessageCreated { get; set; } = DateTime.UtcNow;
    }
}
