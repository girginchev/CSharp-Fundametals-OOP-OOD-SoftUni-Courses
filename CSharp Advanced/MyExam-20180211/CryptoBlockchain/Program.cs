namespace CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var linesNumber = int.Parse(Console.ReadLine());

            var allLines = new StringBuilder();

            for (int i = 0; i < linesNumber; i++)
            {
                var line = Console.ReadLine();
                allLines.Append(line);
            }
            

            var pattern = @"((?<bracket>{)|\[)[^}\]]*?([0-9]{3,})[^}\]]*?(?(bracket)}|])";

            var matches = Regex.Matches(allLines.ToString(), pattern);

            var messageAsStringNumbers = new List<int>();

            foreach (Match match in matches)
            {
                var numbers = match.Groups[2].Value;
                if (numbers.Length % 3 == 0)
                {
                    var currentLenght = match.Groups[0].Value.Length;
                    for (int i = 0; i < numbers.Length; i+=3)
                    {
                        var currentMessage = int.Parse(numbers[i].ToString() + numbers[i + 1] + numbers[i + 2]) - currentLenght;

                        messageAsStringNumbers.Add(currentMessage);
                    }
                }
            }
            var message = messageAsStringNumbers.Select(c => (char)c).ToArray();

            Console.WriteLine($"{string.Join("",message)}");
        }
    }
}
