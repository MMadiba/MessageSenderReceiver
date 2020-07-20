using System;
using Message.Bus.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Message.Bus
{
	public class MessageBus : IMessageBus
	{
		private readonly string _hostName;
		private readonly string _userName;
		private readonly string _password;

		public MessageBus(RabbitMqConfiguration rabbitMqOptions)
		{
			_hostName = rabbitMqOptions.HostName;
			_userName = rabbitMqOptions.UserName;
			_password = rabbitMqOptions.Password;
		}
		public IConnection GetConnection()
		{
			var connectionFactory = new ConnectionFactory
			{
				HostName = _hostName, UserName = _userName, Password = _password
			};

			IConnection connection;
			try
			{
				connection = connectionFactory.CreateConnection();
			}
			catch (BrokerUnreachableException ex)
			{
				throw new BrokerUnreachableException(ex.InnerException);
			}
			catch (ConnectFailureException ex)
			{
				throw new ConnectFailureException(ex.Message,ex.InnerException);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			return connection;
		}
	}

}
