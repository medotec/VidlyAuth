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
            _dbContext = new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            ICollection<Customer> customers = _dbContext.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            Customer customer = _dbContext.Customers.Include(c => c.MembershipType).Single(c => c.Id == id);
            return View(customer);
        }

        public ActionResult CustomerForm(int id)
        {
            if (id == 0)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _dbContext.MembershipTypes.ToHashSet(),
                    Customer = new Customer()
                };
                return View(viewModel);
            }
            else if (id > 0)
            {
                CustomerFormViewModel viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _dbContext.MembershipTypes.ToHashSet(),
                    Customer = _dbContext.Customers.Single(c => c.Id == id)
                };
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Customers");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                CustomerFormViewModel viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _dbContext.MembershipTypes.ToHashSet(),
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }
        }

        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = _dbContext.Customers.Find(id);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}