using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SklepKortowiadaWMiI.WebPage
{
    public class CategoryController : Controller
    {
        IProductService productService;

        public CategoryController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: Category
        public ActionResult Index(string Category)
        {
            List<Product> products = productService.GetProductsByCategory(Category).ToList();

            return View(products);
        }
    }
}