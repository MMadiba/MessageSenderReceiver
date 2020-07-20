using System;

namespace Message.Receiver
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				Messages.ReceiveMessage();
				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
			Console.ReadLine();
		}

		

	}
}
