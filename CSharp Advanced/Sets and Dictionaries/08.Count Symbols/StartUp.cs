using System;
using System.Collections.Generic;
using System.Linq;
namespace _08.Count_Symbols
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var occurrences = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!occurrences.ContainsKey(ch))
                {
                    occurrences[ch] = 0;
                }

                occurrences[ch]++;
            }

            foreach (var kvp in occurrences)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
