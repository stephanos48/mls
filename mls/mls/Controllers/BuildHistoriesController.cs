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
    [Authorize]
    public class BuildHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuildHistories
        public ActionResult Index()
        {
            var query = from a in db.BuildHistories
                        orderby a.ShipDateTime descending
                        select a;
            return View(query);
        }

        // GET: BuildHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = db.BuildHistories.Find(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            return View(buildHistory);
        }

        // GET: BuildHistories/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveBuildViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions

            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: BuildHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BuildHistoryId,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,SerialNo,Qty,ShipDateTime,AssembledBy,InspectedBy,ShippedBy,Notes")] BuildHistory buildHistory)
        public ActionResult Create(BuildHistory buildHistory)
        {
            if (ModelState.IsValid)
            {
                db.BuildHistories.Add(buildHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //return View(buildHistory);
            return View();
        }

        // GET: BuildHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            var buildhistories = db.BuildHistories.SingleOrDefault(c => c.BuildHistoryId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveBuildViewModel()
            {
                BuildHistory = buildhistories,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = db.BuildHistories.Find(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(buildHistory);
        }

        // POST: BuildHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BuildHistoryId,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,SerialNo,Qty,ShipDateTime,AssembledBy,InspectedBy,ShippedBy,Notes")] BuildHistory buildHistory)
        public ActionResult Edit (BuildHistory buildHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(buildHistory);
        }

        // GET: BuildHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildHistory buildHistory = db.BuildHistories.Find(id);
            if (buildHistory == null)
            {
                return HttpNotFound();
            }
            return View(buildHistory);
        }

        // POST: BuildHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildHistory buildHistory = db.BuildHistories.Find(id);
            db.BuildHistories.Remove(buildHistory);
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
