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
using System.IO;
using Microsoft.AspNet.Identity;

namespace mls.Controllers
{
    [Authorize]
    public class WorkOrderFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkOrderFs
        /*public ActionResult Index()
        {
            return View(db.WorkOrderFs.ToList());
        }*/

        public ActionResult Index(int? id)
        {
            var viewModel = new ProductionIndexDataFViewModel();
            viewModel.WorkOrderFs = db.WorkOrderFs
                .Include(i => i.WoFDetails);

            if (id != null)
            {
                ViewBag.WorkOrderId = id.Value;
                viewModel.WoFDetails = viewModel.WorkOrderFs.Single(
                    i => i.WorkOrderFId == id.Value).WoFDetails;
            }

            return View(viewModel);
        }

        /*
        public ActionResult ProcessWO(WorkOrderF workOrderF)
        {
            int nextid;
            WorkOrderF WoF = new WorkOrderF();

            if (woid == 1)
            {
                nextid = woid + 1;

            }

        }
        */
        public ActionResult ScheduleStockOut(int? id)
        {
            var viewModel = new ProductionStockOutFViewModel();
            viewModel.WorkOrderFs = db.WorkOrderFs
                .Include(i => i.DownReports);

            if (id != null)
            {
                ViewBag.WorkOrderFId = id.Value;
                viewModel.DownReports = viewModel.WorkOrderFs.Where(
                    i => i.WorkOrderFId == id.Value).Single().DownReports;
            }

            return View(viewModel);
        }

        public ActionResult ProductionPlan()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 4
                        orderby c.PromiseDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult Schedule1()
        {
            var query = from c in db.WorkOrderFs
                        where c.PartStockOutId == 7 && c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.WoOrderStatusId != 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleAll()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.WoOrderStatusId != 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleChassis()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.MlsDivisionId == 3 && c.WoOrderStatusId != 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult CylRework()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.WoPartTypeId == 13 && c.WoOrderStatusId != 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult CylTest()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 3 && c.WoPartTypeId == 11 && c.WoOrderStatusId != 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleMinusBayne()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId != 3 && c.WoOrderStatusId != 5 && c.WoOrderStatusId != 6 && c.WoOrderStatusId != 7 && c.WoOrderStatusId != 8 && c.CustomerDivisionId != 9 && c.MlsDivisionId != 3 && c.WoPartTypeId != 11 && c.WoPartTypeId != 13
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleOnHold()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 3
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleClosed()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 5
                        orderby c.ShipDate descending
                        select c;
            return View(query.ToList());
        }

