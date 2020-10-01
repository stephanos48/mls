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
    public class HeilPoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HeilPoes
        public ActionResult Index()
        {
            return View(db.HeilPos.ToList());
        }

        public ActionResult RoHeilTransit()
        {
            var query = from a in db.HeilPos
                        where a.PoOrderStatusId == 2
                        orderby a.OrderDateTime descending
                        select a;
            return View("Index", query);
            //return View();
        }

        // GET: HeilPoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilPo heilPo = db.HeilPos.Find(id);
            if (heilPo == null)
            {
                return HttpNotFound();
            }
            return View(heilPo);
        }

        // GET: HeilPoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeilPoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeilPoId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,ContainerId,ContainerUh,FreightFowarder,Destination,AMS,BOL,Pallet,Invoice,ArrivalWk,RequestedDateTime,PromiseDateTime,Shipdate,Etadate,ReceiptDateTime,PoOrderStatusId,PoSentDateTime,PoSentBy,PoConfirmedDateTime,PoConfirmedBy,Notes")] HeilPo heilPo)
        {
            if (ModelState.IsValid)
            {
                db.HeilPos.Add(heilPo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heilPo);
        }

        // GET: HeilPoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilPo heilPo = db.HeilPos.Find(id);
            if (heilPo == null)
            {
                return HttpNotFound();
            }
            return View(heilPo);
        }

        // POST: HeilPoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeilPoId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,ContainerId,ContainerUh,FreightFowarder,Destination,AMS,BOL,Pallet,Invoice,ArrivalWk,RequestedDateTime,PromiseDateTime,Shipdate,Etadate,ReceiptDateTime,PoOrderStatusId,PoSentDateTime,PoSentBy,PoConfirmedDateTime,PoConfirmedBy,Notes")] HeilPo heilPo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heilPo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heilPo);
        }

        // GET: HeilPoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilPo heilPo = db.HeilPos.Find(id);
            if (heilPo == null)
            {
                return HttpNotFound();
            }
            return View(heilPo);
        }

        // POST: HeilPoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeilPo heilPo = db.HeilPos.Find(id);
            db.HeilPos.Remove(heilPo);
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
