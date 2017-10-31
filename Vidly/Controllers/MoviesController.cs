using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Vidly.Models.Movie { Id = 1, Name = "Shark" };

            //ViewData["Movie"] = movie;
            //ViewBag.RandomMovie = movie;
            //return View();
            //return Content(movie.Name);

            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, SortBy = "name" });

            var customers = new List<Models.Customer>
          {
              new Models.Customer{ Name= "Customer 1"},
              new Models.Customer{ Name= "Customer 1"}
          };
            var viewmodel = new ViewModels.RandomMovieViewModel
            {
                Customers = customers,
                movies = movie

            };

            return View(viewmodel);
            //return View();
        }
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Single(x => x.Id == Id);
            var Genres = _context.Genre.ToList();
            var viewmodel = new ViewModels.MovieViewModel
            {
                Genres = Genres,
                Movie = movie
            };
            return View("MovieForm", viewmodel);

            //return Content("Id = " + Id);
        }

        public ActionResult New()
        {
            var Genres = _context.Genre.ToList();
            var viewmodel = new ViewModels.MovieViewModel
            {
                Movie = new Movie
                {
                    //ReleaseDate = new DateTime(),
                    //NumberInStock = "0"
                },
                Genres = Genres
            };
            return View("MovieForm", viewmodel);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModels.MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //if (pageIndex.HasValue)
            //{
            //    pageIndex = 1;
            //}

            //if (string.IsNullOrWhiteSpace(sortBy))
            //{
            //    sortBy = "Name";
            //}

            ////   return Content("PageIndex = {0} SortBy= {1}");
            //return View();


            //var movies = GetMovies();
            var movies = _context.Movies.Include(x => x.Genre).ToList();

            return View(movies);
        }


        public ActionResult Details(int Id)
        {
            //var customer = GetCustomers().SingleOrDefault(x => x.Id == Id);
            var movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == Id);

            if (movie == null)
            {
                return new HttpNotFoundResult();
            }
            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
           {
               new Movie { Id = 1, Name = "Sherk" },
               new Movie { Id = 2, Name = "Wall-e" }
           };
        }


        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}