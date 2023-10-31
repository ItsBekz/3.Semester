using RabbitMQ.Client;
using System.Text;

namespace api.RabbitMQ
{
    public class RabbitMqPublisher
    {
        private IModel _channel;

        public RabbitMqPublisher()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq"};
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        public void PublishMessage(string message, string queueName)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
}
