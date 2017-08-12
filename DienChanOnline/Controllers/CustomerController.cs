using System;
using System.Linq;
using System.Web.Mvc;
using DienChanOnline.DAL;
using DienChanOnline.Managers.Helpers;
using DienChanOnline.Models;
using DienChanOnline.Models.Structs;
using System.Data.Entity;

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

                customerInDb.Address1 = customer.Address1;
                customerInDb.Address2 = customer.Address2;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.City = customer.City;
                customerInDb.Country = customer.Country;
                customerInDb.Email = customer.Email;
                customerInDb.FirstName = customer.FirstName;
                customerInDb.Job = customer.Job;
                customerInDb.LastName = customer.LastName;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                customerInDb.Purpose = customer.Purpose;
                customerInDb.State = customer.State;
                customerInDb.Zip = customer.Zip;
            }

            _context.SaveChanges();

            if(User.IsInRole(RoleName.Administrator))
            return RedirectToAction("Index", "Customer");

            return View("FormResult");
        }

        [Authorize(Roles = RoleName.Administrator)]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);

            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        [Route("customer/newform/{lang?}/{formId?}")]
        public ActionResult New(string lang = "en", int formId = 0)
        {
            var customer = new Customer();

            var form = new Form
            {
                Title = "Customer Information",
                TitleVn = "Thông Tin Khách Hàng",
                TitleFr = "Informations Importants"
            };

            if (formId != 0)
            {
                form = _context.Forms.SingleOrDefault(f => f.Id == formId);

                if (form == null)
                    return HttpNotFound();
            }

            customer.Form = form;

            customer.FormId = form.Id;

            customer.Language = lang;

            switch (lang)
            {
                case Language.Vietnamese:
                    customer.Title = form.TitleVn;
                    break;
                case Language.French:
                    customer.Title = form.TitleFr;
                    break;
                default:
                    customer.Title = form.Title;
                    break;
            }

            return View("Form", customer);
        }

        [Authorize(Roles = RoleName.Administrator)]
        [Route("customer/editform/{lang?}/{id?}")]
        public ActionResult Edit(string lang = "en", int id = 0)
        {
            var customer = _context.Customers.Include(x => x.Form).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            switch (lang)
            {
                case Language.Vietnamese:
                    customer.Title = customer.Form.TitleVn;
                    break;
                case Language.French:
                    customer.Title = customer.Form.TitleFr;
                    break;
                default:
                    customer.Title = customer.Form.Title;
                    break;
            }

            return View("Form", customer);
        }
    }
}