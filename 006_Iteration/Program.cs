using System;
using System.Collections.Generic;

namespace _006_Iteration
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach (var word in Foo(false))
			{
				Console.WriteLine(word);
			}
		}

		// yield operators executed in deferred manner (enumeration is not executed before starting foreach loop)
		static IEnumerable<string> Foo(bool early)
		{
			try
			{
				Console.WriteLine("yielding");
				yield return "one";

				Console.WriteLine("yielding");
				yield return "two";

				if (early)
					yield break;

				Console.WriteLine("yielding");
				yield return "three";
			}
			// catch (Exception e) { Console.WriteLine(e); } catch is restricted for yields
			finally
			{
				// yield return "four"; yield is restricted inside finally or catch
				Console.WriteLine("Finally"); // executed at the end
			}
		}
	}
}
