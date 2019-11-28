using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool state { get; set; }
    }
}