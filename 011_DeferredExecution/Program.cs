using System;
using System.Collections.Generic;
using System.Linq;

namespace _011_DeferredExecution
{
	class Program
	{
		static void Main(string[] args)
		{
			// captured variable
			int a = 10;

			List<int> numbers = new List<int>();
			numbers.Add(1);
			// enumeration is not executed it will be executed
			// right when enumeration is being proceeded
			IEnumerable<int> query = numbers.Select(x => x * a);  
			numbers.Add(2);

			Console.WriteLine("enumeration 1");
			// enumeration executed here
			foreach (var i in query)
			{
				Console.WriteLine(i); // 10 20
			}

			numbers.Remove(1);

			a = 20;

			Console.WriteLine("enumeration 2");
			// enumeration executed here again. TO avoid reenumeration, call ToList or ToArray (it caches result)
			foreach (var i in query)
			{
				Console.WriteLine(i); // 40, cuz captured variable evelueted at time of execution
			}
		}
	}
}