using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.RabbitMq.Models;

namespace UserAPI.RabbitMq.Sender
{
    public class RabbitMqSender : IRabbitMqSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _username;
        private IConnection _connection;

        public RabbitMqSender()
        {
            _hostname = "localhost";
            _password = "guest";
            _username = "guest";
        }

        public void SendMessage(BaseMessage message, string queueName)
        {
            if (ConnectionExists())
            {
                using IModel channel = _connection.CreateModel();
                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
            else
            {
                Console.WriteLine("Failed to establish RabbitMQ connection.");
                // Log the connection failure here
            }
        }

        private void CreateConnection()
        {
            try
            {
                ConnectionFactory factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
                Console.WriteLine("RabbitMQ connection established.");
                // Log the successful connection here
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to establish RabbitMQ connection: {ex.Message}");
                // Log the connection failure here
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null && _connection.IsOpen)
            {
                return true;
            }
            CreateConnection();
            return _connection != null && _connection.IsOpen;
        }
    }
}
