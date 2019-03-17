using System;
using System.Threading;

namespace _013_ThreadingYield
{
	class Program
	{
		static void Main(string[] args)
		{
			var t1 = new Thread(x => Do('1'));
			var t2 = new Thread(x => Do('2'));
			t1.Start();
			t2.Start();
			Thread.Sleep(1000);
		}

		static void Do(char letter)
		{
			for (int i = 0; i < 10; i++)
			{
				// try comment this if statement code and compare output
				if (i == 5)
				{
					//Thread.Sleep(0); // delegate code execution to another thread, independent of processor
					Thread.Yield(); // delegate code execution to another thread, ready to work on current processor
				}
				Console.WriteLine(letter);
			}
		}
	}
}
