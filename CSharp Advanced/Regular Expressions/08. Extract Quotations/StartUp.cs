using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08.Extract_Quotations
{
    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            Regex.Matches(text, @"('(.*?)')|(""(.*?)"")")
                .Cast<Match>()
                .ToList()
                .ForEach(x => Console.WriteLine(x.Groups[2].Success ? x.Groups[2] : x.Groups[4]));
        }
    }
}
