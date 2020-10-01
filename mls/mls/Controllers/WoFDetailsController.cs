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
    public class WoFDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WoFDetails
        public ActionResult Index()
        {
            var woFDetails = db.WoFDetails.Include(w => w.WorkOrderFs);
            return View(woFDetails.ToList());
        }

        // GET: WoDetails
        public ActionResult WoFDetails()
        {
            var woFDetails = db.WoFDetails.Include(w => w.WorkOrderFs);
            var result = from a in db.WoFDetails
                         orderby a.WorkDate descending
                         select a;
            return View("Index", result.ToList());
        }

        // GET: WoFDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoFDetail woFDetail = db.WoFDetails.Find(id);
            if (woFDetail == null)
            {
                return HttpNotFound();
            }
            return View(woFDetail);
        }

        // GET: WoFDetails/Create
        public ActionResult Create()
        {
            ViewBag.WorkOrderFId = new SelectList(db.WorkOrderFs, "WorkOrderFId", "WorkOrderFId");
            return View();
        }

        // POST: WoFDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WoFDetailId,WorkDate,WoResponsible,Objective,StartTime,FinishTime,TotalTime,Risk,RiskAction,Productive,Notes,WorkOrderFId")] WoFDetail woFDetail)
        {
            if (ModelState.IsValid)
            {
                db.WoFDetails.Add(woFDetail);
                db.SaveChanges();
                return RedirectToAction("WoFDetails", "WoFDetails");
            }

            ViewBag.WorkOrderFId = new SelectList(db.WorkOrderFs, "WorkOrderFId", "WorkOrderFId", woFDetail.WorkOrderFId);
            return View(woFDetail);
        }

        // GET: WoFDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoFDetail woFDetail = db.WoFDetails.Find(id);
            if (woFDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkOrderFId = new SelectList(db.WorkOrderFs, "WorkOrderFId", "WorkOrderFId", woFDetail.WorkOrderFId);
            return View(woFDetail);
        }

        // POST: WoFDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WoFDetailId,WorkDate,WoResponsible,Objective,StartTime,FinishTime,TotalTime,Risk,RiskAction,Productive,Notes,WorkOrderFId")] WoFDetail woFDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woFDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WoFDetails", "WoFDetails");
            }
            ViewBag.WorkOrderFId = new SelectList(db.WorkOrderFs, "WorkOrderFId", "WorkOrderFId", woFDetail.WorkOrderFId);
            return View(woFDetail);
        }

        // GET: WoFDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoFDetail woFDetail = db.WoFDetails.Find(id);
            if (woFDetail == null)
            {
                return HttpNotFound();
            }
            return View(woFDetail);
        }

        // POST: WoFDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WoFDetail woFDetail = db.WoFDetails.Find(id);
            db.WoFDetails.Remove(woFDetail);
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
