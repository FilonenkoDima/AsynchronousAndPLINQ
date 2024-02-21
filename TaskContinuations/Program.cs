using System.Text;

namespace TaskContinuations
{
	internal class Program
	{
		private static string ReverseString(string s)
		{
			Thread.Sleep(1000);
			StringBuilder sb = new StringBuilder();
			for (int i = s.Length - 1;  i >= 0; i--)
				sb.Append(s[i]);
			return sb.ToString();
		}

		private static string[] Map (string sentence)
		{
			return sentence.Split();
		}

		private static string[] Process(string[] words)
		{
			for(int i = 0; i < words.Length; i++)
			{
				int index = i;
				Task.Factory.StartNew(() =>
					words[index] = ReverseString(words[index]), 
					TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);
			}
			return words;
		}

		private static string Reduce(string[] words)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string word in words)
			{
				sb.Append(word).Append(" ");
			}
			return sb.ToString();
		}

		static void Main(string[] args)
		{
			string sentence = "the quick brown fox jumped over the lazy dog";

			// set up map-reduce process
			var task = Task<string[]>.Factory.StartNew(() => Map(sentence))
				.ContinueWith<string[]>(t => Process(t.Result))
				.ContinueWith<string>(t => Reduce(t.Result));

            // display result
            Console.WriteLine("Result: {0}", task.Result);
        }
	}
}
