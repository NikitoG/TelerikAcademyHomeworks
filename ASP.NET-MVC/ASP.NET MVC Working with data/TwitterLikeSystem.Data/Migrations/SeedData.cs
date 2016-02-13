using System.Text;

namespace TwitterLikeSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using TwitterLikeSystem.Models;

    public class SeedData
    {
        private const string LoremIpsum =
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

        private Random random = new Random();

        private PasswordHasher PasswordHasher = new PasswordHasher();


        public List<ApplicationUser> Users;

        public List<Twit> Twits;

        public List<Tag> Tags;

        public List<Comment> Comments;

        public SeedData()
        {
            this.Users = this.InitUsers();
            this.Tags = this.InitTags();
            this.Twits = this.InitTwits();
            this.Comments = this.InitComments();
        }

        private List<Comment> InitComments()
        {
            var comments = new List<Comment>();

            for (int i = 0; i < 20; i++)
            {
                comments.Add(new Comment { Content = LoremIpsum.Substring(random.Next(0, LoremIpsum.Length /2), random.Next(0, LoremIpsum.Length / 2)) });
            }

            return comments;
        }

        private List<Tag> InitTags()
        {
            var tags = new List<Tag>();
            tags.Add(new Tag { Content = "#Telerik" });
            tags.Add(new Tag { Content = "#Akademy" });
            tags.Add(new Tag { Content = "#fail" });
            tags.Add(new Tag { Content = "#MVC" });
            tags.Add(new Tag { Content = "#Node" });

            return tags;
        }

        private List<Twit> InitTwits()
        {
            var twits = new List<Twit>();
            for (int i = 0; i < 20; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < random.Next(1, 3); j++)
                {
                    sb.Append(LoremIpsum.Substring(random.Next(0, LoremIpsum.Length / 2), random.Next(0, LoremIpsum.Length / 2)));
                    sb.Append(" ");
                    sb.Append(this.Tags[random.Next(0, this.Tags.Count)].Content);
                    sb.Append(" ");
                    sb.Append(LoremIpsum.Substring(random.Next(0, LoremIpsum.Length / 2), random.Next(0, LoremIpsum.Length / 2)));
                }
                twits.Add(new Twit { Content = sb.ToString()});
            }

            return twits;
        }

        private List<ApplicationUser> InitUsers()
        {
            var users = new List<ApplicationUser>();

            for (int i = 1; i <= 5; i++)
            {
                var user = new ApplicationUser()
                {
                    UserName = string.Format("user{0}@site.com", i),
                    Email = string.Format("user{0}@site.com", i),
                    PasswordHash = this.PasswordHasher.HashPassword(string.Format("user{0}", i)),
                    FirstName = string.Format("FirstName{0}", i),
                    LastName = string.Format("LastName{0}", i)
                };

                users.Add(user);
            }

            return users;
        }
    }
}
