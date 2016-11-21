using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepKortowiadaWMiI.Models;
using System.Data.Entity;

namespace SklepKortowiadaWMiI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        public Product AddProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return p;
        }

        public Product DeleteProductById(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
                return null;
            db.Products.Remove(product);
            db.SaveChanges();
            return product;

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.AsEnumerable<Product>();
        }

        public Product GetOneProductById(int id)
        {
            return db.Products.Find(id);
        }

        public Product UpdateProductById(int id, Product p)
        {
            
            Product oldProduct = db.Products.Find(id);
            if (oldProduct == null || oldProduct.Id != p.Id)
            {
                return null;
            }
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return p;
        }
    }
}