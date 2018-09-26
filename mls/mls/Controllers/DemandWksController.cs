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
    public class DemandWksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DemandWks
        public ActionResult Index()
        {
            return View(db.DemandWks.ToList());
        }

        // GET: DemandWks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandWk demandWk = db.DemandWks.Find(id);
            if (demandWk == null)
            {
                return HttpNotFound();
            }
            return View(demandWk);
        }

        // GET: DemandWks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemandWks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DemandWkId,CustomerPn,CalendarWk,Qty,LastUpdated,UpdatedBy,Notes")] DemandWk demandWk)
        {
            if (ModelState.IsValid)
            {
                db.DemandWks.Add(demandWk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demandWk);
        }

        // GET: DemandWks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandWk demandWk = db.DemandWks.Find(id);
            if (demandWk == null)
            {
                return HttpNotFound();
            }
            return View(demandWk);
        }

        // POST: DemandWks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DemandWkId,CustomerPn,CalendarWk,Qty,LastUpdated,UpdatedBy,Notes")] DemandWk demandWk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demandWk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demandWk);
        }

        // GET: DemandWks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemandWk demandWk = db.DemandWks.Find(id);
            if (demandWk == null)
            {
                return HttpNotFound();
            }
            return View(demandWk);
        }

        // POST: DemandWks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemandWk demandWk = db.DemandWks.Find(id);
            db.DemandWks.Remove(demandWk);
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