        public ActionResult FinalReview()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 7
                        orderby c.ShipDate descending
                        select c;
            return View("FinalReview", query.ToList());
        }

        public ActionResult ClosedNeedSageUpdate()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 8
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleCanceled()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 6
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult Schedule2()
        {
            var query = from c in db.WorkOrderFs
                        where c.WoOrderStatusId == 4 && (c.WoPartTypeId == 1 || c.WoPartTypeId == 2 || c.WoPartTypeId == 10)
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ScheduleExtreme()
        {
            var query = from c in db.WorkOrderFs
                        where c.ContractorId == 2 && (c.WoOrderStatusId == 4 || c.WoOrderStatusId == 1 || c.WoOrderStatusId == 2)
                        orderby c.ShipDate ascending
                        select c;
            return View("ScheduleExtreme", query.ToList());
        }

        public ActionResult ExtremeClosed()
        {
            var query = from c in db.WorkOrderFs
                        where c.ContractorId == 2 && c.WoOrderStatusId == 5
                        orderby c.ShipDate ascending
                        select c;
            return View("ExtremeClosed", query.ToList());
        }

        public ActionResult Schedule3()
        {
            var query = from c in db.WorkOrderFs
                        where c.MlsDivisionId == 4
                        orderby c.ShipDate ascending
                        select c;
            return View(query.ToList());
        }

        public ActionResult ProductionPlan1(int? id)
        {
            var viewModel = new ProductionIndexDataFViewModel();
            viewModel.WorkOrderFs = db.WorkOrderFs
                .Include(i => i.WoFDetails);

            if (id != null)
            {
                ViewBag.WorkOrderFId = id.Value;
                viewModel.WoFDetails = viewModel.WorkOrderFs.Single(
                    i => i.WorkOrderFId == id.Value).WoFDetails;
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

        // GET: WorkOrderFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrderF workOrderF = db.WorkOrderFs.Find(id);
            if (workOrderF == null)
            {
                return HttpNotFound();
            }
            return View(workOrderF);
        }

        // GET: WorkOrderFs/Create
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
            var contractors = db.Contractors.ToList();

            var viewModel = new SaveWorkOrderFViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                OrderTypes = ordertypes,
                WoPartTypes = woparttypes,
                MlsDivisions = mlsdivisions,
                WoOrderStatuses = woorderstatuses,
                PartStockOuts = partstockouts,
                Contractors = contractors
            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: WorkOrderFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WorkOrderFId,CustomerId,CustomerDivisionId,MlsDivisionId,ContractorId,WoPartTypeId,WorkOrderNumber,NeedDate,PromiseDate,ShipDate,CustomerPn,Qty,CreationDate,StartTime,FinishTime,CloseDate,OrderTypeId,SageJournalNo,Sn,NewSn,CustomerPo,MlsSo,WoOrderStatusId,PartStockOutId,WoNotes,PartsNeeded,PartStockOutNotes,Parts,Equipment,Resources,Notes,Day1,Day2,Day3,Day4,Day5,Day6,Day7,Day8,Day9,Day10,Wk3,Wk4,Wk5,Wk6,Wk7,Wk8")] WorkOrderF workOrderF)
        public ActionResult Create(WorkOrderF workOrderF, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                List<FileWoDetail> fileWoDetails = new List<FileWoDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileWoDetail fileWoDetail = new FileWoDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileWoDetails.Add(fileWoDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileWoDetail.Id + fileWoDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                workOrderF.FileWoDetails = fileWoDetails;
                db.WorkOrderFs.Add(workOrderF);
                db.SaveChanges();
                LogCreateWorkOrderActivity(workOrderF);
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }

            return View();
            //return View(workOrderF);
        }

        public ActionResult LogCreateWorkOrderActivity(WorkOrderF workOrderF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Create";

            WorkOrderLog workOrderLog = new WorkOrderLog();

            workOrderLog.User = currentUser;
            workOrderLog.EventDateTime = logDateTime;
            workOrderLog.EventType = eventType;
            workOrderLog.WorkOrderFId = workOrderF.WorkOrderFId;
            workOrderLog.CreationDate = workOrderF.CreationDate;
            workOrderLog.CustomerId = workOrderF.CustomerId;
            workOrderLog.CustomerDivisionId = workOrderF.CustomerDivisionId;
            workOrderLog.MlsDivisionId = workOrderF.MlsDivisionId;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.ContractorId = workOrderF.ContractorId;
            workOrderLog.WoPartTypeId = workOrderF.WoPartTypeId;
            workOrderLog.WorkOrderNumber = workOrderF.WorkOrderNumber;
            workOrderLog.NeedDate = workOrderF.NeedDate;
            workOrderLog.PromiseDate = workOrderF.PromiseDate;
            workOrderLog.ShipDate = workOrderF.ShipDate;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.Qty = workOrderF.Qty;
            workOrderLog.StartTime = workOrderF.StartTime;
            workOrderLog.FinishTime = workOrderF.FinishTime;
            workOrderLog.CloseDate = workOrderF.CloseDate;
            workOrderLog.OrderTypeId = workOrderF.OrderTypeId;
            workOrderLog.SageJournalNo = workOrderF.SageJournalNo;
            workOrderLog.Sn = workOrderF.Sn;
            workOrderLog.NewSn = workOrderF.NewSn;
            workOrderLog.CustomerPo = workOrderF.CustomerPo;
            workOrderLog.MlsSo = workOrderF.MlsSo;
            workOrderLog.WoOrderStatusId = workOrderF.WoOrderStatusId;
            workOrderLog.PartStockOutId = workOrderF.PartStockOutId;
            workOrderLog.WoNotes = workOrderF.WoNotes;
            workOrderLog.PartsNeeded = workOrderF.PartsNeeded;
            workOrderLog.PartStockOutNotes = workOrderF.PartStockOutNotes;
            workOrderLog.Parts = workOrderF.Parts;
            workOrderLog.Equipment = workOrderF.Equipment;
            workOrderLog.Resources = workOrderF.Resources;
            workOrderLog.Notes = workOrderF.Notes;

            db.WorkOrderLogs.Add(workOrderLog);
            db.SaveChanges();
            return null;
        }

        // GET: WorkOrderFs/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var workorderFs = db.WorkOrderFs.SingleOrDefault(c => c.WorkOrderFId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var ordertypes = db.OrderTypes.ToList();
            var woparttypes = db.WoPartTypes.ToList();
            var woorderstatuses = db.WoOrderStatuses.ToList();
            var partstockouts = db.PartStockOuts.ToList();
            var contractors = db.Contractors.ToList();

            var viewModel = new SaveWorkOrderFViewModel()
            {
                WorkOrderF = workorderFs,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                WoPartTypes = woparttypes,
                OrderTypes = ordertypes,
                WoOrderStatuses = woorderstatuses,
                PartStockOuts = partstockouts,
                Contractors = contractors
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrderF workOrderF = db.WorkOrderFs.Include(s => s.FileWoDetails).SingleOrDefault(x => x.WorkOrderFId == id);
            //WorkOrderF workOrderF = db.WorkOrderFs.Find(id);
            if (workOrderF == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(workOrderF);
        }

        // POST: WorkOrderFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "WorkOrderFId,CustomerId,CustomerDivisionId,MlsDivisionId,ContractorId,WoPartTypeId,WorkOrderNumber,NeedDate,PromiseDate,ShipDate,CustomerPn,Qty,CreationDate,StartTime,FinishTime,CloseDate,OrderTypeId,SageJournalNo,Sn,NewSn,CustomerPo,MlsSo,WoOrderStatusId,PartStockOutId,WoNotes,PartsNeeded,PartStockOutNotes,Parts,Equipment,Resources,Notes,Day1,Day2,Day3,Day4,Day5,Day6,Day7,Day8,Day9,Day10,Wk3,Wk4,Wk5,Wk6,Wk7,Wk8")] WorkOrderF workOrderF)
        public ActionResult Edit(WorkOrderF workOrderF, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileWoDetail fileWoDetail = new FileWoDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            WorkOrderFId = workOrderF.WorkOrderFId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileWoDetail.Id + fileWoDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileWoDetail).State = EntityState.Added;
                    }
                }

                db.Entry(workOrderF).State = EntityState.Modified;
                db.SaveChanges();
                LogEditWorkOrderActivity(workOrderF);
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
            //return View(workOrderF);
        }

        public ActionResult LogEditWorkOrderActivity(WorkOrderF workOrderF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Edit";

            WorkOrderLog workOrderLog = new WorkOrderLog();

            workOrderLog.User = currentUser;
            workOrderLog.EventDateTime = logDateTime;
            workOrderLog.EventType = eventType;
            workOrderLog.WorkOrderFId = workOrderF.WorkOrderFId;
            workOrderLog.CreationDate = workOrderF.CreationDate;
            workOrderLog.CustomerId = workOrderF.CustomerId;
            workOrderLog.CustomerDivisionId = workOrderF.CustomerDivisionId;
            workOrderLog.MlsDivisionId = workOrderF.MlsDivisionId;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.ContractorId = workOrderF.ContractorId;
            workOrderLog.WoPartTypeId = workOrderF.WoPartTypeId;
            workOrderLog.WorkOrderNumber = workOrderF.WorkOrderNumber;
            workOrderLog.NeedDate = workOrderF.NeedDate;
            workOrderLog.PromiseDate = workOrderF.PromiseDate;
            workOrderLog.ShipDate = workOrderF.ShipDate;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.Qty = workOrderF.Qty;
            workOrderLog.StartTime = workOrderF.StartTime;
            workOrderLog.FinishTime = workOrderF.FinishTime;
            workOrderLog.CloseDate = workOrderF.CloseDate;
            workOrderLog.OrderTypeId = workOrderF.OrderTypeId;
            workOrderLog.SageJournalNo = workOrderF.SageJournalNo;
            workOrderLog.Sn = workOrderF.Sn;
            workOrderLog.NewSn = workOrderF.NewSn;
            workOrderLog.CustomerPo = workOrderF.CustomerPo;
            workOrderLog.MlsSo = workOrderF.MlsSo;
            workOrderLog.WoOrderStatusId = workOrderF.WoOrderStatusId;
            workOrderLog.PartStockOutId = workOrderF.PartStockOutId;
            workOrderLog.WoNotes = workOrderF.WoNotes;
            workOrderLog.PartsNeeded = workOrderF.PartsNeeded;
            workOrderLog.PartStockOutNotes = workOrderF.PartStockOutNotes;
            workOrderLog.Parts = workOrderF.Parts;
            workOrderLog.Equipment = workOrderF.Equipment;
            workOrderLog.Resources = workOrderF.Resources;
            workOrderLog.Notes = workOrderF.Notes;

            db.WorkOrderLogs.Add(workOrderLog);
            db.SaveChanges();
            return null;
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/images/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileWoDetail fileWoDetail = db.FileWoDetails.Find(guid);
                if (fileWoDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileWoDetails.Remove(fileWoDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileWoDetail.Id + fileWoDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        // GET: WorkOrderFs/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrderF workOrderF = db.WorkOrderFs.Find(id);
            if (workOrderF == null)
            {
                return HttpNotFound();
            }
            return View(workOrderF);
        }

        // POST: WorkOrderFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            WorkOrderF workOrderF = db.WorkOrderFs.Find(id);
            db.WorkOrderFs.Remove(workOrderF);
            db.SaveChanges();
            LogDeleteWorkOrderActivity(workOrderF);
            return Redirect(returnUrl);
            //return RedirectToAction("Index");
        }

        public ActionResult LogDeleteWorkOrderActivity(WorkOrderF workOrderF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Edit";

            WorkOrderLog workOrderLog = new WorkOrderLog();

            workOrderLog.User = currentUser;
            workOrderLog.EventDateTime = logDateTime;
            workOrderLog.EventType = eventType;
            workOrderLog.WorkOrderFId = workOrderF.WorkOrderFId;
            workOrderLog.CreationDate = workOrderF.CreationDate;
            workOrderLog.CustomerId = workOrderF.CustomerId;
            workOrderLog.CustomerDivisionId = workOrderF.CustomerDivisionId;
            workOrderLog.MlsDivisionId = workOrderF.MlsDivisionId;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.ContractorId = workOrderF.ContractorId;
            workOrderLog.WoPartTypeId = workOrderF.WoPartTypeId;
            workOrderLog.WorkOrderNumber = workOrderF.WorkOrderNumber;
            workOrderLog.NeedDate = workOrderF.NeedDate;
            workOrderLog.PromiseDate = workOrderF.PromiseDate;
            workOrderLog.ShipDate = workOrderF.ShipDate;
            workOrderLog.CustomerPn = workOrderF.CustomerPn;
            workOrderLog.Qty = workOrderF.Qty;
            workOrderLog.StartTime = workOrderF.StartTime;
            workOrderLog.FinishTime = workOrderF.FinishTime;
            workOrderLog.CloseDate = workOrderF.CloseDate;
            workOrderLog.OrderTypeId = workOrderF.OrderTypeId;
            workOrderLog.SageJournalNo = workOrderF.SageJournalNo;
            workOrderLog.Sn = workOrderF.Sn;
            workOrderLog.NewSn = workOrderF.NewSn;
            workOrderLog.CustomerPo = workOrderF.CustomerPo;
            workOrderLog.MlsSo = workOrderF.MlsSo;
            workOrderLog.WoOrderStatusId = workOrderF.WoOrderStatusId;
            workOrderLog.PartStockOutId = workOrderF.PartStockOutId;
            workOrderLog.WoNotes = workOrderF.WoNotes;
            workOrderLog.PartsNeeded = workOrderF.PartsNeeded;
            workOrderLog.PartStockOutNotes = workOrderF.PartStockOutNotes;
            workOrderLog.Parts = workOrderF.Parts;
            workOrderLog.Equipment = workOrderF.Equipment;
            workOrderLog.Resources = workOrderF.Resources;
            workOrderLog.Notes = workOrderF.Notes;

            db.WorkOrderLogs.Add(workOrderLog);
            db.SaveChanges();
            return null;
        }

        public ActionResult _PartStockOut(int stockOutName)
        {
            var queryNew = from a in db.WorkOrderFs
                           where a.PartStockOutId == stockOutName
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 1 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 1
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 2 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 2
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 3 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 3
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 4 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 4
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 5 && a.WoPartTypeId == woPartType
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
            var queryNew = from a in db.WorkOrderFs
                           where a.WoOrderStatusId == 5
                           orderby a.PromiseDate descending
                           select a;
            List<NewWorkOrderFViewModel> result = new List<NewWorkOrderFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewWorkOrderFViewModel
                {
                    WorkOrderFId = order.WorkOrderFId,
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
