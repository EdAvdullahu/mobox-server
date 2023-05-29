using UserAPI.RabbitMq.Models;

namespace UserAPI.RabbitMq.Sender
{
    public interface IRabbitMqSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
