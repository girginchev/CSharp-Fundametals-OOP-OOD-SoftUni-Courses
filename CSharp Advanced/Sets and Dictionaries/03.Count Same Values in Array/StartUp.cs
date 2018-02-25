using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.Count_Same_Values_in_Array
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var dict = new SortedDictionary<decimal, int>();

            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
