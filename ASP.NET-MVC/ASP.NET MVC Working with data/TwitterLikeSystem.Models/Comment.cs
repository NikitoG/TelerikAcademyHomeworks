using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLikeSystem.Models
{

    public class Comment
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public string Content { get; set; }

        public int TwitId { get; set; }

        public virtual Twit Twit { get; set; }
    }
}
