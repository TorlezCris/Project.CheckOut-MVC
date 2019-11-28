using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut_MVC.Service
{
    public interface IHomeService
    {

    }

    public class HomeService : IHomeService
    {
        public Order BuildRequest(int productId)
        {
            return new Order();
        }
    }
}