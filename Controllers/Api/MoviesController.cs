using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using VidlyAuth.Dtos;
using VidlyAuth.Models;

namespace VidlyAuth.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        // GET: /api/movies/
        public IHttpActionResult GetMovies()
        {
            IEnumerable<Movie> movies = _dbContext.Movies.Include(m => m.Genre).ToHashSet();
            IEnumerable<MovieDto> movieDtos = new List<MovieDto>();
            foreach (Movie movie in movies)
            {
                MovieDto movieDto = movie;
                movieDtos.Append(movieDto);
            }
            return Ok(movieDtos);
        }

        //GET: /api/movies/{id}
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            MovieDto movieDto = movie;

            return Ok(movieDto);
        }

        //POST: /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            Movie movie = movieDto;
            if (Equals(!ModelState.IsValid))
            {
                return BadRequest();
            }
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(Request.RequestUri + "/" + movieDto.Id, movieDto);
        }

        //PUT: /api/movies/{id}
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            Movie movieInDb = _dbContext.Movies.Find(id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            movieInDb = movieDto;

            _dbContext.Entry(movieInDb).State = EntityState.Modified;
            _dbContext.SaveChanges();
            
            movieDto = movieInDb;
            
            return Ok(movieDto);
        }

        //DELETE: /api/movies/{id}
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = _dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            
            return Ok();
        }

    }
}
