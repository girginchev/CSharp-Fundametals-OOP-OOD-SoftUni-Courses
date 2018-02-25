using System;
using System.Text.RegularExpressions;

namespace _03.Non_Digit_Count
{
    public class StartUp
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            Console.WriteLine($"Non-digits: {Regex.Matches(text, @"\D").Count}");
        }
    }
}
