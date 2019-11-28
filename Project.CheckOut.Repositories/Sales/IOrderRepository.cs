using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Repositories.Sales
{
    public interface IOrderRepository : IRepository<Order>
    {
        Tuple<string, int> CreateCustomized(int productId);
        List<Order> GetOrdersCustomized(int userId);
    }
}