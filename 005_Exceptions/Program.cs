using System;

namespace _005_Exceptions
{
	class Unmanaged : IDisposable
	{
		public void Dispose()
		{
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			// always try avoiding try/catch block due to it requires more CPU time that checking invalid data
			// before calling some method

			try
			{
				throw null; // same as throw new NullReferenceException();
			}
			catch (Exception e)
			{
				throw e; // no call stack
				throw; // with call satck
			}
			finally
			{
				Console.WriteLine("finally");
				// always invoked (after try or after any catch)
				// only way not to call finally is infinite loop or process accidentally killed
			}

			using (new Unmanaged())
			{
			}

			// using is equivalent to try-finally with dispose in finally
		}
	}
}
