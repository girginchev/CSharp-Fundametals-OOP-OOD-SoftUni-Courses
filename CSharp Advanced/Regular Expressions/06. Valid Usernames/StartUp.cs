using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.Valid_Usernames
{
    public class StartUp
    {
        public static void Main()
        {
            string text;

            while ((text = Console.ReadLine()) != "END")
            {

                Console.WriteLine(Regex.IsMatch(text, @"^[A-Za-z0-9_-]{3,16}$") ? "valid" : "invalid");
                    
            }
        }
    }
}
