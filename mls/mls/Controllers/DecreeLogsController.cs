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
    public class DecreeLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DecreeLogs
        public ActionResult Index()
        {
            return View(db.DecreeLogs.ToList().OrderByDescending(a => a.DecreeDateTime));
        }

        // GET: DecreeLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecreeLog decreeLog = db.DecreeLogs.Find(id);
            if (decreeLog == null)
            {
                return HttpNotFound();
            }
            return View(decreeLog);
        }

        // GET: DecreeLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DecreeLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DecreeLogId,DecreeDateTime,Decree,EffectiveDateTime,Notes")] DecreeLog decreeLog)
        {
            if (ModelState.IsValid)
            {
                db.DecreeLogs.Add(decreeLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decreeLog);
        }

        // GET: DecreeLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecreeLog decreeLog = db.DecreeLogs.Find(id);
            if (decreeLog == null)
            {
                return HttpNotFound();
            }
            return View(decreeLog);
        }

        // POST: DecreeLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DecreeLogId,DecreeDateTime,Decree,EffectiveDateTime,Notes")] DecreeLog decreeLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decreeLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decreeLog);
        }

        // GET: DecreeLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DecreeLog decreeLog = db.DecreeLogs.Find(id);
            if (decreeLog == null)
            {
                return HttpNotFound();
            }
            return View(decreeLog);
        }

        // POST: DecreeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DecreeLog decreeLog = db.DecreeLogs.Find(id);
            db.DecreeLogs.Remove(decreeLog);
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
