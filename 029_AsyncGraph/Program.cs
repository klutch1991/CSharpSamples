using System;
using System.Threading.Tasks;

namespace _029_AsyncGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			Go().GetAwaiter().GetResult();
		}

		static async Task Go()
		{
			var task = PrintAnswerToLife();
			await task;
			Console.WriteLine("Done");
		}

		static async Task PrintAnswerToLife()
		{
			var task = GetAnswerToLife();
			int answer = await task;
			Console.WriteLine(answer);
		}

		static async Task<int> GetAnswerToLife()
		{
			var task = Task.Delay(5000);
			await task;
			int answer = 21 * 2;
			return answer;
		}
	}
}
