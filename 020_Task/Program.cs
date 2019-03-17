using System;
using System.Threading.Tasks;

namespace _020_Task
{
	class Program
	{
		static void Main(string[] args)
		{
			
			// Thread is low-level way to make
			// something work in parallel, but
			// creating a thread manually always consumes
			// large amount of resources.
			// Since that, a good approach to achieve
			// parallel execution of some code is usage
			// of Tasks. Task is high-level abstraction
			// and represents a parallel operation, that
			// may or may not be using actual thread. Task
			// usually using thread pool to make work. It
			// really fits good to achieve asynchronous behavior.

			// example of creating a "hot" task, that'd be executed immediately:

			// NET 4.5
			Task.Run(() => Console.WriteLine("Hello!"));

			// NET 4.0 (same thing but run is shorter!)
			Task.Factory.StartNew(() => Console.WriteLine("Hello!"));

			// cold task, should be started
			var t = new Task(() => Console.WriteLine("cold task"));
			t.Start();
			Console.WriteLine($"cold task is completed: {t.IsCompleted}");
			t.Wait(); // same as Join() on a thread

			Console.ReadKey();
		}
	}
}
