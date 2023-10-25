using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("demo-queue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
    );
var message = new { Name = "Producer", Message = "Hello" };
var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

channel.BasicPublish("", "demo-queue", null, body);

channel.QueueDeclare("test-queue",
    durable: true,
    exclusive: false,
    autoDelete: false,
    arguments: null
    );
var message2 = new { Name = "Producer", Message = "test" };
var body2 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message2));

channel.BasicPublish("", "test-queue", null, body2);
