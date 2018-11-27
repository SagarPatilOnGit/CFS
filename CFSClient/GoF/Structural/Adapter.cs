using System;

namespace CFSApp.GoF.Structural
{
	//Target class
	public class Loan
	{
		protected readonly string _loanType;
		protected string _collateral;
		protected int _maxTerms;
		protected decimal _sactionAmountPercentage;

		public Loan(string type)
		{
			_loanType = type;
		}

		public virtual void LoanEnquiry()
		{
			Console.WriteLine("\nRequested loan is {0} loan",_loanType);
			Console.WriteLine("Collateral is {0}", _collateral);
			Console.WriteLine("Maximum installments can be {0}", _maxTerms);
			Console.WriteLine("Loan amount to be sanctioned is {0}% of colllateral value.", _sactionAmountPercentage);
		}
	}

	//Adapter class
	public class CarLoan : Loan
	{
		public CarLoan(string type) : base(type) { }

		public override void LoanEnquiry()
		{
			var adaptee = new LoanDetails();
			_collateral = adaptee.GetLoanDetails(_loanType, 'C');
			_maxTerms = adaptee.GetLoanDetails(_loanType, 'M');
			_sactionAmountPercentage = adaptee.GetLoanDetails(_loanType, 'S');
			base.LoanEnquiry();
		}
	}

	//Adapter class
	public class HomeLoan : Loan
	{
		public HomeLoan(string type) : base(type){}

		public override void LoanEnquiry()
		{
			var adaptee = new LoanDetails();
			_collateral = adaptee.GetLoanDetails(_loanType, 'C');
			_maxTerms = adaptee.GetLoanDetails(_loanType, 'M');
			_sactionAmountPercentage = adaptee.GetLoanDetails(_loanType, 'S');
			base.LoanEnquiry();
			Console.WriteLine("As per RBI guidelines home loans below 2 million INR will get quarter million subsidy from central govt.");
		}
	}

	//Adaptee class
	public class LoanDetails
	{
		public dynamic GetLoanDetails(string loanType, char value)
		{
			if (value == 'C')
			{
				return loanType;
			}
			else if (value == 'M')
			{
				switch (loanType)
				{
					case "Car": return 60;
					case "Home": return 300;
					default: return 0;
				}
			}
			else
			{
				switch (loanType)
				{
					case "Car": return 100.00M;
					case "Home": return 85.00M;
					default: return 0.00M;
				}
			}
		}
	}

	public class AdapterClient
	{
		public void Display()
		{
			new Loan("Unknown").LoanEnquiry();
			new CarLoan("Car").LoanEnquiry();
			new HomeLoan("Home").LoanEnquiry();
		}
	}
}
