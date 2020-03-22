using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.ViewModels;
using System.Data.Entity;

namespace VideoRental.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(g => g.Id == Id);
            return View(movie);
        }
        #region Example
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek", Id = 1 };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);
        }

        [Route("Movies/released/{month:regex(\\d{2}):range(1,12)}/{day:regex(\\d{2}):range(1,31)}/{year:regex(\\d{4})}")]
        public ActionResult ByReleaseDate(int year, int month, int day)
        {
            return Content(month + "/" + day + "/" + year);
        }
        #endregion
    }
}