using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InformationalSite.Areas.User.Models;
using InformationalSite.Data;
using InformationalSite.Models;
using PagedList;

namespace InformationalSite.Areas.User.Controllers
{
    public class ArticleController : Controller
    {
        // GET: User/Article
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();

            var topArticles = context.Articles.OrderByDescending(a => a.Rating).Take(10).ToList();

            return View(topArticles);
        }

        public ActionResult All(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var context = new ApplicationDbContext();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.RateSortParm = sortOrder == "Rate" ? "rate_desc" : "Rate";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var articles = context.Articles.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(a => a.Header.Contains(searchString)
                                       || a.Content.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    articles = articles.OrderByDescending(a => a.Header);
                    break;
                case "name":
                    articles = articles.OrderBy(a => a.Header);
                    break;
                case "Rate":
                    articles = articles.OrderBy(a => a.Rating);
                    break;
                case "rate_desc":
                    articles = articles.OrderByDescending(a => a.Rating);
                    break;
                default:  // Name ascending 
                    articles = articles.OrderBy(a => a.Rating);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }
    }
}