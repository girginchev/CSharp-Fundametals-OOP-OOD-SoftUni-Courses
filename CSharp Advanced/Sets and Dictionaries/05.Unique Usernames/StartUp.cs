using System;
using System.Collections.Generic;
using System.Linq;
namespace _05.Unique_Usernames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (var i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
