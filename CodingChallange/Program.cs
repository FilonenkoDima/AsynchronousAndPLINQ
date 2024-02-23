using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
	public class Exercise
	{
		private static string[] Map(string sentence)
		{
			return sentence.Split();
		}

		private static string ConvertString(string s)
		{
			string word = s.ToLower();
			StringBuilder sb = new StringBuilder();
			sb.Append(word.Substring(1)).Append(word[0]).Append("ay");
			return sb.ToString();
		}

		private static string[] Process(string[] words)
		{
			for (int i = 0; i < words.Length - 1; i++)
			{
				int index = i;
				Task.Factory.StartNew(() => words[index] = ConvertString(words[index]),
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

		// TODO: complete this method - return the sentence as pig latin
		public static string PigLatin(string sentence)
		{
			if (sentence == null) return null;
			if (sentence == "" || sentence == " ") return string.Empty;

			var res = Task<string[]>.Factory.StartNew(() => Map(sentence))
			.ContinueWith<string[]>(t => Process(t.Result))
			.ContinueWith<string>(t => Reduce(t.Result));

			return res.Result;
		}


		public static void Main(string[] args)
		{
			Console.WriteLine(PigLatin("The Quick Brown Fox Jumped Over The Lazy Dog"));
		}
	}
}
