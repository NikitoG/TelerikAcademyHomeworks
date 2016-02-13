using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TwitterLikeSystem.Data;
using TwitterLikeSystem.Models;

namespace TwitterLikeSystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminTwitsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AdminTwits
        public ActionResult Index()
        {
            var twits = db.Twits.Include(t => t.Author);
            return View(twits.ToList());
        }

        // GET: AdminTwits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // GET: AdminTwits/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: AdminTwits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Twits.Add(twit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", twit.AuthorId);
            return View(twit);
        }

        // GET: AdminTwits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", twit.AuthorId);
            return View(twit);
        }

        // POST: AdminTwits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,AuthorId")] Twit twit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Users, "Id", "FirstName", twit.AuthorId);
            return View(twit);
        }

        // GET: AdminTwits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twit twit = db.Twits.Find(id);
            if (twit == null)
            {
                return HttpNotFound();
            }
            return View(twit);
        }

        // POST: AdminTwits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Twit twit = db.Twits.Find(id);
            db.Twits.Remove(twit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
