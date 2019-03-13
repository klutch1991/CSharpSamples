using System;
using System.Threading;

namespace _012_DisposeAndFinalize
{
	class Program
	{
		static void Main(string[] args)
		{
			var instance = new Disposable();

			using (instance)
			{
				instance.DoWork();
			}

			try
			{
				instance.DoWork();
			}
			catch (ObjectDisposedException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	class Disposable : IDisposable
	{
		private bool _disposed;

		public void Dispose()
		{
			Dispose(true); // true indicates that diapose called explicitly
			//suppress running finalizer, cuz client explicitly called Dispose
			GC.SuppressFinalize(this);
		}

		~Disposable()
		{
			// SHOULD NOT HAVE EXCEPTIONS CUZ IT PREVENTS OTHER FINALIZERS TO RUN
			Dispose(false); // false indicated that dispose called from finalizer
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing) // e.g. if disposing
			{
				Console.WriteLine("Dispose child objects. (Dispose called explicitly)");
			}

			// e.g. if finalizing or disposing
			Console.WriteLine("Release unmanaged resources of it's own. (Dispose or finalize called)");

			_disposed = true;
		}

		public void DoWork()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("Instance has been disposed already!");
			}

			Console.WriteLine("Working...");
		}
	}
}
