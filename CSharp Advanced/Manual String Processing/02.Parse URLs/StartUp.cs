using System;

namespace _02.Parse_URLs
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (!input.Contains("://"))
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            int index = input.IndexOf("://", StringComparison.InvariantCulture);

            string protocol = input.Substring(0, index);

            input = input.Substring(index + 3);

            if (!input.Contains("/") || input.Contains("://") || input.Contains("//") || input.Contains(":") || input.Contains(":/"))
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            index = input.IndexOf("/");

            string server = input.Substring(0, index);
            string resources = input.Substring(index + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");

        }
    }
}
