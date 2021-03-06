using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private MyDbContext _context;
        public CustomersController()
        {
            _context = new MyDbContext();
        }
    
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);


            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        //HTTP POST
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //Http Put
        [HttpPut]
        public Customer UpdateCustomer(int id,Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
            customerInDb.MembershipType_Id = customer.MembershipType_Id;
            customerInDb.Birthday = customer.Birthday;

            _context.SaveChanges();
            return customerInDb;
        }

        [HttpDelete]
        public Customer DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return (customerInDb);
        }
    }
}
