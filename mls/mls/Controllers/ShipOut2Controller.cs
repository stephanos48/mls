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
    public class ShipOut2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipOut2
        public ActionResult Index()
        {
            return View(db.ShipOut2s.ToList());
        }

        // GET: ShipOut2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut2 shipOut2 = db.ShipOut2s.Find(id);
            if (shipOut2 == null)
            {
                return HttpNotFound();
            }
            return View(shipOut2);
        }

        // GET: ShipOut2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipOut2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipOut2Id,CustomerId,CustomerDivisionId,FreightTypeId,FPaymentMethodId,Carrier,TrackingInfo,Destination,Quote,SoldTo,ShipTo,ShipTerms,ShipCity,ShipState,ShipZip,ShipDescription,ShipWeight,ShipDate,ETADate")] ShipOut2 shipOut2)
        {
            if (ModelState.IsValid)
            {
                db.ShipOut2s.Add(shipOut2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipOut2);
        }

        // GET: ShipOut2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut2 shipOut2 = db.ShipOut2s.Find(id);
            if (shipOut2 == null)
            {
                return HttpNotFound();
            }
            return View(shipOut2);
        }

        // POST: ShipOut2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipOut2Id,CustomerId,CustomerDivisionId,FreightTypeId,FPaymentMethodId,Carrier,TrackingInfo,Destination,Quote,SoldTo,ShipTo,ShipTerms,ShipCity,ShipState,ShipZip,ShipDescription,ShipWeight,ShipDate,ETADate")] ShipOut2 shipOut2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipOut2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipOut2);
        }

        // GET: ShipOut2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut2 shipOut2 = db.ShipOut2s.Find(id);
            if (shipOut2 == null)
            {
                return HttpNotFound();
            }
            return View(shipOut2);
        }

        // POST: ShipOut2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipOut2 shipOut2 = db.ShipOut2s.Find(id);
            db.ShipOut2s.Remove(shipOut2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*
        public ActionResult ShipOut2()
        {
            List<ShipOut2> ShipOut2andDetailList = db.ShipOut2s.ToList();
            return View(ShipOut2andDetailList);
        }
        
        [HttpPost]
        public ActionResult SaveOrder(string incomingVesselNo, DateTime date, string notes, ShipOut2Detail[] shipOut2Detail)
        {
            string result = "Error! Order Is Not Complete!";
            if (incomingVesselNo != null && date != null && notes != null)
            {
                IncomingTopLevel model = new IncomingTopLevel();
                model.IncomingVesselNo = incomingVesselNo;
                model.InspectionDateTime = date;
                model.Notes = notes;
                db.IncomingTopLevels.Add(model);

                foreach (var item in shipOut2Detail)
                {
                    IncomingDetail O = new IncomingDetail();
                    O.PartNumber = item.PartNumber;
                    O.InspectorName = item.InspectorName;
                    O.Notes = item.Notes;
                    O.QtyReceived = item.QtyReceived;
                    O.QtyInspected = item.QtyInspected;
                    O.QtyGood = item.QtyGood;
                    O.QtyBad = item.QtyBad;
                    db.IncomingDetails.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }*/

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
