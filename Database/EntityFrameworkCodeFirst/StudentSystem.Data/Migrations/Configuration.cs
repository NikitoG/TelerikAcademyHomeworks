namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext context)
        {
            context.Students.AddOrUpdate(
              p => p.FirstName,
              new Student { FirstName = "Andrew", LastName =  "Peters" },
              new Student { FirstName = "Brice", LastName = "Lambson" },
              new Student { FirstName = "Rowan", LastName = "Miller" }
            );
            
        }
    }
}
