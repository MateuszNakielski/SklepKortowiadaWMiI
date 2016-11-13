using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.DTO;

namespace SklepKortowiadaWMiI.Controllers
{
    public class ProductsController : ApiController
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        public IEnumerable<ProductDTO> GetProducts()
        {
            return db.Products.
                AsEnumerable<Product>().
                Select(p => ProductDTO.ToProductDTO(p));
        }

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(ProductDTO.ToProductDTO(product));
        }

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult PostProduct(ProductDTO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(ProductDTO.FromProductDTO(p));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p.Id }, p);
        }

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok(ProductDTO.ToProductDTO(product));
        }

        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult PutProduct(int id, ProductDTO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.Id)
            {
                return BadRequest();
            }

            Product newProduct = ProductDTO.FromProductDTO(p);

            db.Entry(newProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ProductDTO.ToProductDTO(newProduct));
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}