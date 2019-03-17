using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace _0001_WebApiDeadlockExampleNetFramework.Controllers
{
	public class SomeService
	{
		public async Task DoSomeJobAsync()
		{
			// remove CA(false) to cause deadlock
			await Task.Delay(200).ConfigureAwait(false);
			Thread.Sleep(100);
		}
	}

	public class DefaultController : ApiController
	{
		public IHttpActionResult Get()
		{
			var service = new SomeService();
			service.DoSomeJobAsync().Wait();

			return Ok("done");
		}
	}
}