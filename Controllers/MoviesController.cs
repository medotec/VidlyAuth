using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuth.Models;

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
            IEnumerable<Movie> movies = _dbContext.Movies.Include(m => m.Genre).ToList();
            return View();
        }
    }
}