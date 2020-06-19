using EventsDispatcher.Model;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

namespace EventsDispatcher.Tools
{
    public class BusDispatcher
    {
        public void Dispatch(EventItem eventItem)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(eventItem.EventType, true, false, false, null);
            var body = Encoding.UTF8.GetBytes(eventItem.SerializedContent);
            channel.BasicPublish("", eventItem.EventType, null, body);
            Debug.WriteLine($"{eventItem.EventType} Published");
        }
    }
}
