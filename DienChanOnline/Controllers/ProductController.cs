using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienChanOnline.Models;
using System.Data.Entity;
using DienChanOnline.ViewModels;

namespace DienChanOnline.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public int PageSize = 24;

        public ProductController()
        {
            _context= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Product
        [Route("product/{categoryId}/{page?}")]
        public ActionResult Index(int categoryId, int page = 1)
        {
            var products = _context.Products.Include(p => p.Category).Where(c => c.CategoryId == categoryId).ToList();

            var model = new ProductViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count
                }
            };

            return View("List", model);
        }

        public ActionResult GetProductDetail(int categoryId, int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
                return RedirectToAction("Index", new {categoryId});

            return View("ProductDetail", product);
        }
    }
}