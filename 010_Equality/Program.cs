using System;

namespace _010_Equality
{
	struct Str
	{
		public int A { get; set; }
		public int B { get; set; }
	}

    class Program
    {
        static void Main(string[] args)
        {
			// regular ints
	        int x = 1;
	        int y = 1;
	        Console.WriteLine(x == y); // true (value equality)

			// boxed ints
	        object a = x;
	        object b = y;
	        Console.WriteLine(a == b); // false (reference equality) == operation is binded ty types

			// true, using value equality, Equals method is bound to actual value type, but not reference type
	        // ALWAYS BOXED (potentially poor performance) to avoid - use IEqutable<T> (no boxing)
			Console.WriteLine(a.Equals(b)); 
			// same stuff
			Console.WriteLine(object.Equals(a, b));
			// safe to null
			Console.WriteLine(object.Equals(a, null));

			// false (forced reference equality)
	        Console.WriteLine(object.ReferenceEquals(a, b));
			// false (forced reference equality with implicit boxing to object type)
			Console.WriteLine(object.ReferenceEquals(x, y));

	        // == (equality operiton) executes statically and works faster
	        // .Equals(T) is being executed on object as virtual method and potentially requires more CPU time

	        var str1 = new Str { A = 1, B = 1 };
			var str2 = new Str { A = 1, B = 1 };
			//Console.WriteLine(str1 == str2); unappliable
			// true (structural comparison) - relatively low, it is better to 
			// take control over Equals method and avoid boxing and gain
			// performance up to 5 times
			Console.WriteLine(str1.Equals(str2)); 
        }
    }
}
