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
    public class ProductionPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductionPlans
        public ActionResult Index()
        {
            return View(db.ProductionPlans.ToList());
        }

        public ActionResult ScheduleHome()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View(db.ProductionPlans.ToList());
        }

        // GET: ProductionPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPlan productionPlan = db.ProductionPlans.Find(id);
            if (productionPlan == null)
            {
                return HttpNotFound();
            }
            return View(productionPlan);
        }

        // GET: ProductionPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionPlanId,Pn,Description,TotalOrders,OnHold,Schedule,Day1,Day2,Day3,Day4,Day5,Day6,Day7,Day8,Day9,Day10,Wk3,Wk4,Wk5,Wk6,Wk7,Wk8,Notes")] ProductionPlan productionPlan)
        {
            if (ModelState.IsValid)
            {
                db.ProductionPlans.Add(productionPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productionPlan);
        }

        // GET: ProductionPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPlan productionPlan = db.ProductionPlans.Find(id);
            if (productionPlan == null)
            {
                return HttpNotFound();
            }
            return View(productionPlan);
        }

        // POST: ProductionPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionPlanId,Pn,Description,TotalOrders,OnHold,Schedule,Day1,Day2,Day3,Day4,Day5,Day6,Day7,Day8,Day9,Day10,Wk3,Wk4,Wk5,Wk6,Wk7,Wk8,Notes")] ProductionPlan productionPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productionPlan);
        }

        // GET: ProductionPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionPlan productionPlan = db.ProductionPlans.Find(id);
            if (productionPlan == null)
            {
                return HttpNotFound();
            }
            return View(productionPlan);
        }

        // POST: ProductionPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductionPlan productionPlan = db.ProductionPlans.Find(id);
            db.ProductionPlans.Remove(productionPlan);
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
