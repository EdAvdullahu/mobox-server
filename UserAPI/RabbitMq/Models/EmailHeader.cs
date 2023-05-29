namespace UserAPI.RabbitMq.Models
{
    public class EmailHeader: BaseMessage
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
