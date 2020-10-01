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
    public class InvTransferLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvTransferLogs
        public ActionResult Index()
        {
            return View(db.InvTransferLogs.ToList());
        }

        // GET: InvTransferLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransferLog invTransferLog = db.InvTransferLogs.Find(id);
            if (invTransferLog == null)
            {
                return HttpNotFound();
            }
            return View(invTransferLog);
        }

        // GET: InvTransferLogs/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var invLocation = db.InvLocation.ToList();

            var viewModel = new InvTransferLogViewModel()
            {
                InvLocations = invLocation,
            };
            return View("Create", viewModel);
            //return View();
        }

        // POST: InvTransferLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "InvTransferLogId,TransferDateTime,InvLocationId,CustomerPn,PartDescription,TransferQty,Notes")] InvTransferLog invTransferLog)
        public ActionResult Create(InvTransferLog invTransferLog)
        {
            if (ModelState.IsValid)
            {
                db.InvTransferLogs.Add(invTransferLog);
                db.SaveChanges();
                return RedirectToAction("Index", "InvTransferLogs");
            }
            return View();
            //return View(invTransferLog);
        }

        // GET: InvTransferLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            var invtransferlogs = db.InvTransferLogs.SingleOrDefault(c => c.InvTransferLogId == id);

            var invLocation = db.InvLocation.ToList();

            var viewModel = new InvTransferLogViewModel()
            {
                InvTransferLog = invtransferlogs,
                InvLocations = invLocation,
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransferLog invTransferLog = db.InvTransferLogs.Find(id);
            if (invTransferLog == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(invTransferLog);
        }

        // POST: InvTransferLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "InvTransferLogId,TransferDateTime,InvLocationId,CustomerPn,PartDescription,TransferQty,Notes")] InvTransferLog invTransferLog)
        public ActionResult Edit(InvTransferLog invTransferLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invTransferLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invTransferLog);
        }

        // GET: InvTransferLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransferLog invTransferLog = db.InvTransferLogs.Find(id);
            if (invTransferLog == null)
            {
                return HttpNotFound();
            }
            return View(invTransferLog);
        }

        // POST: InvTransferLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvTransferLog invTransferLog = db.InvTransferLogs.Find(id);
            db.InvTransferLogs.Remove(invTransferLog);
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
