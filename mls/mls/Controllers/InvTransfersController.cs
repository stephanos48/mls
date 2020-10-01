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
    public class InvTransfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvTransfers
        public ActionResult Index()
        {
            return View(db.InvTransfers.ToList());
        }

        // GET: InvTransfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransfer invTransfer = db.InvTransfers.Find(id);
            if (invTransfer == null)
            {
                return HttpNotFound();
            }
            return View(invTransfer);
        }

        // GET: InvTransfers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvTransfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvTransferId,TransferDateTime,InvLocationId,FinishInvLocationId,CustomerPn,PartDescription,TransferFromQty,TransferToQty,Carrier,TrackingInfo,ShipToAddress,Notes")] InvTransfer invTransfer)
        {
            if (ModelState.IsValid)
            {
                db.InvTransfers.Add(invTransfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invTransfer);
        }

        // GET: InvTransfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransfer invTransfer = db.InvTransfers.Find(id);
            if (invTransfer == null)
            {
                return HttpNotFound();
            }
            return View(invTransfer);
        }

        // POST: InvTransfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvTransferId,TransferDateTime,InvLocationId,FinishInvLocationId,CustomerPn,PartDescription,TransferFromQty,TransferToQty,Carrier,TrackingInfo,ShipToAddress,Notes")] InvTransfer invTransfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invTransfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invTransfer);
        }

        // GET: InvTransfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvTransfer invTransfer = db.InvTransfers.Find(id);
            if (invTransfer == null)
            {
                return HttpNotFound();
            }
            return View(invTransfer);
        }

        // POST: InvTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvTransfer invTransfer = db.InvTransfers.Find(id);
            db.InvTransfers.Remove(invTransfer);
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
