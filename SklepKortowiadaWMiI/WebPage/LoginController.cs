using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using SklepKortowiadaWMiI.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static SklepKortowiadaWMiI.WebModels.Cart;

namespace SklepKortowiadaWMiI.WebPage
{
    public class LoginController : Controller
    {
        IOrderService orderService;
        IProductService productService;

        public LoginController(IOrderService orderService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        public ActionResult LoginForm(bool error = false)
        {
            return View(error);
        }

        public RedirectToRouteResult LoginAction(string barcode, string index)
        {
            Order order = orderService.GetOneOrderByBarCode(barcode);

            if (order == null)
                return RedirectToAction("NewOrder", "Login", new { barcode, index });
            else
            {
                if (order.StudentNumber != index)
                    return RedirectToAction("Index", "Login", true);
            }
            Session["order"] = order;
            InitCart();
            return RedirectToAction("Index", "Home");
        }

        public RedirectToRouteResult NewOrderAction(string barcode, string index, string name, string secondname, string faculty, string mode)
        {
            Order order = new Order
            {
                Barcode = barcode,
                SecondName = secondname,
                Name = name,
                Faculty = faculty,
                Mode = mode,
                StudentNumber = index
            };
            orderService.AddOrder(order);
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NewOrder(string barcode, string index)
        {
            string[] dane = { barcode, index };
            return View(dane);
        }

        private void InitCart()
        {
            Cart cart = new Cart();
            
            Order order = Session["order"] as Order;
            Session["Confirmed"] = true;
            List < OrderDetail > orderDetails = orderService.GetOrderDetailsById(order.Id).ToList();
            foreach(var od in orderDetails)
                cart.AddItem(productService.GetOneProductById(od.ProductId), od.Quantity);
            Session["Cart"] = cart;
        }
    }
}