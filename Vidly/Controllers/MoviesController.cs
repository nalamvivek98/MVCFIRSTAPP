using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    //Controller class
    public class MoviesController : Controller
    {
        private MyDbContext _context = new MyDbContext();
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.GenreType).ToList();
            return View(movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewmodel = new MovieFormViewModel
            {
                GenreTypes = genreTypes

            };
            ViewBag.Formname = "New";
            return View("MovieForm",viewmodel);
        } 

        //Edit
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewmodel = new MovieFormViewModel
            {
                Movie=movie,
                GenreTypes = _context.GenreTypes.ToList()

            };
            ViewBag.Formname = "Edit";
            return View("MovieForm", viewmodel);

        }

        //Save
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {

                var MoviesInDb = _context.Movies.Single(m => m.Id == movie.Id);

                // Mapper.Map(customer, customerInDb);

                MoviesInDb.Name = movie.Name;
                MoviesInDb.Releasedate = movie.Releasedate;
                MoviesInDb.GenreType_Id = movie.GenreType_Id;
                MoviesInDb.No_in_stock = movie.No_in_stock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}