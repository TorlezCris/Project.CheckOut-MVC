using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public int iIdUsuario { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; }
    }
}