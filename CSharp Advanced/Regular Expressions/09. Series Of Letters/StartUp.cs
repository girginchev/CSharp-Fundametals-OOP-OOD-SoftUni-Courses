using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09.Series_Of_Letters
{
    public class StartUp
    {
        public static void Main()
        {
            string letters = Console.ReadLine();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (char ch in alphabet)
            {
                letters = Regex.Replace(letters, @"[" + ch + "]{2,}", ch.ToString());

            }

            Console.WriteLine(letters);
        }
    }
}
