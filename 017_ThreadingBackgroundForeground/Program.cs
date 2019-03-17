using System;
using System.Threading;

namespace _017_ThreadingBackgroundForeground
{
	class Program
	{
		static void Main(string[] args)
		{
			// by default all explicitly created threads are foreground threads
			// if thread is marked as backround, MAIN thread won't wait until it ends
			var background = new Thread(x => Do(10)) { IsBackground = true };
			var foreground = new Thread(x => Do(5));
			background.Start();
			foreground.Start();
		}

		private static void Do(int cycles)
		{
			for (int i = 0; i < cycles; i++)
			{
				Thread.Sleep(10);
				Console.WriteLine(i);
			}
		}
	}
}
