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
    public class CycleCountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CycleCounts
        public ActionResult Index()
        {
            return View(db.CycleCounts.ToList().OrderByDescending(s => s.CorrectedDateTime));
        }

        // GET: CycleCounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCount cycleCount = db.CycleCounts.Find(id);
            if (cycleCount == null)
            {
                return HttpNotFound();
            }
            return View(cycleCount);
        }

        // GET: CycleCounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CycleCounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CycleCountId,CycleCountDateTime,CustomerPn,SageQty,PortalQty,ActualQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,SageAdjQty,PortalAdjQty,CorrectedDateTime,Notes")] CycleCount cycleCount)
        {
            if (ModelState.IsValid)
            {
                db.CycleCounts.Add(cycleCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cycleCount);
        }

        // GET: CycleCounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCount cycleCount = db.CycleCounts.Find(id);
            if (cycleCount == null)
            {
                return HttpNotFound();
            }
            return View(cycleCount);
        }

        // POST: CycleCounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CycleCountId,CycleCountDateTime,CustomerPn,SageQty,PortalQty,ActualQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,,SageAdjQty,PortalAdjQty,CorrectedDateTime,Notes")] CycleCount cycleCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycleCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cycleCount);
        }

        // GET: CycleCounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCount cycleCount = db.CycleCounts.Find(id);
            if (cycleCount == null)
            {
                return HttpNotFound();
            }
            return View(cycleCount);
        }

        // POST: CycleCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CycleCount cycleCount = db.CycleCounts.Find(id);
            db.CycleCounts.Remove(cycleCount);
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
