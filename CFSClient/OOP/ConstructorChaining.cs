namespace CFSClient.OOP
{
	// Mechanism of calling one ctor from another ctor
	// 1. To avoid duplicasy in code
	// 2. When it is necessary to call non-default base ctor
	class ConstructorChaining
	{
		private int Age { get; set; }
		private string Name { get; set; }
		//Default ctor
		public ConstructorChaining() : this(0, "") { }
		public ConstructorChaining(int age) : this(age, "") { }
		//parameterized ctor
		public ConstructorChaining(int age, string name)
		{
			Age = age;
			Name = name;
		}
		//copy ctor
		public ConstructorChaining(ConstructorChaining obj)
		{
			Age = obj.Age;
			Name = obj.Name;
		}

		//Private ctor
		private ConstructorChaining(float a) { }
	}


}
