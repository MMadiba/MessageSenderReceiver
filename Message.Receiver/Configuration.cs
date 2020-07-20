using Message.Bus.Options;
using Microsoft.Extensions.Configuration;

namespace Message.Receiver
{
	internal class Configuration
	{
		internal static RabbitMqConfiguration GetRabbitMqConfiguration()
		{
			IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true,true).Build();
			
			var configurationValue = configuration.GetSection(nameof(RabbitMqConfiguration));
			var rabbitMqConfiguration = new RabbitMqConfiguration
			{
				HostName = configurationValue["HostName"],
				UserName = configurationValue["UserName"],
				Password = configurationValue["Password"],
				QueueName = configurationValue["Queue"]
			};
			return rabbitMqConfiguration;
		}
	}
}
