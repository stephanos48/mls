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
using mls.Models;

namespace mls.Controllers.Api
{
    public class ShipOutsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ShipOuts
        public IQueryable<ShipOut> GetShipOuts()
        {
            return db.ShipOuts;
        }

        // GET: api/ShipOuts/5
        [ResponseType(typeof(ShipOut))]
        public IHttpActionResult GetShipOut(int id)
        {
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return NotFound();
            }

            return Ok(shipOut);
        }

        // PUT: api/ShipOuts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShipOut(int id, ShipOut shipOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipOut.ShipOutId)
            {
                return BadRequest();
            }

            db.Entry(shipOut).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipOutExists(id))
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

        // POST: api/ShipOuts
        [ResponseType(typeof(ShipOut))]
        public IHttpActionResult PostShipOut(ShipOut shipOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShipOuts.Add(shipOut);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shipOut.ShipOutId }, shipOut);
        }

        // DELETE: api/ShipOuts/5
        [ResponseType(typeof(ShipOut))]
        public IHttpActionResult DeleteShipOut(int id)
        {
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return NotFound();
            }

            db.ShipOuts.Remove(shipOut);
            db.SaveChanges();

            return Ok(shipOut);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShipOutExists(int id)
        {
            return db.ShipOuts.Count(e => e.ShipOutId == id) > 0;
        }
    }
}