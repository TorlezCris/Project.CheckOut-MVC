using Project.CheckOut.Repositories.Sales;
using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Repositories.Dapper.Sales
{
    public class CheckOutUnitOfWork : IUnitOfWork
    {
        public CheckOutUnitOfWork(string connectionString)
        {
            Order = new OrderRepository(connectionString);
            OrderDetail = new OrderDetailRepository(connectionString);
            Product = new ProductRepository(connectionString);
        }

        public IOrderRepository Order { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IProductRepository Product { get; private set; }
    }
}