namespace TwitterLikeSystem.Data
{
    using System;
    using TwitterLikeSystem.Models;

    public interface IUowData : IDisposable
    {
        IRepository<Comment> Comments { get; }

        IRepository<Twit> Twits { get; }

        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
