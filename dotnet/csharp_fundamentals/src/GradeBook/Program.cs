using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Wallace's Grade Book");
            book.GradeAdded += OnGradeAdded;
           
            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"For the book with name {book.Name}");
            System.Console.WriteLine($"The lowest greade is {stats.Low}");
            System.Console.WriteLine($"The highest greade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");


        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade o 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
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
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}
