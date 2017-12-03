using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        private ApplicationDbContext _context;

        /// <summary>
        /// Defensive Code
        /// </summary>
        /// <param name="newRental"></param>
        /// <returns></returns>

        //[HttpPost]
        //public IHttpActionResult CreateNewResntals(Dtos.NewRentalDto newRental)
        //{

        //    if (newRental.MovieIds.Count == 0)
        //    {
        //        return BadRequest("No Movies has been given");

        //    }

        //    var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
        //    if (customer == null)
        //    {
        //        return BadRequest("CustomerId is not Valid");
        //    }

        //    var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
        //    if (movies.Count != newRental.MovieIds.Count)
        //    {
        //        return BadRequest("One or More Movies are invalid");
        //    }

        //    foreach (var movie in movies)
        //    {
        //        if (movie.NumberAvailable == 0)
        //        {
        //            return BadRequest("Movie is not avaliable");
        //        }
        //        movie.NumberAvailable--;
        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = movie,
        //            DateRented = DateTime.Now
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();
        //    return Ok();
        //}


        [HttpPost]
        public IHttpActionResult CreateNewResntals(Dtos.NewRentalDto newRental)
        {


            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
  

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
 
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not avaliable");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
