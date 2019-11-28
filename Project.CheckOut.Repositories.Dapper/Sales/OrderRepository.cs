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
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }

        public Tuple<string, int> CreateCustomized(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var response = NumberOrder(DateTime.UtcNow, connection);
                string numberOfOrder = response.Item1;
                var order = new Order {
                    OrderNumber = numberOfOrder,
                    iIdUsuario = 1,
                    CreatedDate = DateTime.UtcNow,
                    ConfirmDate = null,
                    ShippedDate = null,
                    Status = "Nuevo"
                }; 
                var result = connection.Execute("insert into [OrderTB](OrderNumber, iIdUsuario, CreatedDate, ConfirmDate, ShippedDate, Status)" +
                                        " VALUES(@OrderNumber, "+
                                        "@iIdUsuario, " +
                                        "@CreatedDate, " +
                                        "@ConfirmDate, " +
                                        "@ShippedDate, " +
                                        "@Status)",
                                        new
                                        {
                                            order.OrderNumber,
                                            order.iIdUsuario,
                                            order.CreatedDate,
                                            order.ConfirmDate,
                                            order.ShippedDate,
                                            order.Status
                                        });
                
                if (result == 0)
                    return new Tuple<string, int>("", 0);

                return new Tuple<string, int>(response.Item1, response.Item2);
            }
        }


        Tuple<string, int> NumberOrder(DateTime Date, SqlConnection connection)
        {
            int orderId = connection.Query<int>("select Max(OrderID) " +
                    "from OrderTB ").FirstOrDefault();

            string number = (orderId+1).ToString("D3");
            string orderNumber = Date.Day.ToString() + Date.Month.ToString() + Date.Year.ToString() + number;

            return new Tuple<string, int>(orderNumber, orderId+1);
        }

        public List<Order> GetOrdersCustomized(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Order>("select OrderID, OrderNumber, CreatedDate, ConfirmDate, ShippedDate, Status " +
                    "from OrderTB " +
                    "where iIdUsuario = @userId ", new { userId } ).ToList();
            }
        }
    }
}