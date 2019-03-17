using System;
using System.Threading;
using System.Threading.Tasks;

namespace _028_TaskCompletionSource
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			Delay(1000).GetAwaiter().OnCompleted(() => Console.WriteLine(Thread.CurrentThread.ManagedThreadId));
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			Console.ReadKey();
		}

		// using tcs we are not blocking any thread
		// this is kind of async version of Thread.Sleep
		// and everything is being executed on the same thread
		static Task Delay(int ms)
		{
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			var tcs = new TaskCompletionSource<object>();
			var timer = new System.Timers.Timer(ms) { AutoReset = false };
			timer.Elapsed += (s,e) => { timer.Dispose(); tcs.SetResult(null); };
			timer.Start();
			Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
			return tcs.Task;
		}
	}
}
