using System;
using System.Collections.Generic;
using System.Linq;

namespace CFSClient.OOP
{
	public class ActionFuncPrep
	{
		public void Print(string str)
		{
			Console.WriteLine(str);
		}

		public int Addition(int a, int b)
		{
			return a + b;
		}
	}

	public class ActionFuncClient
	{
		//Consume custom Action<> & Func<>
		public static void ConsumeActionFunc()
		{
			var printtext = new Action<string>(new ActionFuncPrep().Print);
			var addition = new Func<int,int,int>(new ActionFuncPrep().Addition);
			Console.WriteLine("Action<> delgate.....");
			printtext("Hello world");
			Console.WriteLine("\n");
			Console.WriteLine("Func<> delgate.....");
			Console.WriteLine(addition(1,2));

			//Best exmaple of in build Func<> delegate
			var itemList = new List<int>() { 1, 2, 3, 4 };
			var evenList = itemList.Where(i => i % 2 == 0);
			// Break up of above where method is Func<int, bool>
			Console.WriteLine("\n Inside even list");
			foreach (var even in evenList)
			{
				Console.WriteLine(even);
			}
		}
	}
}
