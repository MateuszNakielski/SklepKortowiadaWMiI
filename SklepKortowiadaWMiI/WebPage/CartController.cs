using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using SklepKortowiadaWMiI.WebModels;
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
            if (Session["order"] == null)
                return RedirectToAction("LoginForm", "Login");
            Product product = productService.GetOneProductById(productId);
            ((Cart)Session["Cart"]).AddItem(product, quantity);
            Session["Confirmed"] = false;
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int number)
        {
            ((Cart)Session["Cart"]).RemoveItem(number);
            Session["Confirmed"] = false;
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            if(Session["order"] == null)
                return RedirectToAction("LoginForm", "Login");
            return View(Session["Cart"]);
        }

        public RedirectToRouteResult ConfirmOrder()
        {
            Session["Confirmed"] = true;
            Cart cart = Session["cart"] as Cart;
            Order order = Session["order"] as Order;
            orderService.ClearOrderDetail(order.Id);
            foreach(var c in cart.Lines)
            {
                OrderDetail od = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId = c.Product.Id,
                    Quantity = c.Quantity
                };
                orderService.AddOrderDetail(order.Id, od);
            }
            return RedirectToAction("Index");
        }
    }
}