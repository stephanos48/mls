using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;

namespace mls.Controllers
{
    [Authorize]
    public class IncomingDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncomingDetails
        public ActionResult Index()
        {
            return View(db.IncomingDetails.ToList());
        }

        // GET: IncomingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingDetail incomingDetail = db.IncomingDetails.Find(id);
            if (incomingDetail == null)
            {
                return HttpNotFound();
            }
            return View(incomingDetail);
        }

        // GET: IncomingDetails/Create
        public ActionResult Create()
        {
            ViewBag.IncomingTopLevelId = new SelectList(db.IncomingTopLevels, "IncomingTopLevelId", "IncomingTopLevelId");

            return View();
        }

        // POST: IncomingDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomingDetailId,InspectionDateTime,PartNumber,SerialNumber,InspectionCriteria,InspectionType,QtyReceived,QtyInspected,QtyGood,QtyBad,InspectorName,Notes,IncomingTopLevelId")] IncomingDetail incomingDetail)
        {
            if (ModelState.IsValid)
            {
                db.IncomingDetails.Add(incomingDetail);
                db.SaveChanges();
                return RedirectToAction("Index", "IncomingTopLevels");
            }

            ViewBag.IncomingTopLevelId = new SelectList(db.IncomingTopLevels, "IncomingTopLevelId", "IncomingVesselNo", incomingDetail.IncomingTopLevelId);
            return View(incomingDetail);
        }

        // GET: IncomingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingDetail incomingDetail = db.IncomingDetails.Find(id);
            if (incomingDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncomingTopLevelId = new SelectList(db.IncomingTopLevels, "IncomingTopLevelId", "IncomingVesselNo", incomingDetail.IncomingTopLevelId);
            return View(incomingDetail);
        }

        // POST: IncomingDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomingDetailId,InspectionDateTime,PartNumber,SerialNumber,InspectionCriteria,InspectionType,QtyReceived,QtyInspected,QtyGood,QtyBad,InspectorName,Notes,IncomingTopLevelId")] IncomingDetail incomingDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "IncomingTopLevels");
            }
            ViewBag.IncomingTopLevelId = new SelectList(db.IncomingTopLevels, "IncomingTopLevelId", "IncomingVesselNo", incomingDetail.IncomingTopLevelId);
            return View(incomingDetail);
        }

        // GET: IncomingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingDetail incomingDetail = db.IncomingDetails.Find(id);
            if (incomingDetail == null)
            {
                return HttpNotFound();
            }
            return View(incomingDetail);
        }

        // POST: IncomingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingDetail incomingDetail = db.IncomingDetails.Find(id);
            db.IncomingDetails.Remove(incomingDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
