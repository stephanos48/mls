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
    public class IncomingLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncomingLogs
        public ActionResult Index()
        {
            var query = from a in db.IncomingLogs
                        where a.InspectionStatusId == 1
                        orderby a.IncomingStartDate descending
                        select a;
            return View("Index", query);
        }

        public ActionResult Print()
        {
            var query = from a in db.IncomingLogs
                        where a.InspectionStatusId == 1
                        orderby a.IncomingStartDate descending
                        select a;
            return View("Print", query);
        }

        public ActionResult Closed()
        {
            var query = from a in db.IncomingLogs
                        where a.InspectionStatusId == 2
                        orderby a.IncomingStartDate descending
                        select a;
            return View("Closed", query);
        }

        // GET: IncomingLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLog incomingLog = db.IncomingLogs.Find(id);
            if (incomingLog == null)
            {
                return HttpNotFound();
            }
            return View(incomingLog);
        }

        // GET: IncomingLogs/Create
        public ActionResult Create()
        {

            var inspectionstatuses = db.InspectionStatuses.ToList();

            var viewModel = new SaveIncomingViewModel()
            {
                InspectionStatuses = inspectionstatuses
            };
            return View("Create", viewModel);

        }

        // POST: IncomingLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IncomingLogId,Pn,InspectionType,InspectionLength,IncomingStartDate,IncomingRemovalDate,InspectionMethod,InspectionCriteria,InspectionStatusId,Notes")] IncomingLog incomingLog)
        public ActionResult Create(IncomingLog incomingLog)
        {
            if (ModelState.IsValid)
            {
                db.IncomingLogs.Add(incomingLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //return View(incomingLog);
        }

        // GET: IncomingLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            var incominglogs = db.IncomingLogs.SingleOrDefault(c => c.IncomingLogId == id);

            var inspectionstatuses = db.InspectionStatuses.ToList();

            var viewModel = new SaveIncomingViewModel()
            {
                IncomingLog = incominglogs,
                InspectionStatuses = inspectionstatuses
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLog incomingLog = db.IncomingLogs.Find(id);
            if (incomingLog == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(incomingLog);
        }

        // POST: IncomingLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "IncomingLogId,Pn,InspectionType,InspectionLength,IncomingStartDate,IncomingRemovalDate,InspectionMethod,InspectionCriteria,InspectionStatusId,Notes")] IncomingLog incomingLog)
        public ActionResult Edit(IncomingLog incomingLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingLog);
        }

        // GET: IncomingLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingLog incomingLog = db.IncomingLogs.Find(id);
            if (incomingLog == null)
            {
                return HttpNotFound();
            }
            return View(incomingLog);
        }

        // POST: IncomingLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingLog incomingLog = db.IncomingLogs.Find(id);
            db.IncomingLogs.Remove(incomingLog);
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
