using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut_MVC.Model
{
    public class DetailOfOrder
    {
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal TotalPay { get; set; }
    }
}