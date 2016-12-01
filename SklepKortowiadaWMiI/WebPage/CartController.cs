using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using SklepKortowiadaWMiI.WebModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKortowiadaWMiI.WebPage
{
    public class CartController : Controller
    {
        private IProductService productService;
        private IOrderService orderService;
        
        public CartController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        public RedirectToRouteResult AddToCart(int productId, int quantity, string returnUrl)
        {
            Product product = productService.GetOneProductById(productId);
            getCart().AddItem(product, quantity);
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult Index()
        {
            return View(getCart());
        }

        private Cart getCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

    }
}