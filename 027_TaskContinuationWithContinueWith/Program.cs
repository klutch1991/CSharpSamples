using System;
using System.Linq;
using System.Threading.Tasks;

namespace _027_TaskContinuationWithContinueWith
{
	class Program
	{
		static void Main(string[] args)
		{
			Task<int> primeNumberTask = new Task<int>(() =>
				Enumerable.Range(2, 3000000).Count(n =>
					Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
			
			primeNumberTask.ContinueWith(t =>
			{
				Console.WriteLine(t.Result);
			});

			primeNumberTask.RunSynchronously();

			Console.ReadKey();
		}
	}
}
