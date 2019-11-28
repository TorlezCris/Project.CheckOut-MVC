using Project.CheckOut.UnitOfWork;
using Project.CheckOut_MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.CheckOut_MVC.Controllers
{
    public class OrderDetailController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public OrderDetailController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: OrderDetail
        public ActionResult Index(int OrderId, string OrderNumber)
        {
            var orderDetail = _unit.OrderDetail.GetOrderDetailCustomized(OrderId);
            var product = _unit.Product.GetProductCustomized(orderDetail.ProductId);

            return View(new DetailOfOrder {
                OrderNumber = OrderNumber,
                ProductName = product.Name,
                Discount = orderDetail.Discount,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
                TotalPay = orderDetail.TotalPay
            });
        }
    }
}