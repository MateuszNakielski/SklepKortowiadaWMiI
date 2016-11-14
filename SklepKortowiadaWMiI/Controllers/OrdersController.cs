using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.DTO;
using System.Collections.Generic;

namespace SklepKortowiadaWMiI.Controllers
{
    public class OrdersController : ApiController
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        public IEnumerable<OrderDTO> GetOrders()
        {
            return db.Orders.AsEnumerable<Order>().Select(o => OrderDTO.ToOrderDTO(o));
        }

        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult GetOrder(int id)
        {
            OrderDTO order = OrderDTO.ToOrderDTO(db.Orders.Find(id));
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

    //    [ResponseType(typeof(OrderDTO))]
    //    public IHttpActionResult PutOrder(int id, OrderDTO order)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != order.Id)
    //        {
    //            return BadRequest();
    //        }

    //        db.Entry(order).State = EntityState.Modified;

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!OrderExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    // POST: api/Orders1
    //    [ResponseType(typeof(Order))]
    //    public IHttpActionResult PostOrder(Order order)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.Orders.Add(order);
    //        db.SaveChanges();

    //        return CreatedAtRoute("DefaultApi", new { id = order.Id }, order);
    //    }

    //    // DELETE: api/Orders1/5
    //    [ResponseType(typeof(Order))]
    //    public IHttpActionResult DeleteOrder(int id)
    //    {
    //        Order order = db.Orders.Find(id);
    //        if (order == null)
    //        {
    //            return NotFound();
    //        }

    //        db.Orders.Remove(order);
    //        db.SaveChanges();

    //        return Ok(order);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool OrderExists(int id)
    //    {
    //        return db.Orders.Count(e => e.Id == id) > 0;
    //    }
    //}
}