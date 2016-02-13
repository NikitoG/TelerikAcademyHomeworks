using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TwitterLikeSystem.Models;

namespace TwitterLikeSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<TwitterLikeSystem.Data.DataContext>
    {
        private PasswordHasher PasswordHasher = new PasswordHasher();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterLikeSystem.Data.DataContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var role = new IdentityRole { Name = "Administrator" };
            roleManager.Create(role);

            var admin = new ApplicationUser
            {
                UserName = "admin@site.com",
                Email = "admin@site.com",
                PasswordHash = this.PasswordHasher.HashPassword("admin"),
                FirstName = "Admin",
                LastName = "Peshov",
            };
            userManager.Create(admin);
            userManager.AddToRole(admin.Id, "Administrator");

            context.SaveChanges();

            var seed = new SeedData();

            foreach (var user in seed.Users)
            {
                userManager.Create(user);
            }

            context.SaveChanges();
            
            foreach (var twit in seed.Twits)
            {
                var user = context.Users.OrderBy(u => new Guid()).FirstOrDefault();
                if (user != null)
                {
                    twit.AuthorId = user.Id;
                }
                
                var regex = new Regex(@"(?<=#)\w+");
                var matches = regex.Matches(twit.Content);

                foreach (Match tag in matches)
                {
                    twit.Content = twit.Content.Replace("#" + tag.Value, string.Format("<a href='Home/Tag/{0}'>#{0}</a>", tag.Value));
                    var existedTag = context.Tags.FirstOrDefault(t => t.Content.ToLower() == tag.Value.ToLower());
                    if (existedTag != null)
                    {
                        twit.Tags.Add(existedTag);
                        context.Twits.Add(twit);
                        existedTag.Twits.Add(twit);
                    }
                    else
                    { 
                        var newTag = new Tag {Content = tag.Value.ToLower()};
                        context.Tags.Add(newTag);
                        twit.Tags.Add(newTag);
                        context.Twits.Add(twit);
                        newTag.Twits.Add(twit);
                    }
                    context.SaveChanges();
                }
            }


            foreach (var comment in seed.Comments)
            {
                var user = context.Users.OrderBy(u => new Guid()).FirstOrDefault();
                var twit = context.Twits.OrderBy(u => new Guid()).FirstOrDefault();

                comment.AuthorId = user.Id;
                comment.TwitId = twit.Id;

                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }
    }
}
