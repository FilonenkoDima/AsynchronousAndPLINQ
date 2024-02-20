namespace WorkWithTasks
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// start new task
			var task = Task.Factory.StartNew(() =>
			{
				Thread.Sleep(2000);
				Console.WriteLine("Hello world!");

                // thread information
                Console.WriteLine("Is background thread: {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Is threadpool thread: {0}", Thread.CurrentThread.IsThreadPoolThread);

				// throw exception
				throw new InvalidOperationException("Something went wrong");

            }, TaskCreationOptions.LongRunning);

			// wait for task to complete
			task.Wait();
		}
	}
}
