using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Sets_Of_Elements
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lenOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 1; i <= lenOfSets.Sum(); i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (i <= lenOfSets[0])
                {
                    firstSet.Add(num);
                    continue;
                }

                secondSet.Add(num);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
