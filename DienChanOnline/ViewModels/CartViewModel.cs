using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DienChanOnline.Models;

namespace DienChanOnline.ViewModels
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}