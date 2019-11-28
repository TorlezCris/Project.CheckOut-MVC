using Project.CheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CheckOut.Repositories.Sales
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        bool CreateCustomized(int orderId, int productId, int quantity, decimal price);
        OrderDetail GetOrderDetailCustomized(int OrderId);
    }
}
