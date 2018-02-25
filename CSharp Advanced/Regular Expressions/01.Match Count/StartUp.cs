using System;
using System.Text.RegularExpressions;

namespace _01.Match_Count
{
    public class StartUp
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            var regex = Regex.Matches(text, word);

            Console.WriteLine(regex.Count);
        }
    }
}
