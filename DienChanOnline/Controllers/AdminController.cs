using System;
using System.Web.Mvc;
using DienChanOnline.DAL;
using DienChanOnline.Managers;
using DienChanOnline.Models;
using DienChanOnline.Models.Structs;

namespace DienChanOnline.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class AdminController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFormType()
        {
            //var model = _formTypeQuery.GetFormTypes();

            //return View(model);

            return null;
        }

        public ActionResult CreateFormType()
        {
            return View("EditFormType", new Form());
        }

        public ActionResult EditFormType(string guidInfo)
        {
            //var selectedType = _formTypeQuery.GetFormTypeByGuid(guidInfo);

            //return View(selectedType);

            return null;
        }

        [HttpPost]
        public ActionResult EditFormType(Form form)
        {
            if (!ModelState.IsValid) return View(form);

            form.Name = form.Name.ToTitleCase();

            form.TitleFr = form.TitleFr.ToTitleCase();

            form.TitleVn = string.IsNullOrEmpty(form.TitleVn) ? form.TitleFr.Translate("fr|vi") : form.TitleVn.ToTitleCase();

            form.Title = string.IsNullOrEmpty(form.Title) ? form.TitleFr.Translate("fr|en") : form.Title.ToTitleCase();

            //form.GuidInfo = string.IsNullOrEmpty(form.GuidInfo) ? Guid.NewGuid().ToString() : form.GuidInfo; 

            //form.Link = $"http://dienchanus.com/Customer?id={form.GuidInfo}";
            //form.CustomersLink = $"http://dienchanus.com/Customer/GetCustomerList?guidInfo={form.GuidInfo}";

            //_formTypeQuery.InsertFormType(form);

            TempData["message"] = $"Form {form.Name} has been saved!";

            return RedirectToAction("GetFormType");
        }

        public ActionResult DeleteFormType(string guidInfo)
        {
            //var selectedType = _formTypeQuery.GetFormTypeByGuid(guidInfo);

            //if (selectedType != null)
            //{
            //    _formTypeQuery.RemoveFormType(selectedType);

            //    TempData["message"] = $"Form {selectedType.Name} has been saved!";
            //}

            return RedirectToAction("GetFormType");
        }
    }
}