using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MoviesSite.Models;

namespace MoviesSite.Web.Models
{
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieViewModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Director = movie.Director,
                    Studio = movie.Studio,
                    MaleId = movie.MaleId,
                    Male = movie.Male,
                    FemaleId = movie.FemaleId,
                    Female = movie.Female
                };
            }
        }
        
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public int MaleId { get; set; }
        
        public virtual Actor Male { get; set; }

        public int FemaleId { get; set; }
        
        public virtual Actor Female { get; set; }
    }
}