using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuth.Models;

namespace VidlyAuth.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();
            return View();
        }
    }
}