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
    public class RequisitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requisitions
        public ActionResult Index()
        {
            var query = from a in db.Requisitions
                        where a.StatusId != 2 
                        orderby a.RequisitionId descending
                        select a;
            return View("Index", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult Closed()
        {
            var query = from a in db.Requisitions
                        where a.StatusId == 2
                        orderby a.RequisitionId descending
                        select a;
            return View("Closed", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            var statuses = db.Statuses.ToList();

            var viewModel = new SaveReqViewModel()
            {
                Statuses = statuses
            };

            return View("Create", viewModel);
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RequisitionId,StatusId,Supplier,Description,PartNumber,RequestDate,NeedDate,EtaDate,Requestor,Notes")] Requisition requisition)
        public ActionResult Create(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Requisitions.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //return View(requisition);
            return View();
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            var requisitions = db.Requisitions.SingleOrDefault(c => c.RequisitionId == id);

            var statuses = db.Statuses.ToList();

            var viewModel = new SaveReqViewModel()
            {
                Requisition = requisitions,
                Statuses = statuses
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RequisitionId,StatusId,Supplier,Description,PartNumber,RequestDate,NeedDate,EtaDate,Requestor,Notes")] Requisition requisition)
        public ActionResult Edit(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisition requisition = db.Requisitions.Find(id);
            db.Requisitions.Remove(requisition);
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
