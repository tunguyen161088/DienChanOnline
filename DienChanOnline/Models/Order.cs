using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DienChanOnline.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ShipName { get; set; }

        public string Email { get; set; }

        public string ShipAddress1 { get; set; }

        public string ShipAddress2 { get; set; }

        public string ShipCity { get; set; }

        public string ShipState { get; set; }

        public string ShipZip { get; set; }

        public string ShipCountry { get; set; }

        public string ShipPhone { get; set; }

        public string BillName { get; set; }

        public string BillAddress1 { get; set; }

        public string BillAddress2 { get; set; }

        public string BillCity { get; set; }

        public string BillState { get; set; }

        public string BillZip { get; set; }

        public string BillCountry { get; set; }

        public string BillPhone { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Tax { get; set; }

        public decimal ShippingPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotal { get; set; }

        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

    public class OrderShipment
    {
        public int Id { get; set; }

        public string ShippingStatus { get; set; }

        public string Carrier { get; set; }

        public string Service { get; set; }

        public decimal Price { get; set; }

        public DateTime ShipDate { get; set; }

        public string TrackingNumber { get; set; }
    }

    public class OrderShipmentDetail
    {
        public int Id { get; set; }

        
    }
}