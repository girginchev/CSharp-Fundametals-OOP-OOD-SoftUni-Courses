using System;
using System.Text.RegularExpressions;

namespace _02.Vowel_Count
{
    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            Console.WriteLine($"Vowels: {Regex.Matches(text, @"[aeiouyAEIOUY]").Count}");
        }
    }
}
