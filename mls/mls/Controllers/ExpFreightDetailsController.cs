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
    public class ExpFreightDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExpFreightDetails
        public ActionResult Index()
        {
            var expFreightDetails = db.ExpFreightDetails.Include(s => s.ExpeditedFreights);
            return View(expFreightDetails.ToList());
        }

        // GET: ExpFreightDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpFreightDetail expFreightDetail = db.ExpFreightDetails.Find(id);
            if (expFreightDetail == null)
            {
                return HttpNotFound();
            }
            return View(expFreightDetail);
        }

        // GET: ExpFreightDetails/Create
        public ActionResult Create()
        {
            ViewBag.ExpeditedFreightId = new SelectList(db.ExpeditedFreights, "ExpeditedFreightId", "ExpeditedFreightNo");
            return View();
        }

        // POST: ExpFreightDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpFreightDetailId,ExpediteMode,StartDateTime,ArrivalDateTime,Cost,Notes,ExpeditedFreightId")] ExpFreightDetail expFreightDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExpFreightDetails.Add(expFreightDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpeditedFreightId = new SelectList(db.ExpeditedFreights, "ExpeditedFreightId", "ExpeditedFreightNo", expFreightDetail.ExpeditedFreightId);
            return View(expFreightDetail);
        }

        // GET: ExpFreightDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpFreightDetail expFreightDetail = db.ExpFreightDetails.Find(id);
            if (expFreightDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpeditedFreightId = new SelectList(db.ExpeditedFreights, "ExpeditedFreightId", "ExpeditedFreightNo", expFreightDetail.ExpeditedFreightId);
            return View(expFreightDetail);
        }

        // POST: ExpFreightDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpFreightDetailId,ExpediteMode,StartDateTime,ArrivalDateTime,Cost,Notes,ExpeditedFreightId")] ExpFreightDetail expFreightDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expFreightDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpeditedFreightId = new SelectList(db.ExpeditedFreights, "ExpeditedFreightId", "ExpeditedFreightNo", expFreightDetail.ExpeditedFreightId);
            return View(expFreightDetail);
        }

        // GET: ExpFreightDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpFreightDetail expFreightDetail = db.ExpFreightDetails.Find(id);
            if (expFreightDetail == null)
            {
                return HttpNotFound();
            }
            return View(expFreightDetail);
        }

        // POST: ExpFreightDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpFreightDetail expFreightDetail = db.ExpFreightDetails.Find(id);
            db.ExpFreightDetails.Remove(expFreightDetail);
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
