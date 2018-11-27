using System;

namespace CFSClient.OOP
{
	public class Parent
	{
		public void Print()
		{
			Console.WriteLine("In parent");
		}
	}

	public class Child1 : Parent
	{
		public new void Print()
		{
			Console.WriteLine("Child1 class, shadowing implemented without warnings");
		}
	}

	public class Child2 : Parent
	{
		//
		public void Print()
		{
			Console.WriteLine("Child2 class, shadowing implemented with compiler warning");
		}
	}
}
