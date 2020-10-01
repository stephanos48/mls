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
    public class HeilShipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HeilShips
        public ActionResult Index()
        {
            return View(db.HeilShips.ToList());
        }

        public ActionResult RoHeilShip()
        {
            var query = from a in db.HeilPos
                        where a.PoOrderStatusId == 5
                        orderby a.OrderDateTime descending
                        select a;
            return View("Index", query);
            //return View();
        }

        // GET: HeilShips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilShip heilShip = db.HeilShips.Find(id);
            if (heilShip == null)
            {
                return HttpNotFound();
            }
            return View(heilShip);
        }

        // GET: HeilShips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeilShips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HeilShipId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,WoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,CQStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] HeilShip heilShip)
        {
            if (ModelState.IsValid)
            {
                db.HeilShips.Add(heilShip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heilShip);
        }

        // GET: HeilShips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilShip heilShip = db.HeilShips.Find(id);
            if (heilShip == null)
            {
                return HttpNotFound();
            }
            return View(heilShip);
        }

        // POST: HeilShips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HeilShipId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,WoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,CQStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] HeilShip heilShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heilShip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heilShip);
        }

        // GET: HeilShips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeilShip heilShip = db.HeilShips.Find(id);
            if (heilShip == null)
            {
                return HttpNotFound();
            }
            return View(heilShip);
        }

        // POST: HeilShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeilShip heilShip = db.HeilShips.Find(id);
            db.HeilShips.Remove(heilShip);
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
