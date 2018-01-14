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
using Microsoft.Ajax.Utilities;

namespace mls.Controllers
{
    public class ShipInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        // GET: ShipIns
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult Transit()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId != 3
                        orderby a.ContainerUh descending
                        select a;
             return View("Transit", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult ROTransit()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId != 3
                        orderby a.ContainerUh descending
                        select a;
            return View("ROTransit", query);
            //return View(db.ShipIns.ToList());
        }

        public ActionResult _Transit(int division)
        {
            var transitquery = from a in db.ShipIns
                where a.ShipInStatusId != 3 && a.CustomerDivisionId == division
                orderby a.ContainerUh descending
                select a;
            return View("_TransitPartialView", transitquery);
        }

        public ActionResult loaddata()
        {

            using (ApplicationDbContext dc = new ApplicationDbContext())
            {
               var data = from a in dc.ShipIns
                          where a.ShipInStatusId != 3
                          orderby a.ContainerUh descending
                          select a;
                return Json(new {data = data.ToList()}, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult NovTransit()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId != 3 && a.CustomerId == 17
                        orderby a.ContainerUh descending
                        select a;
            return View("NovTransit", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult WbTransit()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId != 3 && a.CustomerId == 2
                        orderby a.ContainerUh descending
                        select a;
            return View("WBTransit", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult WBReceipt()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId == 3 && a.CustomerId == 2 
                        orderby a.ContainerUh descending
                        select a;
            return View("WBReceipt", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult NovReceipt()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId == 3 && a.CustomerId == 17
                        orderby a.ContainerUh descending
                        select a;
            return View("NovReceipt", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult Receipt()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId == 3
                        orderby a.ContainerUh descending
                        select a;
            return View("Receipt", query);
            //return View(db.ShipIns.ToList());
        }

        [Authorize]
        // GET: ShipIns
        public ActionResult ROReceipt()
        {
            var query = from a in db.ShipIns
                        where a.ShipInStatusId == 3
                        orderby a.ContainerUh descending
                        select a;
            return View("ROReceipt", query);
            //return View(db.ShipIns.ToList());
        }

        // GET: ShipIns/Details/5
        public ActionResult WbDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View(shipIn);
        }

        // GET: ShipIns/Details/5
        public ActionResult NovDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View(shipIn);
        }

        // GET: ShipIns/Details/5
        public ActionResult WbDetailsR(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View(shipIn);
        }

        // GET: ShipIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View(shipIn);
        }

        // GET: ShipIns/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var shipinstatuses = db.ShipInStatuses.ToList();

            var viewModel = new SaveShipInViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                ShipInStatuses = shipinstatuses

            };
            return View("Create", viewModel);
        }

        // POST: ShipIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShipInId,CustomerId,CustomerDivisionId,Destination,ContainerId,ContainerUh,BOL,AMS,CO,Invoice,Seal,Port,Pallet,Pn,UhPn,Shipdate,Etadate,Qty,Hub,Hubeta,Receiptdate,Receivedby,Qtyconfirmed,ShipInStatusId")] ShipIn shipIn)
        public ActionResult Create(ShipIn shipIn)
        {
            if (ModelState.IsValid)
            {
                db.ShipIns.Add(shipIn);
                db.SaveChanges();
                return RedirectToAction("Index", "ShipIns");
            }

            return View();
            //return View(shipIn);
        }

        // GET: ShipIns/Edit/5
        public ActionResult Edit(int? id)
        {
            var shipins = db.ShipIns.SingleOrDefault(c => c.ShipInId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var shipinstatuses = db.ShipInStatuses.ToList();

            var viewModel = new SaveShipInViewModel()
            {
                ShipIn = shipins,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                ShipInStatuses = shipinstatuses
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: ShipIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShipInId,CustomerId,CustomerDivisionId,Destination,ContainerId,ContainerUh,BOL,AMS,CO,Invoice,Seal,Port,Pallet,Pn,UhPn,Shipdate,Etadate,Qty,Hub,Hubeta,Receiptdate,Receivedby,Qtyconfirmed,ShipInStatusId")] ShipIn shipIn)
        public ActionResult Edit(ShipIn shipIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipIn);
        }

        // GET: ShipIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipIn shipIn = db.ShipIns.Find(id);
            if (shipIn == null)
            {
                return HttpNotFound();
            }
            return View(shipIn);
        }

        // POST: ShipIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipIn shipIn = db.ShipIns.Find(id);
            db.ShipIns.Remove(shipIn);
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
