namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using(var dbContext = new StudentSystemContext())
            {
                var student = new Student
                {
                    FirstName = "Pesho",
                    LastName = "Peshov",
                    Number = 12345
                };

                var course = new Course
                {
                    Name = "DSA",
                    Description = "DSA",
                    Materials = new string[] {"Telerik Academy", "C# Intro"}
                };

                var homework = new Homework
                {
                    Content = "Let's do it",
                    TimeSend = DateTime.Now
                };

                student.Courses.Add(course);
                student.Homework.Add(homework);
                course.Homework.Add(homework);
                course.Students.Add(student);
                dbContext.Students.Add(student);
                dbContext.SaveChanges();

                Console.WriteLine("{0} is added!", dbContext.Students.FirstOrDefault().FullName); 
                Console.WriteLine("Ready!");
                Console.ReadLine();
            }
        }
    }
}
