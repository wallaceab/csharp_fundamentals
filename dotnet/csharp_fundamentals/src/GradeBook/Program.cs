using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
    
            List<double> grades = new List<double>();
            grades.Add(12.7);
            grades.Add(10.3);
            grades.Add(6.11);
            grades.Add(6.11);
            grades.Add(56.1);

            var result = 0.0;

            foreach (var number in grades)
            {
                result += number;
            }

            result /= grades.Count;
            System.Console.WriteLine($"The average grade is {result:N1}");

            if (args.Length > 0)
            {
                Console.WriteLine($"Hello, {args[0]}!");
            }
            else
            {
                System.Console.WriteLine("Hello!");
            }
        }
    }
}
 