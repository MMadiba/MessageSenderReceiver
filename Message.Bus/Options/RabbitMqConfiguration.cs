﻿namespace Message.Bus.Options
{
	public class RabbitMqConfiguration
	{
		public string HostName { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string QueueName { get; set; }
	}
}
