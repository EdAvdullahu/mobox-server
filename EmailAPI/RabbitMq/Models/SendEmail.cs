namespace EmailAPI.RabbitMq.Models
{
    public class SendEmail : BaseMessage
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
