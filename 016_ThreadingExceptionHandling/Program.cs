using System;
using System.Threading;

namespace _016_ThreadingExceptionHandling
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				new Thread(Do).Start();
			}
			catch (NullReferenceException)
			{
				// NEVER FALL HERE!
				Console.WriteLine("Exception handled in main");
			}
		}

		static void Do()
		{
			try
			{
				throw null;
			}
			catch (NullReferenceException)
			{
				Console.WriteLine("Excetion handled in do");
				throw;
			}
		}
	}
}
