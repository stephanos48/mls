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
    public class ShipOutsController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipOuts
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShipOuts
        /*public ActionResult ShipOut(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var query = from a in db.ShipOuts
                        orderby a.ShipDate descending
                        select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Pn.Contains(searchString) || s.PoNumber.Contains(searchString));


            }
            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Pn);
                    break;
                case "Date":
                    query = query.OrderBy(s => s.ShipDate);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.ShipDate);
                    break;
                default:
                    query = query.OrderBy(s => s.Pn);
                    break;
            }
            return View("ShipOut", query);
        }*/

        // GET: ShipOuts
        public ActionResult ShipOut()
        {
            var query = from a in db.ShipOuts
                        orderby a.ShipDate descending
                        select a;
           return View("ShipOut", query);
        }

        public ActionResult ShipOut90()
        {
            var baselinedate = DateTime.Now.AddDays(-90);
            var query = from a in db.ShipOuts
                        where a.ShipDate >= baselinedate
                        orderby a.ShipDate descending
                        select a;
            return View("ShipOut90", query);
        }

        // GET: ShipOuts
        public ActionResult WBShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 2 && a.CustomerDivisionId == 6
                        orderby a.ShipDate descending
                        select a;
            return View("WBShipOut", query);
        }

        // GET: ShipOuts
        public ActionResult HeilShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.ShipDate descending
                        select a;
            return View("HeilShipOut", query);
        }

        // GET: ShipOuts
        public ActionResult PcShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDate descending
                        select a;
            return View("PcShipOut", query);
        }

        // GET: ShipOuts
        public ActionResult ChShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 21 && a.CustomerDivisionId == 7
                        orderby a.ShipDate descending
                        select a;
            return View("ChShipOut", query);
        }

        // GET: ShipOuts
        public ActionResult ThiShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 8
                        orderby a.ShipDate descending
                        select a;
            return View("ThiShipOut", query);
        }

        // GET: ShipOuts
        public ActionResult JbtOrlandoShipOut()
        {
            var query = from a in db.ShipOuts
                        where a.CustomerId == 19
                        orderby a.ShipDate descending
                        select a;
            return View("JbtOrlandoShipOut", query);
        }

        // GET: ROShipOuts
        public ActionResult ROShipOut()
        {
            var query = from a in db.ShipOuts
                        orderby a.ShipDate descending
                        select a;
            return View("ROShipOut", query);
        }

        // GET: ShipOuts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return HttpNotFound();
            }
            return View(shipOut);
        }

        // GET: ShipOuts/Details/5
        public ActionResult RODetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return HttpNotFound();
            }
            return View(shipOut);
        }

        // GET: ShipOuts/Details/5
        public ActionResult JbtDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut jbtshipOut = db.ShipOuts.Find(id);
            if (jbtshipOut == null)
            {
                return HttpNotFound();
            }
            return View(jbtshipOut);
        }

        // GET: ShipOuts/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var freighttypes = db.FreightTypes.ToList();
            var fpaymentmethods = db.FPaymentMethods.ToList();

            var viewModel = new SaveShipOutViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                FreightTypes = freighttypes,
                FPaymentMetods = fpaymentmethods

            };
            return View("Create", viewModel);

            //return View();
        }

        // POST: ShipOuts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShipOutId,CustomerId,CustomerDivisionId,FreightTypeId,FPaymentMethodId,Carrier,TrackingInfo,Destination,Quote,SoldTo,ShipTo,ShipCity,ShipState,ShipZip,ShipDescription,ShipWeight,ManifestNo,PoNumber,SoNumber,PalletNo,Pn,Sn,ShipDate,Quantity")] ShipOut shipOut)
        public ActionResult Create(ShipOut shipOut)
        {
            if (ModelState.IsValid)
            {
                db.ShipOuts.Add(shipOut);
                db.SaveChanges();
                return RedirectToAction("Index", "ShipIns");
            }

            return View();
            //return View(shipOut);
        }

        // GET: ShipOuts/Edit/5
        public ActionResult Edit(int? id)
        {

            var shipouts = db.ShipOuts.SingleOrDefault(c => c.ShipOutId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var freighttypes = db.FreightTypes.ToList();
            var fpaymentmethods = db.FPaymentMethods.ToList();

            var viewModel = new SaveShipOutViewModel()
            {
                ShipOut = shipouts,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                FreightTypes = freighttypes,
                FPaymentMetods = fpaymentmethods

            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: ShipOuts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShipOutId,CustomerId,CustomerDivisionId,FreightTypeId,FPaymentMethodId,Carrier,TrackingInfo,Destination,Quote,SoldTo,ShipTo,ShipCity,ShipState,ShipZip,ShipDescription,ShipWeight,ManifestNo,PoNumber,SoNumber,PalletNo,Pn,Sn,ShipDate,Quantity")] ShipOut shipOut)
        public ActionResult Edit(ShipOut shipOut)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipOut).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ShipIns");
            }
            return View();
        }

        // GET: ShipOuts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipOut shipOut = db.ShipOuts.Find(id);
            if (shipOut == null)
            {
                return HttpNotFound();
            }
            return View(shipOut);
        }

        // POST: ShipOuts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipOut shipOut = db.ShipOuts.Find(id);
            db.ShipOuts.Remove(shipOut);
            db.SaveChanges();
            return RedirectToAction("Index", "ShipIns");
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
