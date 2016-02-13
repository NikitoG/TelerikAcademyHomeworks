using System.Collections.Generic;

namespace TwitterLikeSystem.Models
{
    public class Twit
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

        public Twit()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }


        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
