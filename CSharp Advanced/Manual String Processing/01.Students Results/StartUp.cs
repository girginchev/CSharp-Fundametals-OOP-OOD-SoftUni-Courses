using System;

namespace _01.Students_Results
{
    public class StartUp
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            string row = "Name      |   CAdv|   COOP| AdvOOP|Average|";

            Console.WriteLine(row);
            int index = row.IndexOf("|");

            for (int i = 0; i < num; i++)
            {
                var line = Console.ReadLine()
                    .Split(" -,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string name = line[0];

                double firstResult = double.Parse(line[1]);
                double secondtResult = double.Parse(line[2]);
                double thirdResult = double.Parse(line[3]);

                double averageResult = (firstResult + secondtResult + thirdResult) / 3;

                Console.WriteLine($"{name}{new string(' ', index - name.Length)}|   {firstResult:f2}|   {secondtResult:f2}|   {thirdResult:f2}| {averageResult:f4}|");
            }
        }
    }
}
