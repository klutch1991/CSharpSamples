using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _025_TaskContinuationWithAwaiter
{
	class Program
	{
		static void Main(string[] args)
		{
			Task<int> primeNumberTask = Task.Run(() =>
				Enumerable.Range(2, 3000000).Count(n =>
					Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

			var awaiter = primeNumberTask.GetAwaiter();

			awaiter.OnCompleted(() =>
			{
				int result = awaiter.GetResult();
				Console.WriteLine(result);
			});

			Console.ReadKey();
		}
	}
}
