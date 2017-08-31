using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienChanOnline.Models;
using DienChanOnline.ViewModels;

namespace DienChanOnline.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: AddToCart
        public ActionResult Index(Cart cart, string returnUrl)
        {
            var model = new CartViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int id, string
            returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string
            returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ActionResult Checkout(Cart cart)
        {
            var model = new ShippingDetails
            {
                Cart = cart
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
                return View(shippingDetails);

            //do something

            cart.Clear();

            return View("OrderSummary");
        }
    }
}