using Project.CheckOut.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.UnitOfWork
{
    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        IProductRepository Product { get; }
    }
}