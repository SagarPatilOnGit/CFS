using System;

namespace CFSClient.GoF.Creational
{
	//abstract factory
	public abstract class SnacksFactory
	{
		public abstract Sweet PrepareSweet();
		public abstract Wafers PrepareWafers();
	}

	//abstract products
	public abstract class Sweet
	{
		public abstract void Eat();
	}

	public abstract class Wafers
	{
		public abstract void Eat();
	}

	//Haldiram Nagpur Snacks Factory
	public class Rasgulla : Sweet
	{
		public override void Eat() => Console.WriteLine("Very yummy rasgulla");
	}

	public class BananaWafers : Wafers
	{
		public override void Eat() => Console.WriteLine("Best banana wafers");
	}

	public class HaldiramFactory : SnacksFactory
	{
		public override Sweet PrepareSweet() => new Rasgulla();
		public override Wafers PrepareWafers() => new BananaWafers();
	}

	//Balaji Gujrat Snacks Factory
	public class DryGulabJam : Sweet
	{
		public override void Eat() => Console.WriteLine("Cheap and Yummy Gulabjam");
	}

	public class PotatoWafers : Wafers
	{
		public override void Eat() => Console.WriteLine("Large quantity and tasty potato wafers");
	}

	public class BalajiFactory : SnacksFactory
	{
		public override Sweet PrepareSweet() => new DryGulabJam();
		public override Wafers PrepareWafers() => new PotatoWafers();
	}

	//Client class
	class Customer
	{
		private readonly Sweet _sweet;
		private readonly Wafers _wafers;

		public Customer(SnacksFactory snacksFactory)
		{
			_wafers = snacksFactory.PrepareWafers();
			_sweet = snacksFactory.PrepareSweet();
		}

		//customer feedback method
		public void Feedback()
		{
			_wafers.Eat();
			_sweet.Eat();
		}
	}
}
