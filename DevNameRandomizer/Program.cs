using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DevRandomizer
{
	class Program
	{
		static void Main(string[] args)
		{
			var howManyPlayers = "------------------------ How Many Players? -------------------------";
			var whoIsPlaying = "------------------------ Who's Playin? -----------------------------";
			var randomizedOrder = "------------------------ Randomized Order -------------------------";

			Console.WriteLine(howManyPlayers);

			int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(whoIsPlaying);

			string[] playersArray = new string[numberOfPlayers];

			for (int i = 0; i < playersArray.Length; i++)
			{
				playersArray[i] = Console.ReadLine();
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine(randomizedOrder);


			var pList = new List<string>(playersArray);
			pList.Shuffle();

			var ballers = string.Join(", ", pList.GetRange(0, playersArray.Length));

			if (ballers.Contains("angel, matt"))
			{
				Console.WriteLine("Random Order: \n{0}", ballers);

				Console.WriteLine("uh oh, Matt is screwed. Try again.\n");
				var reList = new List<string>(playersArray);
				reList.Shuffle(); //TODO: better way to re-shuffle?
				var reRolledBallers = string.Join(", ", reList.GetRange(0, playersArray.Length));
				Console.WriteLine("Second Re-Roll Order: \n{0}", reRolledBallers);
			}
			else
			{
				Console.WriteLine("Random Order: \n{0}", ballers);
			}

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("------------------------ Press enter to exit ----------------------");
			Console.ReadLine();
		}
	}

	public static class ThreadSafeRandom
	{
		[ThreadStatic] private static Random Local;

		public static Random ThisThreadsRandom
		{
			get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
		}
	}

	static class MyExtensions
	{
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
