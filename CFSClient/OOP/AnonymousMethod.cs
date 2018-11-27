using System;

namespace CFSClient.OOP
{
	public class AnonymousMethod
	{
		public delegate void NumberChanger(int number);

		NumberChanger nc = delegate (int x)
		{
			Console.WriteLine("Anonymous method: {0}", x);
		};

		public void AnonymousMethodClient()
		{
			nc(10);
		}
	}
}
