﻿namespace Thread_Example_2
{
	internal class Program
	{
		private const int REPETITIONS = 100;

		public static void DoWork()
		{
			for (int i = 0; i < REPETITIONS; i++)
			{
                Console.Write('B');
            }
		}
		static void Main(string[] args)
		{
			// start 10 new threads
			for(int i = 0;i < 9; i++)
			{
				Thread t = new Thread(DoWork);
				t.Name = "Thread" + i.ToString();
				t.Start();
			}

			// line for breakpoint 
			int dummy = 123;
		}
	}
}
