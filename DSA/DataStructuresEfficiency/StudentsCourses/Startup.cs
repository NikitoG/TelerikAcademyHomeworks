namespace StudentsCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Wintellect.PowerCollections;

    public class Startup
    {
        public static void Main()
        {
            var filePath = @"..\..\Files\students.txt";
            var students = new SortedDictionary<string, OrderedBag<Student>>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (line.Length != 3)
                    {
                        Console.WriteLine("Input line should have first and last name and name of course.");
                        continue;
                    }

                    var student = new Student()
                    {
                        FirstName = line[0].Trim(),
                        LastName = line[1].Trim(),
                        Course = line[2].Trim()
                    };

                    if (!students.ContainsKey(student.Course))
                    {
                        students[student.Course] = new OrderedBag<Student>();
                    }

                    students[student.Course].Add(student);
                }
            }

            foreach (var course in students)
            {
                Console.Write("{0}: ", course.Key);
                Console.WriteLine(string.Join(", ", course.Value));
            }
        }
    }
}
