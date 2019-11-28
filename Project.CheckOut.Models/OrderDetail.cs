using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal TotalPay { get; set; }
    }
}