using System;
using System.Collections.Generic;
using System.Linq;
namespace _09.Phonebook
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            var phoneBook = new Dictionary<string, string>();

            while ((command = Console.ReadLine()) != "search")
            {
                var lines = command.Split('-');

                string name = lines[0];
                string number = lines[1];

                if (!phoneBook.ContainsKey(name))
                {
                    phoneBook[name] = string.Empty;
                }

                phoneBook[name] = number;
            }

            while ((command = Console.ReadLine()) != "stop")
            {
                string name = command;

                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }

                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
        }
    }
}
