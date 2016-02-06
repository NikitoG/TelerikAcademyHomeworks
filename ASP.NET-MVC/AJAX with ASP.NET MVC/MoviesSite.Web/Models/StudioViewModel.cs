using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MoviesSite.Models;

namespace MoviesSite.Web.Models
{
    public class StudioViewModel
    {
        public static Expression<Func<Studio, StudioViewModel>> FromStudio
        {
            get
            {
                return studio => new StudioViewModel
                {
                    Id = studio.Id,
                    Name = studio.Name,
                    Address = studio.Address,
                    Movies = studio.Movies
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}