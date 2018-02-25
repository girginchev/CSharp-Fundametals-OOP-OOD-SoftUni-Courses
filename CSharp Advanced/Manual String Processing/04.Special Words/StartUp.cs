using System;
using System.Linq;

namespace _04.Special_Words
{
    public class StartUp
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine()
                .Split("()[]<>,-!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine()
                .Split("()[]<>,-!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var specialWord in specialWords)
            {
                Console.WriteLine($"{specialWord} - {text.Count(x => x == specialWord)}");
            }
        }
    }
}
