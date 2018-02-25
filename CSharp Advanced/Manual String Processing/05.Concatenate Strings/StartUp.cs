using System;
using System.Text;

namespace _05.Concatenate_Strings
{
    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                string line = Console.ReadLine();

                sb.Append($"{line} ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
