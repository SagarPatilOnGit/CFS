using System;

namespace CFSApp.GoF.Structural
{
	public interface IMortgage
	{
		bool IsEligible(Customer cust, int amount);
	}

	class Mortgage : IMortgage
	{
		private readonly Bank _bank = new Bank();
		private readonly Credit _credit = new Credit();
		private readonly Loans _loan = new Loans();

		public bool IsEligible(Customer cust, int amount)
		{
			Console.WriteLine("{0} applies for {1:C} loan\n",
				cust.Name, amount);

			bool eligible = true;

			// Check creditworthyness of applicant

			if (!_bank.HasSufficientSavings(cust, amount))
			{
				eligible = false;
			}
			else if (!_loan.HasNoBadLoans(cust))
			{
				eligible = false;
			}
			else if (!_credit.HasGoodCredit(cust))
			{
				eligible = false;
			}

			return eligible;
		}
	}

	/// <summary>
	/// The 'Subsystem ClassA' class
	/// </summary>
	class Bank
	{
		public bool HasSufficientSavings(Customer c, int amount)
		{
			Console.WriteLine("Check bank for " + c.Name);
			return true;
		}
	}

	/// <summary>
	/// The 'Subsystem ClassB' class
	/// </summary>
	class Credit
	{
		public bool HasGoodCredit(Customer c)
		{
			Console.WriteLine("Check credit for " + c.Name);
			return true;
		}
	}

	/// <summary>
	/// The 'Subsystem ClassC' class
	/// </summary>
	class Loans
	{
		public bool HasNoBadLoans(Customer c)
		{
			Console.WriteLine("Check loans for " + c.Name);
			return true;
		}
	}

	public class Customer
	{
		private string _name;
		// Constructor
		public Customer(string name)
		{
			_name = name;
		}

		// Gets the name
		public string Name
		{
			get { return _name; }
		}
	}
}
