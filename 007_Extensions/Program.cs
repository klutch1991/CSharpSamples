using System;
using System.ComponentModel.Design.Serialization;

namespace _007_Extensions
{
	class Program
	{
		static void Main(string[] args)
		{
			var instance = new Something();
			var x = 1;

			// instance method has priority
			instance.Foo(x); 
			// avoiding natural priority
			SomethingExtensions.Foo(instance, x); 
			// using another extension methof with same signature (in case of ambigious invocetion)
			AnotherSomethingExtensions.Foo(instance, x); 
		}
	}

	class Something
	{
		public void Foo(object x) => Console.WriteLine("Instance method");
	}

	static class SomethingExtensions
	{
		public static void Foo(this Something something, int x) => Console.WriteLine("Extension method");
	}

	static class AnotherSomethingExtensions
	{
		public static void Foo(this Something something, int x) => Console.WriteLine("Another Extension method");
	}
}
