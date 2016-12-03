using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SklepKortowiadaWMiI.WebPage
{
    public class HomeController : Controller
    {
        IProductService productService;

        public HomeController( IProductService productService)
        {
            this.productService = productService;
        } 
        // GET: Home
        public ActionResult Index()
        {
            return View(productService.GetAllProducts().ToList<Product>());
        }
    }
}