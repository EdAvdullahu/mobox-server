namespace UserAPI.RabbitMq.Models
{
    public class NewUserHeader:BaseMessage
    {
        public Guid UserId { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Image { get; set; }
    }
}
