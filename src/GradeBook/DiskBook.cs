using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {

        public override event GradeAddedDelegate GradeAdded;

        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {

            if (grade <= 100 && grade >= 0)
            {
                using (var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                }

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
                var result = new Statistics();

                using (var reader = File.OpenText($"{Name}.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }

                return result;
        }
    }
}