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
    public class CustomersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Customers
        public IQueryable<Customers> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomers(int id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.custid)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customers.custid }, customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            db.SaveChanges();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(int id)
        {
            return db.Customers.Count(e => e.custid == id) > 0;
        }

        [Route("api/Customers/{id}/Orders")]
        public IEnumerable<OrdersByCustomerMapper> Get(int id)
        {
            const string sql = @"Select OrderId, RequiredDate, ShippedDate, ShipName, ShipAddress, ShipCity from Sales.Orders where custid = @id";

            var param = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            return db.Database.SqlQuery<OrdersByCustomerMapper>(sql, param).ToList();
        }
    }
}