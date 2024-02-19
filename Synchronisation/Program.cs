namespace Synchronisation
{
	internal class Program
	{
		// shared field for work result
		public static int result = 0;

		// lock handle for shared result
		private static object lockHandle = new object();

		// event wait handles
		public static EventWaitHandle readyForResult = new AutoResetEvent(false);
		public static EventWaitHandle setResult = new AutoResetEvent(false);

		public static void DoWork()
		{
			while (true)
			{
				int i = result;

				// simulate long calculation
				Thread.Sleep(1);

				// wait until main loop is ready to receive result 
				readyForResult.WaitOne();

				// return result
				lock(lockHandle)
				{
					result = i + 1;
				}

				// tell main loop that we set the result
				setResult.Set();
			}
		}
		static void Main(string[] args)
		{
			// start the thread
			Thread t = new Thread(DoWork);
			t.Start();

			// collect result every 10 milliseconds
			for(int i = 0; i< 100; i++)
			{
				// tell thread that we're ready to receive the result 
				readyForResult.Set();

				// wait until thread has set the result 
				setResult.WaitOne();

				lock(lockHandle)
				{
                    Console.WriteLine(result);
                }

				// simulate other work
				Thread.Sleep(10);
			}

		}
	}
}
