using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [System.Runtime.InteropServices.Guid("3B4E9E46-F6C5-4E32-A64A-27FE43D3FCFE")]
    public class CustomersController : Controller
    {
        private MyDbContext _context;
        
        
        public CustomersController()
        {
            _context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        // GET: Customers

        public ViewResult New()
        {
            var membershipTypes = (IEnumerable<MembershipType>)_context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewmodel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

              if(!ModelState.IsValid)
               {
                   var viewmodel = new CustomerFormViewModel
                   {
                       Customer = customer,
                       MembershipTypes = _context.MembershipTypes.ToList()

                   };
                   return View("CustomerForm", viewmodel);
             }
             
            if (customer.Id==0)
            _context.Customers.Add(customer);
            else
            {

                var customerInDb = _context.Customers.Single(m => m.Id == customer.Id);

               // Mapper.Map(customer, customerInDb);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
                customerInDb.MembershipType_Id= customerInDb.MembershipType_Id;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
              return  HttpNotFound();

            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("CustomerForm", viewmodel);

        }
        public ViewResult Index()
        {
            var customers =_context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}
