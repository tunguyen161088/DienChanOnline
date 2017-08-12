using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DienChanOnline.Models;

namespace DienChanOnline.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}