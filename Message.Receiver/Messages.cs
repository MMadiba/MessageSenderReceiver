using System;
using Message.Bus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Message.Receiver
{
	public class Messages
	{
		private const string ReceivedMessage = "Hello {0}, I am your father!";

		public static void ReceiveMessage()
		{
			var configuration = Configuration.GetRabbitMqConfiguration();
			var messageBus = new MessageBus(configuration);
			var connection = messageBus.GetConnection();
			var channel = connection.CreateModel();
			channel.QueueDeclare(queue: configuration.QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
			var consumer = new EventingBasicConsumer(channel);
			consumer.Received += HandleMessage;
			channel.BasicConsume(queue: configuration.QueueName, autoAck: true, consumer: consumer);
		}

		private static void HandleMessage(object sender, BasicDeliverEventArgs e)
		{
			var body = e.Body.ToArray();
			var receivedName = string.Empty;
			if (!Validation.IsNameValid(body, ref receivedName)) return;
			Console.WriteLine(ReceivedMessage, receivedName);
		}
	}

	
}
