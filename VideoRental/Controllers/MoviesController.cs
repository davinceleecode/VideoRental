﻿using System;
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
        // GET: Movies
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {


            if (!ModelState.IsValid)
            {
                var videModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", videModel);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var customerInDb = _context.Movies.Single(m => m.Id == movie.Id);
                customerInDb.Name = movie.Name;
                customerInDb.ReleaseDate = movie.ReleaseDate;
                customerInDb.NumberInStock = movie.NumberInStock;
                customerInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index", movies);

            return View("ReadOnlyIndex", movies);
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