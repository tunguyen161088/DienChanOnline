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
        public ActionResult Index(string returnUrl)
        {
            var model = new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        public RedirectToRouteResult AddToCart(int id, string
            returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int id, string
            returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}