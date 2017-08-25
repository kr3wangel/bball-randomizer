using System;
using System.Collections.Generic;
using System.Linq;

namespace DevRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("------------------------ How Many Players? -------------------------");

			int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("------------------------ Who's Playin? -------------------------");

			string[] playersArray = new string[numberOfPlayers];

			for (int i = 0; i < playersArray.Length; i++)
			{
				playersArray[i] = Console.ReadLine();
			}


			List<string> list = playersArray.ToList();


			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("------------------------ Randomized Order -------------------------");


			string playerList = string.Join(", ", playersArray);

			if (playerList.Contains("angel, matt"))
			{
				Console.WriteLine("uh oh, Matt is screwed");
			}

			Console.WriteLine(playerList);

			// maybe use random numbers to pick out of the array indexes to build the random list?
			//var random = new Random().Next(1, 10).ToString();
			//Console.WriteLine("random number= {0}", random);

			Console.ReadLine();
		}
    }
}
