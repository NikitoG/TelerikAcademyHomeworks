using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesSite.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public int MaleId { get; set; }

        [ForeignKey("MaleId")]
        public virtual Actor Male { get; set; }

        public int FemaleId { get; set; }

        [ForeignKey("FemaleId")]
        public virtual Actor Female { get; set; }
    }
}
