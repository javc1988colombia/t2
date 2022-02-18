using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using t2.Mappers;
using t2.Models;

namespace t2.Controllers
{
    public class OrdersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Orders
        public IQueryable<Orders> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult GetOrders(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrders(int id, Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orders.orderid)
            {
                return BadRequest();
            }

            db.Entry(orders).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Orders))]
        public IHttpActionResult PostOrders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(orders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orders.orderid }, orders);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult DeleteOrders(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            db.Orders.Remove(orders);
            db.SaveChanges();

            return Ok(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdersExists(int id)
        {
            return db.Orders.Count(e => e.orderid == id) > 0;
        }
    }
}