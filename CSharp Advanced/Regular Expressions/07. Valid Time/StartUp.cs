using System;
using System.Text.RegularExpressions;

namespace _07.Valid_Time
{
    public class StartUp
    {
        public static void Main()
        {
            string text;

            while ((text = Console.ReadLine()) != "END")
            {

                Console.WriteLine(Regex.IsMatch(text, @"^[01][0-9]:[0-5][0-9]:[0-5][0-9]\s*(AM|PM)$") ? "valid" : "invalid");

            }
        }
    }
}
