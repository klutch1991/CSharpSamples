using System;
using System.Threading;

namespace _015_ThreadingVariableCapture
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				// adding temp variable prevents access to modified closure
				// the reason of the problem is that for-loop references
				// the same variable all the time while loop iterates
				int temp = i; // THIS VARIABLE IS LOCAL FOR EACH LOOP ITERATION, SO IT PREVENTS PROBLEMS (VALUE TYPE IS COPIED, NOT REFERENCED)
				new Thread(() => Console.Write(temp)).Start();
			}
		}
	}
}
