using System.Security.Cryptography.X509Certificates;

namespace Thread_Example_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// start background thread
			Thread t = new Thread(() =>
			{
				Console.WriteLine("Thread is starting, press ENTER to continue..");
				Console.ReadLine();
			});
			t.IsBackground = false;
			t.Start();

			// main program thread ends here
		}
	}
}
