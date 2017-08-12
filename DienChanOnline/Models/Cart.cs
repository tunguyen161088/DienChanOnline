using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DienChanOnline.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();
        public void AddItem(Product product, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(l => l.Product.Id ==
                                          product.Id);
        }
        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            _lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines => _lineCollection;
    }
}