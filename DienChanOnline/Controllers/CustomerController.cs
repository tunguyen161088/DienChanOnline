using System;
using System.Linq;
using System.Web.Mvc;
using DienChanOnline.DAL;
using DienChanOnline.Managers.Helpers;
using DienChanOnline.Models;
using DienChanOnline.Models.Structs;

namespace DienChanOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(int? id)
        {
            var customers = _context.Customers.ToList();
            if (id != null)
            {
                customers = customers.Where(c => c.FormId == id).ToList();
            }

            return View("List", customers);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", customer);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                _context.Customers.Remove(customerInDb);

                _context.Customers.Add(customer);
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult New()
        {
            var customer = new Customer();

            return View("Form", customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View("Form", customer);
        }
    }
}