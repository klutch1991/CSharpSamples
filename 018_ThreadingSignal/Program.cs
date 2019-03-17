using System;
using System.Threading;

namespace _018_ThreadingSignal
{
	class Program
	{
		static void Main(string[] args)
		{
			var signal = new ManualResetEvent(false);

			new Thread(() =>
			{
				Console.WriteLine("Waiting for signal");
				signal.WaitOne();
				signal.Dispose();
				Console.WriteLine("Got signal!");
			}).Start();

			Thread.Sleep(2000);
			signal.Set();
		}
	}
}
