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

        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult PutOrder(int id, OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = OrderDTO.FromOrderDTO(orderDTO);
            if (id != orderDTO.Id)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(orderDTO);
        }

        // POST: api/Orders1
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult PostOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = OrderDTO.FromOrderDTO(orderDTO);
            db.Orders.Add(order);
            db.SaveChanges();

            return Ok(orderDTO);
        }
        [Route("api/Orders/{id}")]
        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult AddOrderDetail(int id, OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = db.Orders.Find(id);
            if (order == null)
                return NotFound();
            OrderDetail orderDetail = OrderDetailDTO.FromOrderDetailDTO(orderDetailDTO, id);
            
            
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        // DELETE: api/Orders1/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }


        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.Id == id) > 0;
        }
    }
    }