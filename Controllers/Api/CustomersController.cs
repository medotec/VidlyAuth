using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.DynamicData;
using System.Web.Http;
using VidlyAuth.Dtos;
using VidlyAuth.Models;
using WebGrease.Css.Extensions;

namespace VidlyAuth.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = ApplicationDbContext.Create();
        }

        //GET: /api/customers
        public IHttpActionResult GetCustomers()
        {
            IEnumerable<Customer> customers = _dbContext.Customers.Include(c => c.MembershipType).ToHashSet();
            IEnumerable<CustomerDto> customerDtos = new HashSet<CustomerDto>();
            foreach (Customer customer in customers)
            {
                CustomerDto customerDto = customer;
                customerDtos.Append(customerDto);
            }
            return Ok(customerDtos);
        }

        //GET: /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            CustomerDto customerDto = customer;

            return Ok(customerDto);
        }

        //POST: /api/customers/
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Customer customer = customerDto;
            _dbContext.Customers.Add(customer);
            
            _dbContext.SaveChanges();
            customerDto.Id = customer.Id;

            return Created(Request.RequestUri + "/" + customer.Id, customerDto);
        }

        //PUT: /api/customers/{id}
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Customer customerInDb = _dbContext.Customers.Find(id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            customerInDb = customerDto;

            _dbContext.Entry(customerInDb).State = EntityState.Modified;
            _dbContext.SaveChanges();

            customerDto = customerInDb;

            return Ok(customerDto);
        }

        //DELETE: /api/customers/{id}
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customerInDb = _dbContext.Customers.Find(id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
