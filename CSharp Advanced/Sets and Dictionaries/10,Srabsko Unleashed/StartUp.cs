using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10_Srabsko_Unleashed
{
    public class StartUp
    {
        public static void Main()
        {
            string input = String.Empty;
            var statistics = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "End")
            {
                var line = input.Split('@');

                if (!Regex.IsMatch(line[0], @"[A-Za-z]+ {1,3}$")
                    || !Regex.IsMatch(line[1], @"([A-Za-z]+ ){1,3}\d+ \d+$"))
                {
                    continue;
                }

                string name = line[0].Trim();

                var stack = new Stack<string>(line[1].Split());

                int ticketCount = int.Parse(stack.Pop());
                int ticketPrice = int.Parse(stack.Pop());

                string venue = string.Join(" ", stack.Reverse());

                if (!statistics.ContainsKey(venue))
                {
                    statistics[venue] = new Dictionary<string, long>();
                }

                if (!statistics[venue].ContainsKey(name))
                {
                    statistics[venue][name] = 0;
                }

                statistics[venue][name] += ticketCount * ticketPrice;

            }

            foreach (var venue in statistics)
            {
                Console.WriteLine(venue.Key);

                venue.Value
                    .OrderByDescending(x => x.Value)
                    .ToList()
                    .ForEach(x => Console.WriteLine($"#  {x.Key} -> {x.Value}"));
            }
        }
    }
}
