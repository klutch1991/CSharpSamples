using System;

namespace _002_CovariantAndContrvariant
{
	// Albahari page 146 ++ (also see delagates varianty)

	class A { }

	class B : A { }

	interface IXContrvariant<in T> { void DoContrvariantIn<T>(T item); }

	interface IXCovariant<out T> where T : new() { T DoCovariantOut<T>() where T : new(); }

	class X<T> : IXContrvariant<T>, IXCovariant<T> where T : new()
	{
		public void DoContrvariantIn<T>(T item) => Console.WriteLine(typeof(T).Name);

		public T DoCovariantOut<T>() where T : new() => new T();
	}

	class Program
	{
		static void Main(string[] args)
		{
			IXCovariant<A> xCovariant = new X<B>(); // allowed covariant implicit cast 
			// ковариантность - получение более специфического типа на выходе метода, чем запрошено параметром
			A a = xCovariant.DoCovariantOut<A>();
			B b = xCovariant.DoCovariantOut<B>();

			IXContrvariant<B> xContrvariantB = new X<A>(); ; // allowed contrvariant implicit cast
			// контрвариантность - введение менее специфического типа на вход метода, чем запрошено параметром
			xContrvariantB.DoContrvariantIn(new X<A>());
			xContrvariantB.DoContrvariantIn(new X<B>());
		}
	}
}
