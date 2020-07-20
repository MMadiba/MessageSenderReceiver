using Message.Receiver;
using NUnit.Framework;

namespace Message.Test
{
	public class Tests
	{
		[Test]
		public void Test()
		{
			const string name = "IQ Business";
			Sender.Messages.Send(name);
			Messages.ReceiveMessage();
			Assert.Pass();
		}
	}
}