using EmailAPI.RabbitMq.Models;
using EmailAPI.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using EmailAPI.Models;

namespace EmailAPI.RabbitMq.Consumer
{
    public class RabbitMqConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "EmailQueue", false, false, false,arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    SendEmail email = JsonConvert.DeserializeObject<SendEmail>(content);
                    EmailLog emailLog = new EmailLog
                    {
                        Email = email.Email,
                        Subject = email.Subject,
                        Body = email.Message,
                        UserId = email.UserId
                    };
                    await emailService.SendEmail(emailLog);
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };
            _channel.BasicConsume("EmailQueue", false, consumer);
            return Task.CompletedTask;
        }
    }
}
