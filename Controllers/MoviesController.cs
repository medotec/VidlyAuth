using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using VidlyAuth.Models;
using VidlyAuth.ViewModels;

namespace VidlyAuth.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Movie
        public ActionResult Index()
        {
            ICollection<Movie> movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie movie = _dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult MovieForm(int id)
        {
            if (id == 0)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel
                {
                    Genres = _dbContext.Genres.ToHashSet(),
                    Movie = new Movie()
                };
                return View(viewModel);
            }
            else if(id > 0)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel
                {
                    Genres = _dbContext.Genres.ToHashSet(),
                    Movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id)
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.Id == 0)
                {
                    _dbContext.Movies.Add(movie);
                    
                }
                else if(movie.Id > 0)
                {
                    _dbContext.Entry(movie).State = EntityState.Modified;
                }

                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                MovieFormViewModel viewModel = new MovieFormViewModel
                {
                    Genres = _dbContext.Genres.ToHashSet(),
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }
        }
    }
}