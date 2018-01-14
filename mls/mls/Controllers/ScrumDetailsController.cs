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
    public class ScrumDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScrumDetails
        public ActionResult Index()
        {
            var scrumDetails = db.ScrumDetails.Include(s => s.Scrums);
            return View(scrumDetails.ToList());
        }

        public ActionResult ScrumHome()
        {
            return View();
        }

        // GET: ScrumDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumDetail scrumDetail = db.ScrumDetails.Find(id);
            if (scrumDetail == null)
            {
                return HttpNotFound();
            }
            return View(scrumDetail);
        }

        // GET: ScrumDetails/Create
        public ActionResult Create()
        {
            ViewBag.ScrumId = new SelectList(db.Scrums, "ScrumId", "Action");
            return View();
        }

        // POST: ScrumDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScrumDetailId,ScrumUpdate,UpdateDateTime,UpdatePerson,PriorDueDateTime,NewDueDateTime,Notes,ScrumId")] ScrumDetail scrumDetail)
        {
            if (ModelState.IsValid)
            {
                db.ScrumDetails.Add(scrumDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScrumId = new SelectList(db.Scrums, "ScrumId", "Action", scrumDetail.ScrumId);
            return View(scrumDetail);
        }

        // GET: ScrumDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumDetail scrumDetail = db.ScrumDetails.Find(id);
            if (scrumDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScrumId = new SelectList(db.Scrums, "ScrumId", "Action", scrumDetail.ScrumId);
            return View(scrumDetail);
        }

        // POST: ScrumDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScrumDetailId,ScrumUpdate,UpdateDateTime,UpdatePerson,PriorDueDateTime,NewDueDateTime,Notes,ScrumId")] ScrumDetail scrumDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrumDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScrumId = new SelectList(db.Scrums, "ScrumId", "Action", scrumDetail.ScrumId);
            return View(scrumDetail);
        }

        // GET: ScrumDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScrumDetail scrumDetail = db.ScrumDetails.Find(id);
            if (scrumDetail == null)
            {
                return HttpNotFound();
            }
            return View(scrumDetail);
        }

        // POST: ScrumDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScrumDetail scrumDetail = db.ScrumDetails.Find(id);
            db.ScrumDetails.Remove(scrumDetail);
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
