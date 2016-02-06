using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSite.Models
{
    public class Actor
    {
        private ICollection<Movie> maleMovies;
        private ICollection<Movie> femaleMovies;

        public Actor()
        {
            this.maleMovies = new HashSet<Movie>();
            this.femaleMovies = new HashSet<Movie>();
        } 

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }

        public bool Male { get; set; }

        public virtual ICollection<Movie> MaleMovies { get { return this.maleMovies; } set { this.maleMovies = value; } }
        public virtual ICollection<Movie> FemaleMovies { get { return this.femaleMovies; } set { this.femaleMovies = value; } }
    }
}
