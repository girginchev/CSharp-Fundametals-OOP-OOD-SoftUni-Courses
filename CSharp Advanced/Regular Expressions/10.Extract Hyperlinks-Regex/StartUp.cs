using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _07.Extract_Hyperlinks
{
    public class StartUp
    {
        public static void Main()
        {
            string lines = string.Empty;
            var sb = new StringBuilder();
            while ((lines = Console.ReadLine()) != "END")
            {
                sb.Append(lines + " ");
            }

            string input = sb.ToString().Trim();

            var matches = Regex.Matches(input, @"(?:<a\s+.*?href\s*=\s*((?<part>""(?<catch>.+?)"")|(?<part>'(?<catch>.+?)')|(?<catch>[^""'].+?(?:\s+|>))).*?>)");

            matches
                .Cast<Match>()
                .ToList()
                .ForEach(x => Console.WriteLine(x.Groups["catch"].Value.TrimEnd('>')));
        }
    }
}

