using System;
using System.Collections.Generic;
using System.Linq;
namespace SoftUni_Party
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            var guests = new SortedSet<string>();

            while ((input = Console.ReadLine()) != "PARTY")
            {
                guests.Add(input);
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(guests.Count);
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}
