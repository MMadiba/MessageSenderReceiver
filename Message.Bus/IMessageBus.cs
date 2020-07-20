using RabbitMQ.Client;

namespace Message.Bus
{
	internal interface IMessageBus
	{
		IConnection GetConnection();
	}
}
