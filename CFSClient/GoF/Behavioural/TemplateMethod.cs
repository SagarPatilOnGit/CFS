using System;

namespace CFSClient.GoF.Behavioural
{
	// This design pattern cannot be implemented without abstract classes
	public abstract class Pizza
	{
		//Template Method
		public void MakePizza()
		{
			MakeDough();
			AddTomatoSause();
			AddCheese();
			AddTopings();
		}

		// Abstract method provides degree of freedom & pattern's expressive power 
		public abstract void AddTopings();

		private void AddCheese()
		{
			Console.WriteLine("Add cheese");
		}

		private void MakeDough()
		{
			Console.WriteLine("Make dough");
		}

		private void AddTomatoSause()
		{
			Console.WriteLine("Add tomato sause");
		}
	}

	public class VegPizza : Pizza
	{
		public override void AddTopings()
		{
			Console.WriteLine("Add tomotoes, pepper, mushrooms!");
		}
	}

	public class NonvegPizza : Pizza
	{
		public override void AddTopings()
		{
			Console.WriteLine("Add bacon, chicken!");
		}
	}
}
