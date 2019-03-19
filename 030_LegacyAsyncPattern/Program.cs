using System;
using System.Threading;

namespace _030_LegacyAsyncPattern
{
	class Program
	{
		// not supported on core
		static void Main(string[] args)
		{
			Func<int, int, int> myDelegate = new Func<int, int, int>(HardSum);

			// Under the hood, it creates a ManualResetEvent 
			// and returns it wrapped into some IAsyncResult
			// implementation
			IAsyncResult asyncResult = myDelegate.BeginInvoke(2, 2, null, null);

			// awaits until sum method will finish it's work
			// uses resetEvent.WaitOne()
			int result = myDelegate.EndInvoke(asyncResult);

			Console.WriteLine("Ended invocation");
		}

		static int HardSum(int a, int b)
		{
			Console.WriteLine($"Executing sum. ThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
			Thread.Sleep(1000);
			return a + b;
		}
	}
}