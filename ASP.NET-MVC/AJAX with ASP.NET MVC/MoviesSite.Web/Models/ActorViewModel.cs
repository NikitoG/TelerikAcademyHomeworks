using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MoviesSite.Models;

namespace MoviesSite.Web.Models
{
    public class ActorViewModel
    {
        public static Expression<Func<Actor, ActorViewModel>> FromActor
        {
            get
            {
                return actor => new ActorViewModel
                {
                    Id = actor.Id,
                    FirstName = actor.FirstName,
                    LastName = actor.LastName,
                    Age = actor.Age,
                    Male = actor.Male,
                    MaleMovies = actor.MaleMovies,
                    FemaleMovies = actor.FemaleMovies
                };
            }
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        public bool Male { get; set; }

        public virtual ICollection<Movie> MaleMovies { get; set; }
        public virtual ICollection<Movie> FemaleMovies { get; set; }
    }
}