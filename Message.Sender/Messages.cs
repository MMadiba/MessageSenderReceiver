using System.Text;
using Message.Bus;
using RabbitMQ.Client;

namespace Message.Sender
{
	public class Messages
	{
		private const string Message = "Hello my name is,{0}";
		public static void Send(string name)
		{
			var message = string.Format(Message, name);
			var configuration = Configuration.GetRabbitMqConfiguration();
			var messageBus = new MessageBus(configuration);
			var connection = messageBus.GetConnection();

			using (connection)
			{
				using var channel = connection.CreateModel();
				channel.QueueDeclare(configuration.QueueName, false, false, false, null);
				var body = Encoding.UTF8.GetBytes(message);
				channel.BasicPublish("", configuration.QueueName, null, body);
			}
		}

	}
}
