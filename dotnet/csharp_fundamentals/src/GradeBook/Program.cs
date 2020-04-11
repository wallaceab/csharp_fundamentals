using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            var book = new Book("Wallace's Grade Book");

            var done = false;

            while (!done)
            {
                System.Console.WriteLine("Enter a grade o 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    done = true;
                    continue;
                }
                else
                {
                    try
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("**");
                    }
                }
            }

            var stats = book.GetStatistics();

            System.Console.WriteLine($"The lowest greade is {stats.Low}");
            System.Console.WriteLine($"The highest greade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");


        }
    }
}
