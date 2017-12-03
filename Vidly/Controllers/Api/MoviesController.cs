using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();


        }

        public IHttpActionResult GetMovies(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == Id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<Movie, Dtos.MovieDto>(movie));
        }

        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.Include(x => x.Genre).ToList().Select(AutoMapper.Mapper.Map<Models.Movie, Dtos.MovieDto>);

            return Ok(movies);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, Dtos.MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDB = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDB == null)
            {
                return NotFound();
            }
            Mapper.Map<Dtos.MovieDto, Models.Movie>(movie, movieInDB);
            _context.SaveChanges();
            return Ok(Mapper.Map<Movie, Dtos.MovieDto>(movieInDB));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movie = Mapper.Map<MovieDto, Movie>(MovieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            MovieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), MovieDto);
        }

        //[HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDB = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movieInDB == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieInDB);

            _context.SaveChanges();
            return Ok();
        }
    }
}
