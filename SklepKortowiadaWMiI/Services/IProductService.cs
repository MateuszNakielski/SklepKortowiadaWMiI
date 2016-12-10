using SklepKortowiadaWMiI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepKortowiadaWMiI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetOneProductById(int id);
        Product AddProduct(Product p);
        Product DeleteProductById(int id);
        Product UpdateProductById(int id, Product product);
        IEnumerable<Product> GetProductsByCategory(string category);
    }


}
