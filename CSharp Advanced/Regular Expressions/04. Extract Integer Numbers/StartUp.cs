using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Extract_Integer_Numbers
{
    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            Regex.Matches(text, @"\d+")
                .Cast<Match>()
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
