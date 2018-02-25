using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Academy_Graduation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var students = new SortedDictionary<string, double[]>();

            for (var i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                var grades = Console.ReadLine()
                    .Trim()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                if (!students.ContainsKey(name))
                {
                    students[name] = new double[grades.Length];
                    students[name] = grades;
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
