using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesSite.Data;
using MoviesSite.Models;
using MoviesSite.Web.Models;

namespace MoviesSite.Web.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult GetAll()
        {
            var movies = db.Movies.Include(m => m.Female).Include(m => m.Male).Include(m => m.Studio)
                .AsQueryable().Select(MovieViewModel.FromMovie);
            return PartialView("_AllMoviesPartial", movies);
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsMoviePartial", movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.FemaleId = new SelectList(db.Actors, "Id", "FirstName");
            ViewBag.MaleId = new SelectList(db.Actors, "Id", "FirstName");
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name");
            return PartialView("_CreateMoviePartial");
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Year,Director,StudioId,MaleId,FemaleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }

            ViewBag.FemaleId = new SelectList(db.Actors, "Id", "FirstName", movie.FemaleId);
            ViewBag.MaleId = new SelectList(db.Actors, "Id", "FirstName", movie.MaleId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return PartialView("_CreateMoviePartial", movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.FemaleId = new SelectList(db.Actors, "Id", "FirstName", movie.FemaleId);
            ViewBag.MaleId = new SelectList(db.Actors, "Id", "FirstName", movie.MaleId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return PartialView("_EditMoviePartial", movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Year,Director,StudioId,MaleId,FemaleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            ViewBag.FemaleId = new SelectList(db.Actors, "Id", "FirstName", movie.FemaleId);
            ViewBag.MaleId = new SelectList(db.Actors, "Id", "FirstName", movie.MaleId);
            ViewBag.StudioId = new SelectList(db.Studios, "Id", "Name", movie.StudioId);
            return PartialView("_EditMoviePartial", movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteMoviePartial", movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("GetAll");
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
