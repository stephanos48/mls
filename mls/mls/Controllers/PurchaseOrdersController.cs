﻿using System;
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
    public class PurchaseOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            return View(db.PurchaseOrders.ToList());
        }

        public ActionResult PoHome()
        {
            return View("PoHome");
        }

        public ActionResult HeilPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("PoHome", query);
        }

        public ActionResult MarathonPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 2
                        orderby a.OrderDateTime descending
                        select a;
            return View("PoHome", query);
        }

        public ActionResult BaynePo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 4
                        orderby a.OrderDateTime descending
                        select a;
            return View("PoHome", query);
        }

        public ActionResult PcPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.OrderDateTime descending
                        select a;
            return View("PoHome", query);
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseOrderId,PoNumber,SupplierId,ShipToAddress,ConfirmTo,ShipVia,FOB,Terms,Reference,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,OrderStatusId,Notes")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseOrderId,PoNumber,SupplierId,ShipToAddress,ConfirmTo,ShipVia,FOB,Terms,Reference,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,OrderStatusId,Notes")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
