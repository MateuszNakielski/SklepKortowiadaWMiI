using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.DTO;
using SklepKortowiadaWMiI.Services;

namespace SklepKortowiadaWMiI.Controllers
{
    public class ProductsController : ApiController
    {
        IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return productService.GetAllProducts().Select(p => ProductDTO.ToProductDTO(p));
        }

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = productService.GetOneProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ProductDTO.ToProductDTO(product));
        }

    }
}