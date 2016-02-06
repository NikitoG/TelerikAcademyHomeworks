using MoviesSite.Models;

namespace MoviesSite.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesSite.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesSite.Data.ApplicationDbContext context)
        {
            context.Studios.AddOrUpdate(
              s => s.Name,
              new Studio { Name = "Pesho Pictures", Address = "Bollywood" },
              new Studio { Name = "Gosho Mayer", Address = "Kaspichan" },
              new Studio { Name = "Stamat Fox", Address = "Boyana" }
            );

            context.Actors.AddOrUpdate(
                a => a.FirstName,
                new Actor { FirstName = "Pesho", LastName = "Peshov", Male = true, Age = 28 },
                new Actor { FirstName = "Gosho", LastName = "Goshov", Male = true, Age = 18 },
                new Actor { FirstName = "Mariika", LastName = "MAriikova", Male = false, Age = 19 },
                new Actor { FirstName = "Stamatka", LastName = "Stamatkova", Male = true, Age = 22 }
                );
                
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "Batman", StudioId = 1, Director = "Mincho Maistora", Year = 2022, FemaleId = 3, MaleId = 1},
                new Movie { Title = "Robin", StudioId = 2, Director = "Mincho Maistora", Year = 2002, FemaleId = 4, MaleId = 1 },
                new Movie { Title = "Spiderman", StudioId = 3, Director = "Gosho BashMaistora", Year = 2052, FemaleId = 3, MaleId = 2 }
                );

        }
    }
}
