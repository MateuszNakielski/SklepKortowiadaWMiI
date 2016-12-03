using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SklepKortowiadaWMiI.WebPage
{
    public class LoginController : Controller
    {
        IOrderService orderService;

        public LoginController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public ActionResult LoginForm(bool error = false)
        {
            return View(error);
        }

        public RedirectToRouteResult LoginAction(string barcode, string index)
        {
            Order order = orderService.GetOneOrderByBarCode(barcode);
            
            if(order == null)
                return RedirectToAction("NewOrder", "Login", new { barcode, index });
            else
            {
                if(order.StudentNumber != index)
                    return RedirectToAction("Index", "Login", true);
            }
            Session["order"] = order;
            return RedirectToAction("NewOrder", "Login");
        }

        public ActionResult NewOrder(string barcode, string index)
        {
            string[] dane = { barcode, index };
            return View(dane);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}