using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    public class WoDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WoDetails
        public ActionResult Index()
        {
            var woDetails = db.WoDetails.Include(w => w.WorkOrders);
            return View(woDetails.ToList());
        }

        // GET: WoDetails
        public ActionResult WoDetails()
        {
            var woDetails = db.WoDetails.Include(w => w.WorkOrders);
            var result = from a in db.WoDetails
                         orderby a.WorkDate descending
                         select a;
            return View("Index", result.ToList());
        }

        // GET: WoDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoDetail woDetail = db.WoDetails.Find(id);
            if (woDetail == null)
            {
                return HttpNotFound();
            }
            return View(woDetail);
        }

        // GET: WoDetails/Create
        public ActionResult Create()
        {
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "WorkOrderId", "WorkOrderId");

            /*var productives = db.Productives.ToList();
            var woresponsible = db.WoResponsibles.ToList();

            var viewModel = new SaveWoDetailViewModel()
            {

                Productives = productives,
                WoResponsibles = woresponsible,

            };*/

            //return View("Create", viewModel);

            return View();
        }

        // POST: WoDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WoDetailId,WorkDate,WoResponsible,Objective,StartTime,FinishTime,TotalTime,Risk,RiskAction,Productive,Notes,WorkOrderId")] WoDetail woDetail)
        //public ActionResult Create(WoDetail woDetail)
        {
            if (ModelState.IsValid)
            {
                db.WoDetails.Add(woDetail);
                db.SaveChanges();
                return RedirectToAction("ProductionPlan1", "WorkOrders");
            }

            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "WorkOrderId", "WorkOrderId", woDetail.WorkOrderId); 
            return View(woDetail);
            //return View(woDetail);
        }

        // GET: WoDetails/Edit/5
        public ActionResult Edit(int? id)
        {

            /*var workorders = db.WoDetails.SingleOrDefault(c => c.WoDetailId == id);

            var productives = db.Productives.ToList();
            var woresponsible = db.WoResponsibles.ToList();

            var viewModel = new SaveWoDetailViewModel()
            {

                Productives = productives,
                WoResponsibles = woresponsible,

            };*/

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoDetail woDetail = db.WoDetails.Find(id);
            if (woDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "WorkOrderId", "WorkOrderId", woDetail.WorkOrderId);
            return View(woDetail);
        }

        // POST: WoDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WoDetailId,WorkDate,WoResponsible,Objective,StartTime,FinishTime,TotalTime,Risk,RiskAction,Productive,Notes,WorkOrderId")] WoDetail woDetail)
        //public ActionResult Edit(WoDetail woDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkOrderId = new SelectList(db.WorkOrders, "WorkOrderId", "WorkOrderId", woDetail.WorkOrderId);
            return View(woDetail);
        }

        // GET: WoDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoDetail woDetail = db.WoDetails.Find(id);
            if (woDetail == null)
            {
                return HttpNotFound();
            }
            return View(woDetail);
        }

        // POST: WoDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WoDetail woDetail = db.WoDetails.Find(id);
            db.WoDetails.Remove(woDetail);
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
