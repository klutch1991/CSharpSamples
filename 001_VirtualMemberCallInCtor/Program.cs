using System;

namespace _001_VirtualMemberCallInCtor
{
	class Parent
	{
		public Parent()
		{
			DoSomething();
		}

		protected virtual void DoSomething()
		{
		}
	}

	class Child : Parent
	{
		private string foo;

		public Child()
		{
			foo = "HELLO";
		}

		protected override void DoSomething()
		{
			Console.WriteLine(foo.ToLower()); //NullReferenceException!?!
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var b = new Child();
		}
	}
}
