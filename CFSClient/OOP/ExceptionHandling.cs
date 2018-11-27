using System;

namespace CFSClient.OOP
{
	public class ExceptionHandling
	{
		public string HandleException()
		{
			try
			{
				var temp = (10 * 10) / 'o';
				// throw new Exception();
				return temp.ToString();
			}
			catch (Exception)
			{
				return "from catch";
			}
		}
	}
}
