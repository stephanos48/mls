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
using System.Data.SqlClient;

namespace mls.Controllers
{
    [Authorize]
    public class ShipPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipPlans
        public ActionResult HydOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HydOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DipOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DipOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DttOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DttOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult CLOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 3
                        orderby a.ShipDateTime ascending
                        select a;
            return View("CLOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DopOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 5
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DopOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ShipPlanPrintHyd()
        {
            var baselinedate = DateTime.Now.AddDays(-90);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbRoPrintHyd", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed()
        {
            var baselinedate = DateTime.Now.AddDays(-90);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed180less()
        {
            var baselinedate = DateTime.Now.AddDays(-180);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed90()
        {
            var startdate = DateTime.Now.AddDays(-90);
            var enddate = DateTime.Now.AddDays(-180);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= startdate && a.ShipDateTime <= enddate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed180()
        {
            var startdate = DateTime.Now.AddDays(-180);
            var enddate = DateTime.Now.AddDays(-365);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= startdate && a.ShipDateTime <= enddate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed365less()
        {
            var baselinedate = DateTime.Now.AddDays(-365);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed365()
        {
            var baselinedate = DateTime.Now.AddDays(-365);
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime <= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult Slotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7
                        orderby a.ShipDateTime ascending
                        select a;
            return View("Slotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult CanceledOrders()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("CanceledOrders", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult LookUp()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("LookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgLookUp()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.CustomerId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("LookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcLookUp()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.CustomerPn ascending
                        select a;
            return View("EsgLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: ShipPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlan shipPlan = db.ShipPlans.Find(id);
            if (shipPlan == null)
            {
                return HttpNotFound();
            }
            return View(shipPlan);
        }

        // GET: ShipPlans/Details/5
        public ActionResult RoDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlan shipPlan = db.ShipPlans.Find(id);
            if (shipPlan == null)
            {
                return HttpNotFound();
            }
            return View(shipPlan);
        }

        // GET: ShipPlans/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.ShipPlanStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveShipPlanViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                ShipPlanStatuses = statuses,
                CQStatuses = cqstatuses
            };

            return View("Create", viewModel);
        }

        // POST: ShipPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShipPlanId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,OrderStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] ShipPlan shipPlan)
        public ActionResult Create(ShipPlan shipPlan, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.ShipPlans.Add(shipPlan);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            //return View(shipPlan);
            return View();
        }

        // GET: ShipPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var shipplans = db.ShipPlans.SingleOrDefault(c => c.ShipPlanId == id);

            var statuses = db.ShipPlanStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveShipPlanViewModel()
            {
                ShipPlan = shipplans,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                ShipPlanStatuses = statuses,
                CQStatuses = cqstatuses
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlan shipPlan = db.ShipPlans.Find(id);
            if (shipPlan == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(shipPlan);
        }

        // POST: ShipPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShipPlanId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,OrderStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] ShipPlan shipPlan)
        public ActionResult Edit(ShipPlan shipPlan, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipPlan).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(shipPlan);
        }

        // GET: ShipPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlan shipPlan = db.ShipPlans.Find(id);
            if (shipPlan == null)
            {
                return HttpNotFound();
            }
            return View(shipPlan);
        }

        // POST: ShipPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipPlan shipPlan = db.ShipPlans.Find(id);
            db.ShipPlans.Remove(shipPlan);
            db.SaveChanges();
            return RedirectToAction("ShipPlanStatus");
        }

        public ActionResult _ShipNew(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == 1
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipNew", result);
        }

        public ActionResult _ShipIssue(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == 2
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipIssue", result);
        }

        public ActionResult _ShipHot(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.CQStatusId == 1
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipHot", result);
        }

        public ActionResult _ShipPcHotCustomer(int customer, int division)
        {
            var queryNew = from a in db.ShipPlans
                           where a.CQStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == 9
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipHotCustomer", result);
        }

        public ActionResult _ShipHotCustomer(int customer)
        {
            var queryNew = from a in db.ShipPlans
                           where a.CQStatusId == 1 && a.CustomerId == customer
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipHotCustomer", result);
        }

        public ActionResult _ShipPrep(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == 3
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipPrep", result);
        }

        public ActionResult _ShipCarrierPickUp(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == 4
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_ShipCarrierPickUp", result);
        }

        public ActionResult _OrdersToCancel(int status)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == status
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_OrdersToCancel", result);
        }

        public ActionResult _OrderIssuesCustomer(int status, int customer)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == status && a.CustomerId == customer
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_OrdersToCancel", result);
        }

        public ActionResult _PcOrderIssuesCustomer(int status, int customer, int division)
        {
            var queryNew = from a in db.ShipPlans
                           where a.ShipPlanStatusId == status && a.CustomerId == customer && a.CustomerDivisionId == division
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanViewModel> result = new List<NewShipPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanViewModel
                {
                    ShipPlanId = sp.ShipPlanId,
                    CustomerPn = sp.CustomerPn,
                    CustomerOrderNo = sp.CustomerOrderNo,
                    CustomerOrderLine = sp.CustomerOrderLine,
                    SoNumber = sp.SoNumber,
                    OrderQty = sp.OrderQty,
                    ShipQty = sp.ShipQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ShipDateTime = sp.ShipDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_OrdersToCancel", result);
        }

        public ActionResult ShipPlanStatus()
        {
            return View("ShipPlanStatus");
        }

        public ActionResult Sales()
        {
            return View("Sales");
        }

        public ActionResult HydSales()
        {
            return View("HydSales");
        }

        public ActionResult DipSales()
        {
            return View("DipSales");
        }

        public ActionResult DttSales()
        {
            return View("DttSales");
        }

        public ActionResult DopSales()
        {
            return View("DopSales");
        }

        public ActionResult ClSales()
        {
            return View("ClSales");
        }

        public ActionResult EsgStatus()
        {
            return View("EsgStatus");
        }

        public ActionResult EsgPcStatus()
        {
            return View("EsgPcStatus");
        }

        public ActionResult JbtStatus()
        {
            return View("JbtStatus");
        }

        public ActionResult WbStatus()
        {
            return View("WbStatus");
        }

        public ActionResult ChStatus()
        {
            return View("ChStatus");
        }

        public ActionResult ThiStatus()
        {
            return View("ThiStatus");
        }

        public ActionResult HunterStatus()
        {
            return View("HunterStatus");
        }

        public ActionResult EsgOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgPcOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgRoOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.CustomerId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime descending
                        select a;
            return View("EsgPcShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 1
                        orderby a.ShipDateTime descending
                        select a;
            return View("EsgRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 19
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtOgdRoOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 7 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOgdRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtOrlRoOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 7 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOrlRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 19
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 19
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 19
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOrlRoShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtOrlRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdRoShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtOgdRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbOpenDip()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpenDip", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbOpenHyd()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpenHyd", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbDip()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbDip", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbHyd()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbHyd", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbAll()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbAll", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 2
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbRoShippedWb()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 2
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbRoShippedWb", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ThiRoOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ThiCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 8
                        orderby a.ShipDateTime descending
                        select a;
            return View("ThiShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 8
                        orderby a.ShipDateTime descending
                        select a;
            return View("ThiRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ChCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 21
                        orderby a.ShipDateTime descending
                        select a;
            return View("ChShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterOpen()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult HunterCanceled()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterSlotted()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterShipped()
        {
            var query = from a in db.ShipPlans
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 4
                        orderby a.ShipDateTime descending
                        select a;
            return View("HunterShipped", query);
            //return View(db.Requisitions.ToList());
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
