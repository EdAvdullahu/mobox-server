using SongAPI.RabbitMq.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;
using SongAPI.Repository.Interface;
using SongAPI.Models.Dto;

namespace SongAPI.RabbitMq.Consumer
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
            _channel.QueueDeclare(queue: "NewUser", false, false, false,arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    NewUser newUser = JsonConvert.DeserializeObject<NewUser>(content);
                    if (newUser.Type == "Listener")
                    {
                        var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                        UserPutPost user = new UserPutPost
                        {
                            UISId = newUser.UserId,
                            UserName = newUser.Username
                        };
                        await userRepo.CreateUpdateUser(user);
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }else if(newUser.Type == "Artist")
                    {
                        var artistRepo = scope.ServiceProvider.GetRequiredService<IArtistRepository>();
                        ArtistPutPost artist = new ArtistPutPost
                        {
                            UISId = newUser.UserId,
                            Name = newUser.Username,
                            Image = newUser.Image,
                        };
                        await artistRepo.CreateUpdateArtist(artist);
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                    else
                    {
                        _channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                }
            };
            _channel.BasicConsume("NewUser", false, consumer);
            return Task.CompletedTask;
        }
    }
}
