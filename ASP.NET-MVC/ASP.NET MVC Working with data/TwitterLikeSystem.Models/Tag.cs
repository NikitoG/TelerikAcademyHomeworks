using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLikeSystem.Models
{
    public class Tag
    {
        private ICollection<Twit> twits;

        public Tag()
        {
            this.twits = new HashSet<Twit>();
        } 

        public int Id { get; set; }

        public string Content { get; set; }

        public ICollection<Twit> Twits
        {
            get { return this.twits; }
            set { this.twits = value; }
        } 
    }
}
