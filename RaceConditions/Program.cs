namespace RaceConditions
{
	internal class Program
	{
		public static int i = 0;

		public static void DoWork()
		{
			for ( i = 0; i < 5; i++)
			{
				Console.Write("*");
			}
		}
		static void Main(string[] args)
		{
			// start thread to display 5 stars
			Thread t = new Thread(DoWork);
			t.Start();

			// display 5 additional stars
			DoWork();
		}
	}
}
