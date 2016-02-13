using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using TwitterLikeSystem.Models;

namespace TwitterLikeSystem.Controllers
{
    using System.Web.Mvc;
    using TwitterLikeSystem.Data;

    public class HomeController : BaseController
    {
        public HomeController(IUowData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTwit(TwitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var regex = new Regex(@"(?<=#)\w+");
                var matches = regex.Matches(model.Content);
                var user = Data.Users.All().FirstOrDefault(x => x.UserName == User.Identity.Name);
                var newTwit = new Twit { Content = model.Content, Author = user};

                var tags = new List<Tag>();
                foreach (Match tag in matches)
                {
                    newTwit.Content = newTwit.Content.Replace("#" + tag.Value, string.Format("<a href='Home/Tag/{0}'>#{0}</a>", tag.Value));
                    var existedTag = Data.Tags.All().FirstOrDefault(t => t.Content.ToLower() == tag.Value.ToLower());
                    if (existedTag != null)
                    {
                        newTwit.Tags.Add(existedTag);
                        Data.Twits.Add(newTwit);
                        existedTag.Twits.Add(newTwit);
                    }
                    else
                    {
                        var newTag = new Tag { Content = tag.Value.ToLower() };
                        Data.Tags.Add(newTag);
                        newTwit.Tags.Add(newTag);
                        Data.Twits.Add(newTwit);
                        newTag.Twits.Add(newTwit);
                    }
                    Data.SaveChanges();
                }

                Data.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View("Index", model);
        }

        public ActionResult Tag(string id)
        {
            var tag = Data.Tags
                .All()
                .Include("Twits")
                .FirstOrDefault(t => t.Content == id);
            

            if (tag == null)
            {
                this.RedirectToAction("Index");
            }

            return View(tag);
        }

        public ActionResult TwitsByUser()
        {
            var user = Data.Users.All().FirstOrDefault(x => x.UserName == User.Identity.Name);

            var userTwits = Data.Twits.All()
                .Where(t => t.AuthorId == user.Id)
                .ToList();

            return View(userTwits);
        }
    }
}