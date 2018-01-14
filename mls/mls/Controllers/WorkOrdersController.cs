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
        public ActionResult Index()
        {
            return View(db.WorkOrders.ToList());
        }

        // GET: WorkOrders
        public ActionResult WorkOrder()
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

            var woparttypes = db.WoPartTypes.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var ordertypes = db.OrderTypes.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var woorderstatuses = db.WoOrderStatuses.ToList();
            
            var viewModel = new SaveWorkOrderViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                OrderTypes = ordertypes,
                WoPartTypes = woparttypes,
                MlsDivisions = mlsdivisions,
                WoOrderStatuses = woorderstatuses
            };

            return View("Create", viewModel);
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WorId,MlsDivisionId,PartTypeId,CustomerPn,Qty,CreationDate,StartTime,FinishTime,OrderTypeId,Sn,CustomerPo,MlsSo,Notes")] WorkOrder workOrder)
        public ActionResult Create (WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.WorkOrders.Add(workOrder);
                db.SaveChanges();
                return RedirectToAction("Index", "WorkOrders");
            }

            return View();
            //return View(workOrder);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            var workorders = db.WorkOrders.SingleOrDefault(c => c.WorkOrderId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var ordertypes = db.OrderTypes.ToList();
            var woparttypes = db.WoPartTypes.ToList();
            var woorderstatuses = db.WoOrderStatuses.ToList();

            var viewModel = new SaveWorkOrderViewModel()
            {
                WorkOrder = workorders,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                WoPartTypes = woparttypes,
                OrderTypes = ordertypes,
                WoOrderStatuses =woorderstatuses
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
        public ActionResult Edit(WorkOrder workOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrder);
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

        // GET: WorkOrders/BayneLifters/Closed
        public ActionResult _WoNewWorkOrders(int woPartType)
        {
            var queryNew = from a in db.WorkOrders
                           where a.WoOrderStatusId == 1 && a.WoPartTypeId == woPartType 
                           orderby a.WorkOrderId descending
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
                           orderby a.WorkOrderId descending
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
                           orderby a.WorkOrderId descending
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
                           orderby a.WorkOrderId descending
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
                           orderby a.WorkOrderId descending
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
