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
    public class ChOilsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChOils
        public ActionResult Index()
        {
            return View(db.ChOils.ToList());
        }

        // GET: ChOils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChOil chOil = db.ChOils.Find(id);
            if (chOil == null)
            {
                return HttpNotFound();
            }
            return View(chOil);
        }

        // GET: ChOils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChOils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChOilId,DateSampleTaken,TakenByName,Result,Notes")] ChOil chOil)
        {
            if (ModelState.IsValid)
            {
                db.ChOils.Add(chOil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chOil);
        }

        // GET: ChOils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChOil chOil = db.ChOils.Find(id);
            if (chOil == null)
            {
                return HttpNotFound();
            }
            return View(chOil);
        }

        // POST: ChOils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChOilId,DateSampleTaken,TakenByName,Result,Notes")] ChOil chOil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chOil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chOil);
        }

        // GET: ChOils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChOil chOil = db.ChOils.Find(id);
            if (chOil == null)
            {
                return HttpNotFound();
            }
            return View(chOil);
        }

        // POST: ChOils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChOil chOil = db.ChOils.Find(id);
            db.ChOils.Remove(chOil);
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
