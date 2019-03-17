using System;
using System.Threading;
using System.Threading.Tasks;

namespace _019_ThreadPool
{
	class Program
	{
		static void Main(string[] args)
		{
			// running code in threads from thread pool
			// theese threads are always background
			// and have IsThreadPoolThread property set to true
			// more of, threads from thread pool are
			// kind of being created in advance, so no
			// need to consume additional resources
			// to creae a thread when making work in 
			// a thread pool thread!

			// .NET 4.0+
			Task.Run(() => SayHelloFrom("Threadpool"));

			// < .Net4.0
			ThreadPool.QueueUserWorkItem(x => SayHelloFrom("Threadpool"));

			Thread.Sleep(1000);
		}

		static void SayHelloFrom(string where)
		{
			Console.WriteLine($@"
				Hello from {@where}! 
				IsBackgroundThread: {Thread.CurrentThread.IsBackground}; 
				IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
		}
	}
}
