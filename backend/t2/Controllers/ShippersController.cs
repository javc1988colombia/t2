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
using t2.Mappers;
using t2.Models;

namespace t2.Controllers
{
    public class ShippersController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Shippers
        public List<ShippersMapper> GetShippers()
        {
            return db.Database.SqlQuery<ShippersMapper>("Select ShipperId, CompanyName from Sales.Shippers").ToList();
        }

        // GET: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult GetShippers(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return NotFound();
            }

            return Ok(shippers);
        }

        // PUT: api/Shippers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShippers(int id, Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shippers.shipperid)
            {
                return BadRequest();
            }

            db.Entry(shippers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippersExists(id))
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

        // POST: api/Shippers
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult PostShippers(Shippers shippers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shippers.Add(shippers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shippers.shipperid }, shippers);
        }

        // DELETE: api/Shippers/5
        [ResponseType(typeof(Shippers))]
        public IHttpActionResult DeleteShippers(int id)
        {
            Shippers shippers = db.Shippers.Find(id);
            if (shippers == null)
            {
                return NotFound();
            }

            db.Shippers.Remove(shippers);
            db.SaveChanges();

            return Ok(shippers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShippersExists(int id)
        {
            return db.Shippers.Count(e => e.shipperid == id) > 0;
        }
    }
}