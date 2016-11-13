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
    public class TShirtsController : ApiController
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        public IEnumerable<TShirtDTO> GetTShirts()
        {
            return db.Products.
                AsEnumerable<Product>().
                OfType<TShirt>().
                Where(p => p.GetType() == typeof(TShirt)).
                AsEnumerable<TShirt>().
                Select(p => TShirtDTO.ToTShirtDTO(p));
        }

        [ResponseType(typeof(TShirtDTO))]
        public IHttpActionResult GetProduct(int id)
        {
            Product tshirt = db.Products.Find(id);
            
            if (tshirt == null || tshirt.GetType() != typeof(TShirt) )
            {
                return NotFound();
            }

            return Ok(TShirtDTO.ToTShirtDTO((TShirt)tshirt));
        }

        [ResponseType(typeof(TShirtDTO))]
        public IHttpActionResult PostProduct(TShirtDTO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(TShirtDTO.FromTShirtDTO(p));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p.Id }, p);
        }

        [ResponseType(typeof(TShirtDTO))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product tshirt = db.Products.Find(id);
            if (tshirt == null || tshirt.GetType() != typeof(TShirt))
            {
                return NotFound();
            }
            db.Products.Remove(tshirt);
            db.SaveChanges();
            return Ok(TShirtDTO.ToTShirtDTO((TShirt)tshirt));
        }

        [ResponseType(typeof(TShirtDTO))]
        public IHttpActionResult PutProduct(int id, TShirtDTO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p.Id)
            {
                return BadRequest();
            }

            TShirt newTshirt = TShirtDTO.FromTShirtDTO(p);

            db.Entry(newTshirt).State = EntityState.Modified;

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

            return Ok(TShirtDTO.ToTShirtDTO(newTshirt));
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}
