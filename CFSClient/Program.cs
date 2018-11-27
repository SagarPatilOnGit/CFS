using System;
using CFSApp.GoF.Structural;
using CFSClient.GoF;
using CFSClient.GoF.Behavioural;
using CFSClient.GoF.Creational;
using CFSClient.OOP;

namespace CFSClient
{
	class Program
	{
		static void Main()
		{
            /* //Utility class
			Console.WriteLine(Utility.GetVisitorCount());
			Console.WriteLine(Utility.NextVisitor());
			*/

            /* //Using clause implementation
			var obj = new UsingClauseClient();
			obj.ExecuteUsing();
			*/

            //// Delegate Implementation
            //DelegateClient.ConsumeDelegate();

            /* //Funct & Action delegate client
			ActionFuncClient.ConsumeActionFunc();
			*/

            /* //Anonymous method client
			new AnonymousMethod().AnonymousMethodClient();
			*/

            /* // Shadowing implementation
			Parent parent = new Child1();
			parent.Print();
			((Child1)parent).Print();
			parent = new Child2();
			parent.Print();
			((Child2)parent).Print();
			*/

            //Polymorphism
            var token = new IdentifierToken();
            IdentifierToken.Method1(token);
            IdentifierToken.Method2(token);

            /* Exception Handling
			//Console.WriteLine(new ExceptionHandling().HandleException());
			*/

            /* //abstract factory pattern
			//haldiram factory feedback
			SnacksFactory haldiramFactory = new HaldiramFactory();
			var haldiramCustomer = new Customer(haldiramFactory);
			Console.WriteLine("Haldiram products feedback :");
			haldiramCustomer.Feedback();
			Console.WriteLine("\n");

			//Balaji factory feedback
			SnacksFactory balajiFactory = new BalajiFactory();
			var balajiCustomer = new Customer(balajiFactory);
			Console.WriteLine("Balaji products feedback :");
			balajiCustomer.Feedback();
			*/

            /* //Singleton design pattern
			var s1 = Singleton.GetInstance();
			var s2 = Singleton.GetInstance();
			if (s1 == s2)
			{
				Console.WriteLine("Singleton implemented successfully");
			}
			*/

            /* // Factory Method design pattern
			new FactoryMethodClient().GetDocuments();
			*/

            /* //Template method design pattern
			Pizza vegPizza = new VegPizza();
			vegPizza.MakePizza();
			Console.WriteLine("\n");
			Pizza nonvegPizza = new NonvegPizza();
			nonvegPizza.MakePizza();
			*/

            /* //Observer pattern
			ObserverClient.PubSubPattern();
			*/

            /* //Facade pattern
			var customer = new CFSApp.GoF.Structural.Customer("Sagar Patil");
			IMortgage mortgage = new Mortgage();
			Console.WriteLine("\n" + customer.Name +
			                  " has been " + (mortgage.IsEligible(customer, 50000) ? "Approved" : "Rejected"));
							  */

            ////Adapter pattern
            //new AdapterClient().Display();

            //new RestApi().DisplayOldApis();
            //var temp = new Singleton().getInner();
        }
	}
}
