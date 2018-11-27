using System;
using System.Collections.Generic;

namespace CFSClient.OOP
{
	// Why Delegates: To insert on the fly business logic / function into framework classes

	//Framework class
	public class Employee
	{
		//Properties
		public int Experience { get; set; }
		public string Name  { get; set; }
		public int ID { get; set; }
		public double Salary { get; set; }

		/* // Hard coded logic in framwork class to promote employee, no resuability
		public void PromoteEmployee(List<Employee> emps)
		{
			foreach (var emp in emps)
			{
				if(emp.Experience > 5)
					Console.WriteLine(emp.Name + " is promoted");
			}
		}
		*/

		// using delegate no hard coded logic, framework component is reusable even if business logic changes
		// step 2: pass delegate as a parameter to framework class function		
		public static void PromoteEmployee(List<Employee> emps, PromoteEmployeeDelegate del)
		{
			foreach (var emp in emps)
			{
				if (del(emp))
					Console.WriteLine(emp.Name + " is promoted");
			}
		}
	}

	// step 1 : declare delegate with same signature as of function pointer
	public delegate bool PromoteEmployeeDelegate(Employee emp);

	public class DelegateClient
	{
		//// step 3: write function pointer with same delgate singnature
		//// this block will be in business component which can be modified as and when required
		//public static bool IsPromoted(Employee emp)
		//{
		//	if (emp.Experience > 5 && emp.Salary > 5000)
		//	{
		//		return true;
		//	}
		//	return false;
		//}

		public static void ConsumeDelegate()
		{
			var empList = new List<Employee>() {
				new Employee() { ID = 1, Name = "ABC", Experience = 4, Salary = 6000 },
				new Employee() { ID = 2, Name = "XYZ", Experience = 6, Salary = 8000 }
			};

			//Step 4: Instantiate delegate

			//var del = new PromoteEmployeeDelegate(IsPromoted);

			// call to framework class
			// Note: static methods are not required, it is only for experimentation purpose
			//Employee.PromoteEmployee(empList, del);
			// Step 3 & 4 are not needed if we use lambda expression
			Employee.PromoteEmployee(empList, emp => emp.Salary > 5000 && emp.Experience > 5);
		}
	}


}
