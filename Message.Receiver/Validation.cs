using System;
using System.Text;

namespace Message.Receiver
{
	internal class Validation
	{
		internal static bool IsNameValid(byte[] message, ref string receivedName)
		{
			var isValid = true;
			try
			{
				var messageReceived = Encoding.UTF8.GetString(message);
				if(string.IsNullOrEmpty(messageReceived))
				{
					return false;
				}

				var splitMessage = messageReceived.Split(',');
				if(splitMessage.Length == 2)
				{
					receivedName = splitMessage[1];
				}
				else
				{
					return false;
				}
			}
			catch (Exception)
			{
				isValid = false;
			}
			return isValid;
		}
	}
}
