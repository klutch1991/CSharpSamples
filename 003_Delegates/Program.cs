using System;

namespace _003_Delegates
{
	public delegate string Trimmer(string value);

	class A
	{
		public string Trim(string s) => s.Trim(' ');
	}

	class B : A
	{
	}

	class Program
	{
		static void Main(string[] args)
		{
			var a = new A();
			var b = new B();

			Trimmer t = a.Trim;
			t += b.Trim;
			
			Console.WriteLine($"Delagate target is of type {((MulticastDelegate)t).Target.GetType().Name}");

			foreach (Delegate d in t.GetInvocationList())
			{
				Console.WriteLine($"Delagate target from invocation list is of type {d.Target.GetType().Name}");
			}
		}
	}
}
