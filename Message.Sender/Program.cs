using System;

namespace Message.Sender
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Name");
				var name = Console.ReadLine();
				Messages.Send(name);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);

			}

			Console.ReadLine();
		}
	}
}
