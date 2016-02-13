namespace TwitterLikeSystem.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;
    using TwitterLikeSystem.Models;

    public class DataContext : IdentityDbContext<ApplicationUser>
    {

        public DataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }


        public virtual IDbSet<Twit> Twits { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }
    }
}
