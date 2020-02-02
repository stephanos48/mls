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
    public class WorkOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkOrders
        public ActionResult Index(int? id)
        {
            var viewModel = new ProductionIndexDataViewModel();
            viewModel.WorkOrders = db.WorkOrders
                .Include(i => i.WoDetails);

            if (id != null)
            {
                ViewBag.WorkOrderId = id.Value;
                viewModel.WoDetails = viewModel.WorkOrders.Single(
                    i => i.WorkOrderId == id.Value).WoDetails;
            }
            
            return View(viewModel);
        }

        public ActionResult ScheduleStockOut(int? id)
        {
            var viewModel = new ProductionStockOutViewModel();
            viewModel.WorkOrders = db.WorkOrders
                .Include(i => i.DownReports);

            if (id != null)
            {
                ViewBag.WorkOrderId = id.Value;
                viewModel.DownReports = viewModel.WorkOrders.Where(
                    i => i.WorkOrderId == id.Value).Single().DownReports;
            }

            return View(viewModel);
        }

        public ActionResult ProductionPlan()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId == 4 
                        orderby c.PromiseDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult Schedule1()
        {
            var query = from c in db.WorkOrders
                        where c.PartStockOutId == 7 && c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleAll()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleMinusBayne()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.CustomerDivisionId != 9
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleClosed()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId == 5
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleCanceled()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId == 6
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult Schedule2()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.CustomerDivisionId == 9
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleExtreme()
        {
            var query = from c in db.WorkOrders
                        where c.WoOrderStatusId == 7
                        orderby c.ShipDate ascending
                        select c;
            return View("Schedule2", query.ToList());
        }

        public ActionResult Schedule3()
        {
            var query = from c in db.WorkOrders
                        where c.MlsDivisionId == 4
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ProductionPlan1(int? id)
        {
            var viewModel = new ProductionIndexDataViewModel();
            viewModel.WorkOrders = db.WorkOrders
                .Include(i => i.WoDetails);

            if (id != null)
            {
                ViewBag.WorkOrderId = id.Value;
                viewModel.WoDetails = viewModel.WorkOrders.Single(
                    i => i.WorkOrderId == id.Value).WoDetails;
            }

            return View(viewModel);
        }

        // GET: WorkOrders
        public ActionResult WorkOrder()
        {
            return View();
        }

        // GET: WorkOrders
        public ActionResult PartStockOuts()
        {
            return View();
        }
        // GET: WorkOrders/WOUH/BayneActuators
        public ActionResult BayneActuators()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/BayneLifters
        public ActionResult BayneLifters()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/CylinderAssembly
        public ActionResult CylinderAssembly()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/
        public ActionResult WOUH()
        {
            return View();
        }

        // GET: WorkOrders/WDIP/
        public ActionResult WDIP()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/
        public ActionResult ChassisLiner()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/
        public ActionResult DOP()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/
        public ActionResult DTT()
        {
            return View();
        }

        // GET: WorkOrders/WOUH/
        public ActionResult WODivision()
        {
            return View();
        }

        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var woparttypes = db.WoPartTypes.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var ordertypes = db.OrderTypes.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var woorderstatuses = db.WoOrderStatuses.ToList();
            var partstockouts = db.PartStockOuts.ToList();
            
            var viewModel = new SaveWorkOrderViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                OrderTypes = ordertypes,
                WoPartTypes = woparttypes,
                MlsDivisions = mlsdivisions,
                WoOrderStatuses = woorderstatuses,
                PartStockOuts = partstockouts
            };

            return View("Create", viewModel);
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WorId,MlsDivisionId,PartTypeId,CustomerPn,Qty,CreationDate,StartTime,FinishTime,OrderTypeId,Sn,CustomerPo,MlsSo,Notes")] WorkOrder workOrder)
        public ActionResult Create (WorkOrder workOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View();
            //return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var workorders = db.WorkOrders.SingleOrDefault(c => c.WorkOrderId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var ordertypes = db.OrderTypes.ToList();
            var woparttypes = db.WoPartTypes.ToList();
            var woorderstatuses = db.WoOrderStatuses.ToList();
            var partstockouts = db.PartStockOuts.ToList();

            var viewModel = new SaveWorkOrderViewModel()
            {
                WorkOrder = workorders,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                WoPartTypes = woparttypes,
                OrderTypes = ordertypes,
                WoOrderStatuses =woorderstatuses,
                PartStockOuts = partstockouts
            };


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "WorId,MlsDivisionId,PartTypeId,CustomerPn,Qty,CreationDate,StartTime,FinishTime,OrderTypeId,Sn,CustomerPo,MlsSo,Notes")] WorkOrder workOrder)
        public ActionResult Edit(WorkOrder workOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrder workOrder = db.WorkOrders.Find(id);
            if (workOrder == null)
            {
                return HttpNotFound();
            }
            return View(workOrder);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrder workOrder = db.WorkOrders.Find(id);
            db.WorkOrders.Remove(workOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult _PartStockOut(int stockOutName)
        {
            var queryNew = from a in db.WorkOrders
                           where a.PartStockOutId == stockOutName
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    CustomerPo = order.CustomerPo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    PromiseDate = order.PromiseDate,
                    PartsNeeded = order.PartsNeeded,
                    PartStockOutNotes = order.PartStockOutNotes,
                    Notes = order.Notes
                });
            }
            return PartialView("_PartStockOutPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WoNewWorkOrders(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 1 && a.WoPartTypeId == woPartType 
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WONewPartialView", result);
        }

        public ActionResult _PpNewWorkOrders()
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 1
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    MlsDivisionId = order.MlsDivisionId,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WONewPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WoScheduling(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 2 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOSchedulingPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _PpScheduling()
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 2
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    MlsDivisionId = order.MlsDivisionId,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOSchedulingPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WoHold(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 3 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOHoldPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _PpHold()
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 3
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    MlsDivisionId = order.MlsDivisionId,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOHoldPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WoProduction(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 4 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOProductionPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _PpProduction()
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 4
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    MlsDivisionId = order.MlsDivisionId,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOProductionPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WOClosed(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 5 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,              
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOClosedPartialView", result);
        }

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _PpClosed()
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 5
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderViewModel> result = new List<NewWorkOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderViewModel
                {
                    WorkOrderId = order.WorkOrderId,
                    MlsSo = order.MlsSo,
                    MlsDivisionId = order.MlsDivisionId,
                    WorkOrderNumber = order.WorkOrderNumber,
                    Customer = order.Customer,
                    CreationDate = order.CreationDate,
                    CustomerPn = order.CustomerPn,
                    Qty = order.Qty,
                    CloseDate = order.CloseDate,
                    NeedDate = order.NeedDate,
                    PromiseDate = order.PromiseDate,
                    CustomerPo = order.CustomerPo,
                    StartTime = order.StartTime,
                    FinishTime = order.FinishTime,
                    OrderTypeId = order.OrderTypeId,
                    Notes = order.Notes
                });
            }
            return PartialView("_WOClosedPartialView", result);
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
