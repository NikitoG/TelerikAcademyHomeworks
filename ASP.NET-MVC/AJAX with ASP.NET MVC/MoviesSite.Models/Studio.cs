using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSite.Models
{
    public class Studio
    {
        private ICollection<Movie> movies;

        public Studio()
        {
            this.movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Movie> Movies { get { return this.movies; } set { this.movies = value; } } 
    }
}
