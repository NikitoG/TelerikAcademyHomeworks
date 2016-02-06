using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MoviesSite.Models;

namespace MoviesSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Actor> Actors { get; set; }
        
        public IDbSet<Movie> Movies { get; set; }
        
        public IDbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                    .HasRequired(m => m.Male)
                    .WithMany(t => t.MaleMovies)
                    .HasForeignKey(m => m.MaleId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                    .HasRequired(m => m.Female)
                    .WithMany(t => t.FemaleMovies)
                    .HasForeignKey(m => m.FemaleId)
                    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
