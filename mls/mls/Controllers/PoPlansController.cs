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
using Microsoft.AspNet.Identity;

namespace mls.Controllers
{
    [Authorize]
    public class PoPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PoPlans
        public ActionResult Index()
        {
            return View(db.PoPlans.ToList());
        }

        public ActionResult PoPlanStatus()
        {
            return View("PoPlanStatus");
        }

        public ActionResult PoPlanClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("PoPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 8
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("ThiRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOrlRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("JbtOrlRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("JbtOgdRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 1
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("EsgRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult VtRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 1
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("VtRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("EsgPcClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbRoClosedWb()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 2
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("WbRoClosedWb", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult PoPlanCanceled()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 7
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("PoPlanCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult InTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2
                        orderby a.ContainerUh descending
                        select a;
            return View("InTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 8
                        orderby a.ContainerUh descending
                        select a;
            return View("ThiRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOrlRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ContainerUh descending
                        select a;
            return View("JbtOrlRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ContainerUh descending
                        select a;
            return View("JbtOgdRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 1
                        orderby a.ContainerUh descending
                        select a;
            return View("EsgRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult VtRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 1 
                        orderby a.ContainerUh descending
                        select a;
            return View("VtRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ContainerUh descending
                        select a;
            return View("EsgPcTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbRoTransitWb()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 2
                        orderby a.ContainerUh descending
                        select a;
            return View("WbRoTransitWb", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HydOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 1
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("HydOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DipOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 4
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DipOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DttOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 2
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DttOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DopOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 5
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DopOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ClOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 3
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("ClOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult LookUp()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId != 5 && a.PoOrderStatusId != 6 && a.PoOrderStatusId != 7
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("LookUp", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: PoPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // GET: PoPlans/Details/5
        public ActionResult RoDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // GET: PoPlans/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.PoOrderStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SavePoPlanViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PoOrderStatuses = statuses,
                Suppliers = suppliers
            };

            return View("Create", viewModel);
        }

        // POST: PoPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PoPlanId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,PoOrderStatusId,Notes")] PoPlan poPlan)
        public ActionResult Create(PoPlan poPlan, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.PoPlans.Add(poPlan);
                db.SaveChanges();
                LogCreatePoPlanActivity(poPlan);
                return Redirect(returnUrl);
                //return RedirectToAction("PoPlanStatus");
            }

            //return View(poPlan);
            return View();
        }

        public ActionResult LogCreatePoPlanActivity(PoPlan poPlan)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Create";

            PoPlanLog poPlanLog = new PoPlanLog();

            poPlanLog.User = currentUser;
            poPlanLog.EventDateTime = logDateTime;
            poPlanLog.EventType = eventType;
            poPlanLog.PoPlanId = poPlan.PoPlanId;
            poPlanLog.PoNumber = poPlan.PoNumber;
            poPlanLog.PoLine = poPlan.PoLine;
            poPlanLog.CustomerId = poPlan.CustomerId;
            poPlanLog.CustomerDivisionId = poPlan.CustomerDivisionId;
            poPlanLog.MlsDivisionId = poPlan.MlsDivisionId;
            poPlanLog.CustomerPn = poPlan.CustomerPn;
            poPlanLog.UhPn = poPlan.UhPn;
            poPlanLog.SupplierId = poPlan.SupplierId;
            poPlanLog.CustomerOrderNumber = poPlan.CustomerOrderNumber;
            poPlanLog.SoNumber = poPlan.SoNumber;
            poPlanLog.OrderQty = poPlan.OrderQty;
            poPlanLog.ReceivedQty = poPlan.ReceivedQty;
            poPlanLog.ContainerId = poPlan.ContainerId;
            poPlanLog.OrderDateTime = poPlan.OrderDateTime;
            poPlanLog.ContainerUh = poPlan.ContainerUh;
            poPlanLog.AMS = poPlan.AMS;
            poPlanLog.ArrivalWk = poPlan.ArrivalWk;
            poPlanLog.BOL = poPlan.BOL;
            poPlanLog.Destination = poPlan.Destination;
            poPlanLog.Etadate = poPlan.Etadate;
            poPlanLog.FreightFowarder = poPlan.FreightFowarder;
            poPlanLog.Invoice = poPlan.Invoice;
            poPlanLog.Pallet = poPlan.Pallet;
            poPlanLog.PartDescription = poPlan.PartDescription;
            poPlanLog.PoConfirmedBy = poPlan.PoConfirmedBy;
            poPlanLog.RequestedDateTime = poPlan.RequestedDateTime;
            poPlanLog.ReceiptDateTime = poPlan.ReceiptDateTime;
            poPlanLog.Shipdate = poPlan.Shipdate;
            poPlanLog.PromiseDateTime = poPlan.PromiseDateTime;
            poPlanLog.PoSentDateTime = poPlan.PoSentDateTime;
            poPlanLog.PoSentBy = poPlan.PoSentBy;
            poPlanLog.PoOrderStatusId = poPlan.PoOrderStatusId;
            poPlanLog.PoConfirmedDateTime = poPlan.PoConfirmedDateTime;
            poPlanLog.Notes = poPlan.Notes;

            db.PoPlanLogs.Add(poPlanLog);
            db.SaveChanges();
            return null;
        }

        // GET: PoPlans/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var poplans = db.PoPlans.SingleOrDefault(c => c.PoPlanId == id);

            var statuses = db.PoOrderStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SavePoPlanViewModel()
            {
                PoPlan = poplans,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PoOrderStatuses = statuses,
                Suppliers = suppliers
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(poPlan);
        }

        // POST: PoPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PoPlanId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,PoOrderStatusId,Notes")] PoPlan poPlan)
        public ActionResult Edit(PoPlan poPlan, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poPlan).State = EntityState.Modified;
                db.SaveChanges();
                LogEditPoPlanActivity(poPlan);
                return Redirect(returnUrl);
                //return RedirectToAction("PoPlanStatus");
            }
            return View();
            //return View(poPlan);
        }

        public ActionResult LogEditPoPlanActivity(PoPlan poPlan)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Edit";

            PoPlanLog poPlanLog = new PoPlanLog();

            poPlanLog.User = currentUser;
            poPlanLog.EventDateTime = logDateTime;
            poPlanLog.EventType = eventType;
            poPlanLog.PoPlanId = poPlan.PoPlanId;
            poPlanLog.PoNumber = poPlan.PoNumber;
            poPlanLog.PoLine = poPlan.PoLine;
            poPlanLog.CustomerId = poPlan.CustomerId;
            poPlanLog.CustomerDivisionId = poPlan.CustomerDivisionId;
            poPlanLog.MlsDivisionId = poPlan.MlsDivisionId;
            poPlanLog.CustomerPn = poPlan.CustomerPn;
            poPlanLog.UhPn = poPlan.UhPn;
            poPlanLog.SupplierId = poPlan.SupplierId;
            poPlanLog.CustomerOrderNumber = poPlan.CustomerOrderNumber;
            poPlanLog.SoNumber = poPlan.SoNumber;
            poPlanLog.OrderQty = poPlan.OrderQty;
            poPlanLog.ReceivedQty = poPlan.ReceivedQty;
            poPlanLog.ContainerId = poPlan.ContainerId;
            poPlanLog.OrderDateTime = poPlan.OrderDateTime;
            poPlanLog.ContainerUh = poPlan.ContainerUh;
            poPlanLog.AMS = poPlan.AMS;
            poPlanLog.ArrivalWk = poPlan.ArrivalWk;
            poPlanLog.BOL = poPlan.BOL;
            poPlanLog.Destination = poPlan.Destination;
            poPlanLog.Etadate = poPlan.Etadate;
            poPlanLog.FreightFowarder = poPlan.FreightFowarder;
            poPlanLog.Invoice = poPlan.Invoice;
            poPlanLog.Pallet = poPlan.Pallet;
            poPlanLog.PartDescription = poPlan.PartDescription;
            poPlanLog.PoConfirmedBy = poPlan.PoConfirmedBy;
            poPlanLog.RequestedDateTime = poPlan.RequestedDateTime;
            poPlanLog.ReceiptDateTime = poPlan.ReceiptDateTime;
            poPlanLog.Shipdate = poPlan.Shipdate;
            poPlanLog.PromiseDateTime = poPlan.PromiseDateTime;
            poPlanLog.PoSentDateTime = poPlan.PoSentDateTime;
            poPlanLog.PoSentBy = poPlan.PoSentBy;
            poPlanLog.PoOrderStatusId = poPlan.PoOrderStatusId;
            poPlanLog.PoConfirmedDateTime = poPlan.PoConfirmedDateTime;
            poPlanLog.Notes = poPlan.Notes;

            db.PoPlanLogs.Add(poPlanLog);
            db.SaveChanges();
            return null;
        }

        // GET: PoPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // POST: PoPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            PoPlan poPlan = db.PoPlans.Find(id);
            db.PoPlans.Remove(poPlan);
            db.SaveChanges();
            LogDeletePoPlanActivity(poPlan);
            return Redirect(returnUrl);
        }

        public ActionResult LogDeletePoPlanActivity(PoPlan poPlan)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Delete";

            PoPlanLog poPlanLog = new PoPlanLog();

            poPlanLog.User = currentUser;
            poPlanLog.EventDateTime = logDateTime;
            poPlanLog.EventType = eventType;
            poPlanLog.PoPlanId = poPlan.PoPlanId;
            poPlanLog.PoNumber = poPlan.PoNumber;
            poPlanLog.PoLine = poPlan.PoLine;
            poPlanLog.CustomerId = poPlan.CustomerId;
            poPlanLog.CustomerDivisionId = poPlan.CustomerDivisionId;
            poPlanLog.MlsDivisionId = poPlan.MlsDivisionId;
            poPlanLog.CustomerPn = poPlan.CustomerPn;
            poPlanLog.UhPn = poPlan.UhPn;
            poPlanLog.SupplierId = poPlan.SupplierId;
            poPlanLog.CustomerOrderNumber = poPlan.CustomerOrderNumber;
            poPlanLog.SoNumber = poPlan.SoNumber;
            poPlanLog.OrderQty = poPlan.OrderQty;
            poPlanLog.ReceivedQty = poPlan.ReceivedQty;
            poPlanLog.ContainerId = poPlan.ContainerId;
            poPlanLog.OrderDateTime = poPlan.OrderDateTime;
            poPlanLog.ContainerUh = poPlan.ContainerUh;
            poPlanLog.AMS = poPlan.AMS;
            poPlanLog.ArrivalWk = poPlan.ArrivalWk;
            poPlanLog.BOL = poPlan.BOL;
            poPlanLog.Destination = poPlan.Destination;
            poPlanLog.Etadate = poPlan.Etadate;
            poPlanLog.FreightFowarder = poPlan.FreightFowarder;
            poPlanLog.Invoice = poPlan.Invoice;
            poPlanLog.Pallet = poPlan.Pallet;
            poPlanLog.PartDescription = poPlan.PartDescription;
            poPlanLog.PoConfirmedBy = poPlan.PoConfirmedBy;
            poPlanLog.RequestedDateTime = poPlan.RequestedDateTime;
            poPlanLog.ReceiptDateTime = poPlan.ReceiptDateTime;
            poPlanLog.Shipdate = poPlan.Shipdate;
            poPlanLog.PromiseDateTime = poPlan.PromiseDateTime;
            poPlanLog.PoSentDateTime = poPlan.PoSentDateTime;
            poPlanLog.PoSentBy = poPlan.PoSentBy;
            poPlanLog.PoOrderStatusId = poPlan.PoOrderStatusId;
            poPlanLog.PoConfirmedDateTime = poPlan.PoConfirmedDateTime;
            poPlanLog.Notes = poPlan.Notes;

            db.PoPlanLogs.Add(poPlanLog);
            db.SaveChanges();
            return null;
        }

        public ActionResult _Issues(int status)
        {
            var queryNew = from a in db.PoPlans
                           where a.PoOrderStatusId == status
                           orderby a.ReceiptDateTime ascending
                           select a;
            List<NewPoPlanViewModel> result = new List<NewPoPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewPoPlanViewModel
                {
                    PoPlanId = sp.PoPlanId,
                    CustomerPn = sp.CustomerPn,
                    OrderDateTime = sp.OrderDateTime,
                    PoNumber = sp.PoNumber,
                    PoLine = sp.PoLine,
                    OrderQty = sp.OrderQty,
                    ReceivedQty = sp.ReceivedQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ReceiptDateTime = sp.ReceiptDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_Issues", result);
        }

        public ActionResult _Cancel(int status)
        {
            var queryNew = from a in db.PoPlans
                           where a.PoOrderStatusId == status
                           orderby a.ReceiptDateTime ascending
                           select a;
            List<NewPoPlanViewModel> result = new List<NewPoPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewPoPlanViewModel
                {
                    PoPlanId = sp.PoPlanId,
                    CustomerPn = sp.CustomerPn,
                    OrderDateTime = sp.OrderDateTime,
                    PoNumber = sp.PoNumber,
                    PoLine = sp.PoLine,
                    OrderQty = sp.OrderQty,
                    ReceivedQty = sp.ReceivedQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ReceiptDateTime = sp.ReceiptDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_Cancel", result);
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
