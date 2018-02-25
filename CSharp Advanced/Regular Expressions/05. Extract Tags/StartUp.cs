using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.Extract_Tags
{
    public class StartUp
    {
        public static void Main()
        {
            string text;

            while ((text = Console.ReadLine()) != "END")
            {
                Regex.Matches(text, @"<\/?.*?>")
                    .Cast<Match>()
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
    }
}
