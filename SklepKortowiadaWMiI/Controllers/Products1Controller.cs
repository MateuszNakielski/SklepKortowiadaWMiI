using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;

namespace SklepKortowiadaWMiI.Controllers
{
    public class Products1Controller : ApiController
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        // GET: api/Products1
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }
    }
}