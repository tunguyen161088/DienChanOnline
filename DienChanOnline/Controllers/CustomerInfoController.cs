using System;
using System.Web.Mvc;
using DienChanOnline.DAL;
using DienChanOnline.Managers.Helpers;
using DienChanOnline.Models;

namespace DienChanOnline.Controllers
{
    public class CustomerInfoController : Controller
    {

        private readonly ICustomerInfoQuery _customerInfoQuery;
        private readonly IFormTypeQuery _formTypeQuery;

        public CustomerInfoController(ICustomerInfoQuery customerInfoQuery, IFormTypeQuery formTypeQuery)
        {
            _customerInfoQuery = customerInfoQuery;
            _formTypeQuery = formTypeQuery;
        }
        
        public ActionResult Index(string id = "", string lang = "us", string sr= "us", int cid = 0)
        {
            if (cid != 0)
            {
                var cust = _customerInfoQuery.GetCustomerById(cid);

                ViewBag.Disable = "true";

                return View(cust);
            }

            var form = _formTypeQuery.GetFormTypeByGuid(id)?? new FormType
            {
                Title = "Customer Information",
                TitleVn = "Thông Tin Khách Hàng",
                TitleFr = "Information Client"
            };

            var model = new CustomerInfo
            {
                BirthDay = DateTime.Today,
                Title =  form.Title,
                FormGuidInfo =  id
            };

            if (lang == "fr")
            {
                var model2 = new CustomerInfoFrance
                {
                    BirthDay = DateTime.Today,
                    Title = form.TitleFr,
                    FormGuidInfo = id
                };

                return View("Index_France", model2);
            }

            if (lang == "vn")
            {
                var model3 = new CustomerInfoVietnam
                {
                    BirthDay = DateTime.Today,
                    Title =  form.TitleVn,
                    FormGuidInfo = id
                };

                return View("Index_Vietnam", model3);
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GetCustomerInfo(CustomerInfo model = null)
        {
            if (!ModelState.IsValid) return View("Index");

            try
            {
                _customerInfoQuery.SaveCustomerInfo(model);

                ViewBag.Message = "Your information has been submitted successfully! Thank you!";

                return View("GetCustomerInfoResult");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GetCustomerInfoFrance(CustomerInfoFrance model = null)
        {
            if (!ModelState.IsValid) return View("Index");

            try
            {
                _customerInfoQuery.SaveCustomerInfo(model);

                ViewBag.Message = "Vos informations ont été envoyées avec succès! Je vous remercie!";

                return View("GetCustomerInfoResult");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GetCustomerInfoVietnam(CustomerInfoVietnam model = null)
        {
            if (!ModelState.IsValid) return View("Index");

            try
            {
                _customerInfoQuery.SaveCustomerInfo(model);

                ViewBag.Message = "Thông tin đã được gửi đi thành công! Xin cảm ơn!";

                return View("GetCustomerInfoResult");
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult DeleteCustomer(int id, Guid guidInfo)
        {
            var customer = _customerInfoQuery.GetCustomerById(id);

            if (customer != null)
            {
                _customerInfoQuery.DeleteCustomer(customer);

                TempData["message"] = $"Customer {customer.FirstName} has been deleted!";
            }

            return RedirectToAction("GetCustomerList", new {guidInfo});
        }

        public ActionResult GetCustomerList(Guid guidInfo)
        {
            var model = _customerInfoQuery.GetCustomersByForm(guidInfo);

            return View(model);
        }
    }
}