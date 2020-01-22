using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuth.Models;
using VidlyAuth.ViewModels;

namespace VidlyAuth.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }
        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            ICollection<Customer> customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Index",customers);
            }
            else
            {
                return View("ReadOnlyIndex", customers);
            }
        }

        public ActionResult Details(int id)
        {
            Customer customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult CustomerForm(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Customers");
            }
            if (id == 0)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel(_dbContext.MembershipTypes.ToHashSet());
                return View(viewModel);
            }
            if (id > 0)
            {
                CustomerFormViewModel viewModel =
                    new CustomerFormViewModel(_dbContext.Customers.Single(c => c.Id == id),
                        _dbContext.MembershipTypes.ToHashSet());
                return View(viewModel);
            }
            return RedirectToAction("Index", "Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult SaveCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == 0)
                {
                    _dbContext.Customers.Add(customer);
                }
                else if (customer.Id > 0)
                {
                    _dbContext.Entry(customer).State = EntityState.Modified;
                }
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                CustomerFormViewModel viewModel =
                    new CustomerFormViewModel(customer, _dbContext.MembershipTypes.ToHashSet());
                return View("CustomerForm", viewModel);
            }
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = _dbContext.Customers.Find(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}