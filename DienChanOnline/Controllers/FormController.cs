using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.WebSockets;
using DienChanOnline.Models;
using DienChanOnline.Models.Structs;

namespace DienChanOnline.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class FormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Form
        public ActionResult Index()
        {
            var forms = _context.Forms.ToList();

            return View("List", forms);
        }

        public ActionResult New()
        {
            var form = new Form();

            ViewBag.Header = "Tạo Mới Form";

            return View("Form", form);
        }

        public ActionResult Edit(int id)
        {
            var form = _context.Forms.SingleOrDefault(f => f.Id == id);

            if (form == null)
                return HttpNotFound();

            ViewBag.Heade = "Chỉnh Sửa Form";

            return View("Form", form);
        }

        [HttpPost]
        public ActionResult Save(Form form)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", form);
            }

            if (form.Id == 0)
                _context.Forms.Add(form);
            else
            {
                var formInDb = _context.Forms.Single(f => f.Id == form.Id);

                formInDb.Name = form.Name;
                formInDb.Title = form.Title;
                formInDb.TitleFr = form.TitleFr;
                formInDb.TitleVn = form.TitleVn;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Form");
        }

        public ActionResult Delete(int id)
        {
            var form = _context.Forms.SingleOrDefault(f => f.Id == id);

            if (form == null)
                return HttpNotFound();

            _context.Forms.Remove(form);

            _context.SaveChanges();

            return RedirectToAction("Index", "Form");
        }
    }
}