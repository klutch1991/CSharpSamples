using System;

namespace _008_AnonymousTypes
{
	class Program
	{
		static void Main(string[] args)
		{
			// Compiler generates common type for both instances
			// due to they are generated in same assembly and
			// hae THE SAME MEMBER NAMES AND COUNT
			// equality member are defined
			var a = new { X = 1, Y = 2 };
			var b = new { X = 2, Y = 3 };

			// ANOTHER TYPE
			var c = new { X = 2, Y = 3, Z = 9 };

			// ANOTHER TYPE
			var d = new { M = 2, Y = 3 };

			Console.WriteLine(a.GetType());
			Console.WriteLine(b.GetType());
			Console.WriteLine(a.GetType() == b.GetType());
		}
	}
}
