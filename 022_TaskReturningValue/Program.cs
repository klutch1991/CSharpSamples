using System;
using System.Linq;
using System.Threading.Tasks;

namespace _022_TaskReturningValue
{
	class Program
	{
		static void Main(string[] args)
		{
			// Task<TResult> previously was named Future<TResult> in CTP
			Task<int> primeNumberTask = Task.Run(() => 
				Enumerable.Range(2,3000000).Count(n => 
					Enumerable.Range(2, (int)Math.Sqrt(n)-1).All(i => n%i > 0)));
			Console.WriteLine("Task running");
			// accessing Result property of a task causes current thread to
			// wait for task's result untis it is done
			Console.WriteLine(primeNumberTask.IsCompleted);
			// waiting for result
			Console.WriteLine($"Answer is {primeNumberTask.Result}");
			// task completed
			Console.WriteLine(primeNumberTask.IsCompleted);
		}
	}
}
