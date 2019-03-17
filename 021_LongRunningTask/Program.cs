using System;
using System.Threading;
using System.Threading.Tasks;

namespace _021_LongRunningTask
{
	class Program
	{
		static void Main(string[] args)
		{
			// This is how you can run task
			// in non-threadpool thread
			// this should be done when you nedd to run 
			// a plenty of long-running operations or
			// blocking operations to maintain
			// your threadpool to be "clean"
			// but there are more effective ways 
			// like async (for io-intensive and blocking tasks) 
			// or provider-consumer queue (for cpu-consuming tasks)
			var longRunningTask = Task.Factory.StartNew(() =>
			{
				Console.WriteLine(Thread.CurrentThread.IsBackground);
				Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
			}, TaskCreationOptions.LongRunning);
			longRunningTask.Wait();

			// more 
		}
	}
}
