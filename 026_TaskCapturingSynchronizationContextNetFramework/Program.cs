using System;
using System.Threading;
using System.Windows.Forms;

namespace _026_SynchronizationContextNetFramework
{
	class Form1 : Form
	{
		public Form1()
		{
		}
	}

	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// проверим наличие контекста синхронизации
			var context = SynchronizationContext.Current;
			if (context == null)
				MessageBox.Show("No context for this thread");
			else
				MessageBox.Show("We got a context");

			// создадим форму
			Form form = new Form1();

			// проверим наличие контекста синхронизации еще раз
			context = SynchronizationContext.Current;

			if (context == null)
				MessageBox.Show("No context for this thread");
			else
				MessageBox.Show("We got a context");

			if (context == null)
				MessageBox.Show("No context for this thread");

			Application.Run(new Form1());
		}
	}
}
