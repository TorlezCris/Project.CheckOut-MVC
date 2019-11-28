using Project.CheckOut.Models;
using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.CheckOut_MVC.Controllers
{
    public class OrderController : Controller
    {
        protected readonly IUnitOfWork _unit;

        public OrderController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Order
        public ActionResult Index()
        {
            //Recuperar userId
            int userId = 1;
            return View(_unit.Order.GetOrdersCustomized(userId));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create(string OrderNumber)
        {
            return View(new Order { OrderNumber = OrderNumber });
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(int productId, int quantity, string precio)
        {
            try
            {
                decimal x = decimal.Parse(precio);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                var response = _unit.Order.CreateCustomized(productId);
                if (response.Item2 == 0)
                    return RedirectToAction("Index");

                var responseOrderDetail = _unit.OrderDetail.CreateCustomized(response.Item2, productId, quantity, decimal.Parse(precio));
                return RedirectToAction("Create", new { OrderNumber = response.Item1 });
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
