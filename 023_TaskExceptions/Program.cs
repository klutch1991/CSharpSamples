using System;
using System.Linq;
using System.Threading.Tasks;

namespace _023_TaskExceptions
{
	class Program
	{
		static void Main(string[] args)
		{
			// unlikely than threads, tasks can easily generate exceptions,
			// which can be handled in calling code blocks

			Task<int> t1 = Task.Run(() => {
				throw null;
				return 1;
			});

			Task<int> t2 = Task.Run(() => {
				throw null;
				return 2;
			});

			try
			{
				// if just access Result property, AggregateException is being genereted
				var result = t1.Result; // or t.Wait();
			}
			catch (AggregateException e)
			{
				Console.WriteLine(e.InnerExceptions.First().Message);
			}

			try
			{
				// if call GetResult on awaiter, real Exception is being generated
				var awaiter = t2.GetAwaiter();
				var result = awaiter.GetResult();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
