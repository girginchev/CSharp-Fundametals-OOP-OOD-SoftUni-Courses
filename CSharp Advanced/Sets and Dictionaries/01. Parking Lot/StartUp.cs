using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.Parking_Lot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            var carNumbers = new SortedSet<string>();

            while ((command = Console.ReadLine()) != "END")
            {
                var parameters = command.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (parameters[0] == "IN")
                {
                    carNumbers.Add(parameters[1]);
                }

                if (parameters[0] == "OUT")
                {
                    carNumbers.Remove(parameters[1]);
                }
            }

            Console.WriteLine(carNumbers.Count == 0 ? "Parking Lot is Empty" : string.Join(Environment.NewLine, carNumbers));
        }
    }
}
