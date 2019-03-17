using System;
using System.Threading;
using System.Threading.Tasks;

namespace _024_TaskExecuteAsMethod
{
	class Program
	{
		static void Main(string[] args)
		{
			DoSomethingAsync1().GetAwaiter().GetResult();
		}

		static async Task DoSomethingAsync1()
		{
			// won't wait for exception, since task is not awaited
			var t = DoSomethingAsync2();
			Console.WriteLine("Do something 1");
		}

		static async Task DoSomethingAsync2()
		{
			await Task.Delay(0);
			throw null;
		}
	}
}
