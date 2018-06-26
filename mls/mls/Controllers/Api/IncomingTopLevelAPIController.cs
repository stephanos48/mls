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
    public class IncomingTopLevelAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/IncomingTopLevels
        public IList<IncomingTopLevel> GetIncomingTopLevels()
        {
            try
            {
                //return Ok(db.IncomingTopLevels.ToList());
                var incomingtoplevels = db.IncomingTopLevels.ToList();
                return incomingtoplevels;
            }
            catch (Exception ex)
            {
                throw;
            }
            //return db.IncomingTopLevels;
        }

        // GET: api/IncomingTopLevels/5
        [ResponseType(typeof(IncomingTopLevel))]
        public IHttpActionResult GetIncomingTopLevel(int id)
        {
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            if (incomingTopLevel == null)
            {
                return NotFound();
            }

            return Ok(incomingTopLevel);
        }

        // PUT: api/IncomingTopLevels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncomingTopLevel(int id, IncomingTopLevel incomingTopLevel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (id != incomingTopLevel.IncomingTopLevelId)
                    {
                        return BadRequest();
                    }
                    //return BadRequest(ModelState);

                    var oldIncomingTopLevel = db.IncomingTopLevels.FirstOrDefault(s => s.IncomingTopLevelId == id);
                    oldIncomingTopLevel.IncomingVesselNo = incomingTopLevel.IncomingVesselNo;
                    oldIncomingTopLevel.InspectionDateTime = incomingTopLevel.InspectionDateTime;
                    oldIncomingTopLevel.Notes = incomingTopLevel.Notes;

                    foreach (var incomingDetails in incomingTopLevel.IncomingDetails)
                    {
                        if (incomingDetails.IncomingDetailId == 0)
                        {
                            oldIncomingTopLevel.IncomingDetails.Add(incomingDetails);
                        }
                    }
                    db.SaveChanges();

                    return StatusCode(HttpStatusCode.NoContent);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //if (id != incomingTopLevel.IncomingTopLevelId)
        //{
        //    return BadRequest();
        //}

        /*db.Entry(incomingTopLevel).State = EntityState.Modified;

        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IncomingTopLevelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return StatusCode(HttpStatusCode.NoContent);
    }*/

        // POST: api/IncomingTopLevels
        [ResponseType(typeof(IncomingTopLevel))]
        public IHttpActionResult PostIncomingTopLevel(IncomingTopLevel incomingTopLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (var _db = new ApplicationDbContext())
                {
                    _db.IncomingTopLevels.Add(incomingTopLevel);
                    foreach (var incomingDetails in incomingTopLevel.IncomingDetails)
                    {
                        incomingDetails.IncomingTopLevelId = incomingTopLevel.IncomingTopLevelId;
                        _db.IncomingDetails.Add(incomingDetails);
                    }

                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            //db.IncomingTopLevels.Add(incomingTopLevel);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = incomingTopLevel.IncomingTopLevelId }, incomingTopLevel);
        }

        // DELETE: api/IncomingTopLevels/5
        [ResponseType(typeof(IncomingTopLevel))]
        public IHttpActionResult DeleteIncomingTopLevel(int id)
        {
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            if (incomingTopLevel == null)
            {
                return NotFound();
            }

            db.IncomingTopLevels.Remove(incomingTopLevel);
            db.SaveChanges();

            return Ok(incomingTopLevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncomingTopLevelExists(int id)
        {
            return db.IncomingTopLevels.Count(e => e.IncomingTopLevelId == id) > 0;
        }

    }
}