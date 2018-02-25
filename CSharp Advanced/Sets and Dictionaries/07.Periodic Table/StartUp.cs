using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.Periodic_Table
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var uniqueChemicals = new SortedSet<string>();

            for (var i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split();
                foreach (var s in input)
                {
                    uniqueChemicals.Add(s);
                }
            }


            Console.WriteLine(string.Join(" ", uniqueChemicals));
        }
    }
}
