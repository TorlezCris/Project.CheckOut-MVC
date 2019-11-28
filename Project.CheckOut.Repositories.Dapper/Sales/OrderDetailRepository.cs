using Dapper;
using Project.CheckOut.Models;
using Project.CheckOut.Repositories.Sales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.CheckOut.Repositories.Dapper.Sales
{
    class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(string connectionString) : base(connectionString)
        {

        }

        public OrderDetail GetOrderDetailCustomized(int OrderId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<OrderDetail>("select OrderID, ProductId, UnitPrice, Quantity, Discount, TotalPay " +
                    "from OrderDetailTB " +
                    "where OrderID = @OrderId ", new { OrderId }).FirstOrDefault();
            }
        }

        public bool CreateCustomized(int orderId, int productId, int quantity, decimal price)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = productId,
                    UnitPrice = price,
                    Quantity = quantity,
                    Discount = 0,
                    TotalPay = quantity*price
                };
                var result = connection.Execute("insert into [OrderDetailTB]([OrderID], [ProductID], [UnitPrice], [Quantity], [Discount], [TotalPay])" +
                                        " VALUES(@OrderId, " +
                                        "@ProductId, " +
                                        "@UnitPrice, " +
                                        "@Quantity, " +
                                        "@Discount, " + 
                                        "@TotalPay)",
                                        new
                                        {
                                            orderDetail.OrderId,
                                            orderDetail.ProductId,
                                            orderDetail.UnitPrice,
                                            orderDetail.Quantity,
                                            orderDetail.Discount,
                                            orderDetail.TotalPay,
                                        });

                return result > 0 ? true : false;
            }
        }
    }
}