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
    public class VtCycleCountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VtCycleCounts
        public ActionResult Index()
        {
            return View(db.VtCycleCounts.ToList());
        }

        // GET: VtCycleCounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtCycleCount vtCycleCount = db.VtCycleCounts.Find(id);
            if (vtCycleCount == null)
            {
                return HttpNotFound();
            }
            return View(vtCycleCount);
        }

        // GET: VtCycleCounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VtCycleCounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VtCycleCountId,CycleCountDateTime,CustomerPn,PortalQty,ActualQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,CorrectedDateTime,Notes")] VtCycleCount vtCycleCount)
        {
            if (ModelState.IsValid)
            {
                db.VtCycleCounts.Add(vtCycleCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vtCycleCount);
        }

        // GET: VtCycleCounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtCycleCount vtCycleCount = db.VtCycleCounts.Find(id);
            if (vtCycleCount == null)
            {
                return HttpNotFound();
            }
            return View(vtCycleCount);
        }

        // POST: VtCycleCounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VtCycleCountId,CycleCountDateTime,CustomerPn,PortalQty,ActualQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,CorrectedDateTime,Notes")] VtCycleCount vtCycleCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vtCycleCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vtCycleCount);
        }

        // GET: VtCycleCounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtCycleCount vtCycleCount = db.VtCycleCounts.Find(id);
            if (vtCycleCount == null)
            {
                return HttpNotFound();
            }
            return View(vtCycleCount);
        }

        // POST: VtCycleCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VtCycleCount vtCycleCount = db.VtCycleCounts.Find(id);
            db.VtCycleCounts.Remove(vtCycleCount);
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
