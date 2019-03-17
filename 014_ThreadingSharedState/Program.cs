using System;
using System.Threading;

namespace _014_ThreadingSharedState
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = 0;

			var t1 = new Thread(x =>
			{
				a += 10;
			});

			var t2 = new Thread(x =>
			{
				a += 100;
			});

			t2.Start();
			t1.Start();
			Thread.Sleep(100);
			Console.WriteLine(a);
		}
	}
}
