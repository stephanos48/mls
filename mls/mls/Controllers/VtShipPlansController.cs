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
    public class VtShipPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VtShipPlans
        public ActionResult Index()
        {
            return View(db.VtShipPlans.ToList());
        }

        // GET: VtShipPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtShipPlan vtShipPlan = db.VtShipPlans.Find(id);
            if (vtShipPlan == null)
            {
                return HttpNotFound();
            }
            return View(vtShipPlan);
        }

        // GET: VtShipPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VtShipPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VtShipPlanId,OrderDateTime,CustomerId,CustomerDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,CustomerPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] VtShipPlan vtShipPlan)
        {
            if (ModelState.IsValid)
            {
                db.VtShipPlans.Add(vtShipPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vtShipPlan);
        }

        // GET: VtShipPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtShipPlan vtShipPlan = db.VtShipPlans.Find(id);
            if (vtShipPlan == null)
            {
                return HttpNotFound();
            }
            return View(vtShipPlan);
        }

        // POST: VtShipPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VtShipPlanId,OrderDateTime,CustomerId,CustomerDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,CustomerPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] VtShipPlan vtShipPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vtShipPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vtShipPlan);
        }

        // GET: VtShipPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtShipPlan vtShipPlan = db.VtShipPlans.Find(id);
            if (vtShipPlan == null)
            {
                return HttpNotFound();
            }
            return View(vtShipPlan);
        }

        // POST: VtShipPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VtShipPlan vtShipPlan = db.VtShipPlans.Find(id);
            db.VtShipPlans.Remove(vtShipPlan);
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
