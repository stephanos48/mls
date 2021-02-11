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
    public class ShipPlanFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult HydOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HydOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult OHNotShipped()
        {
          
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate).Where(z => z.ContractorId == 1) on tx.Pn equals j.CustomerPn into sr
                        join c in db.CycleCountFs.Where(u => u.CycleCountDateTime >= startDate) on tx.Pn equals c.CustomerPn into cr
                        join n in db.NCRs.Where(u => u.StatusId != 2) on tx.Pn equals n.PartNumber into nr
                        orderby tx.Pn
                        select new
                        {
                            Id = tx.Txqohid,
                            Pn = tx.Pn,
                            Customer = tx.CustomerId,
                            CustomerDivision = tx.CustomerDivisionId,
                            MlsDivision = tx.MlsDivisionId,
                            May11Qoh = tx.Qoh,
                            May11Rec = (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum(),
                            May11Ship = (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            May11Wo = (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum(),
                            May11Cc = (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            May11Nc = (int?)nr.Select(x => x.Quantity).DefaultIfEmpty(0).Sum(),
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum() + (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum() + (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            Location = tx.Location,
                            Notes = tx.Notes
                        };

            List<NewShipPlanFViewModel> pnoh = new List<NewShipPlanFViewModel>();

            //add all pns with qoh to pnoh list
            foreach (var item in query)
            {
                if (item.Qoh > 0)
                {
                    NewShipPlanFViewModel onhand = new NewShipPlanFViewModel()
                    {
                        ShipPlanFId = item.Id,
                        CustomerPn = item.Pn,
                        Qoh = item.Qoh.ToString(),
                        Notes = item.Notes

                    };
                    pnoh.Add(onhand);
                }
            }

            //use linq to return open orders from ShipPlanFs
            var queryopenorder = (from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 2 && a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9
                        orderby a.ShipDateTime ascending
                        select new
                        {
                            a.CustomerPn
                        }).Distinct();


            //transfer open orders to list
            List<NewShipPlanFViewModel> openorders = new List<NewShipPlanFViewModel>();
            foreach(var item in queryopenorder)
            {

                NewShipPlanFViewModel orderonhand = new NewShipPlanFViewModel()
                {

                    CustomerPn = item.CustomerPn,

                };

                openorders.Add(orderonhand);

            }

            List<NewShipPlanFViewModel> openorderswqoh = new List<NewShipPlanFViewModel>();

            foreach (var part in openorders)
            {
                foreach (var s in pnoh)
                {
                    if (part.CustomerPn == s.CustomerPn)
                    {

                        NewShipPlanFViewModel mymodel = new NewShipPlanFViewModel()
                        {
                            ShipPlanFId = s.ShipPlanFId,
                            CustomerPn = part.CustomerPn,
                            Qoh = s.Qoh,
                            Notes = s.Notes
                        };

                        openorderswqoh.Add(mymodel);

                    }
                }

            }

            return View("~/Views/ShipPlanFs/OHNotShipped.cshtml", openorderswqoh);
        }

        public ActionResult OHNotShippedEdit()
        {

            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate).Where(z => z.ContractorId == 1) on tx.Pn equals j.CustomerPn into sr
                        join c in db.CycleCountFs.Where(u => u.CycleCountDateTime >= startDate) on tx.Pn equals c.CustomerPn into cr
                        join n in db.NCRs.Where(u => u.StatusId != 2) on tx.Pn equals n.PartNumber into nr
                        orderby tx.Pn
                        select new
                        {
                            Id = tx.Txqohid,
                            Pn = tx.Pn,
                            Customer = tx.CustomerId,
                            CustomerDivision = tx.CustomerDivisionId,
                            MlsDivision = tx.MlsDivisionId,
                            May11Qoh = tx.Qoh,
                            May11Rec = (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum(),
                            May11Ship = (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum(),
                            May11Wo = (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum(),
                            May11Cc = (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            May11Nc = (int?)nr.Select(x => x.Quantity).DefaultIfEmpty(0).Sum(),
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum() + (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum() + (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            Location = tx.Location,
                            Notes = tx.Notes
                        };

            List<NewShipPlanFViewModel> pnoh = new List<NewShipPlanFViewModel>();

            //add all pns with qoh to pnoh list
            foreach (var item in query)
            {
                if (item.Qoh > 0)
                {
                    NewShipPlanFViewModel onhand = new NewShipPlanFViewModel()
                    {
                        ShipPlanFId = item.Id,
                        CustomerPn = item.Pn,
                        Qoh = item.Qoh.ToString(),
                        Notes = item.Notes

                    };
                    pnoh.Add(onhand);
                }
            }

            //use linq to return open orders from ShipPlanFs
            var queryopenorder = (from a in db.ShipPlanFs
                                  where a.ShipPlanStatusId != 2 && a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9
                                  orderby a.ShipDateTime ascending
                                  select new
                                  {
                                      a.CustomerPn
                                  }).Distinct();


            //transfer open orders to list
            List<NewShipPlanFViewModel> openorders = new List<NewShipPlanFViewModel>();
            foreach (var item in queryopenorder)
            {

                NewShipPlanFViewModel orderonhand = new NewShipPlanFViewModel()
                {

                    CustomerPn = item.CustomerPn,

                };

                openorders.Add(orderonhand);

            }

            List<NewShipPlanFViewModel> openorderswqoh = new List<NewShipPlanFViewModel>();

            foreach (var part in openorders)
            {
                foreach (var s in pnoh)
                {
                    if (part.CustomerPn == s.CustomerPn)
                    {

                        NewShipPlanFViewModel mymodel = new NewShipPlanFViewModel()
                        {
                            ShipPlanFId = s.ShipPlanFId,
                            CustomerPn = part.CustomerPn,
                            Qoh = s.Qoh,
                            Notes = s.Notes
                        };

                        openorderswqoh.Add(mymodel);

                    }
                }

            }

            return View("~/Views/ShipPlanFs/OHNotShippedEdit.cshtml", openorderswqoh);
        }

        public ActionResult DipOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DipOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DttOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DttOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult CLOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 3
                        orderby a.ShipDateTime ascending
                        select a;
            return View("CLOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DopOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.MlsDivisionId == 5
                        orderby a.ShipDateTime ascending
                        select a;
            return View("DopOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ShipPlanPrintHyd()
        {
            var baselinedate = DateTime.Now.AddDays(-90);
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbRoPrintHyd", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed()
        {
            var baselinedate = DateTime.Now.AddDays(-90);
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed180less()
        {
            var baselinedate = DateTime.Now.AddDays(-180);
            var query = from a in db.ShipPlanFs
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
            var query = from a in db.ShipPlanFs
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
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime <= startdate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed365less()
        {
            var baselinedate = DateTime.Now.AddDays(-365);
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime >= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ShipPlanClosed365()
        {
            var baselinedate = DateTime.Now.AddDays(-365);
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.ShipDateTime <= baselinedate
                        orderby a.ShipDateTime descending
                        select a;
            return View("ShipPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult Slotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7
                        orderby a.ShipDateTime ascending
                        select a;
            return View("Slotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult CanceledOrders()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("CanceledOrders", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult LookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("LookUp", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: ShipPlanFs
        public ActionResult Index()
        {
            return View(db.ShipPlanFs.ToList());
        }

        // GET: ShipPlanFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
            if (shipPlanF == null)
            {
                return HttpNotFound();
            }
            return View(shipPlanF);
        }

        // GET: ShipPlans/Details/5
        public ActionResult RoDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
            if (shipPlanF == null)
            {
                return HttpNotFound();
            }
            return View(shipPlanF);
        }

        // GET: ShipPlanFs/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.ShipPlanStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveShipPlanFViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                ShipPlanStatuses = statuses,
                CQStatuses = cqstatuses
            };

            return View("Create", viewModel);
        }

        // POST: ShipPlanFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ShipPlanFId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,WoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,CQStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] ShipPlanF shipPlanF)
        public ActionResult Create(ShipPlanF shipPlanF, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                List<ShipFileDetail> shipFileDetails = new List<ShipFileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        ShipFileDetail shipFileDetail = new ShipFileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        shipFileDetails.Add(shipFileDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), shipFileDetail.Id + shipFileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                shipPlanF.ShipFileDetails = shipFileDetails;
                db.ShipPlanFs.Add(shipPlanF);
                db.SaveChanges();
                LogCreateShipPlanActivity(shipPlanF);
                return Redirect(returnUrl);
                //return RedirectToAction("ShipPlanStatus");
            }

            //return View(shipPlanF);
            return View();
        }

        public ActionResult LogCreateShipPlanActivity(ShipPlanF shipPlanF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Create";

            ShipPlanLog shipPlanLog = new ShipPlanLog();

            shipPlanLog.User = currentUser;
            shipPlanLog.EventDateTime = logDateTime;
            shipPlanLog.EventType = eventType;
            shipPlanLog.ShipPlanId = shipPlanF.ShipPlanFId;
            shipPlanLog.OrderDateTime = shipPlanF.OrderDateTime;
            shipPlanLog.CustomerId = shipPlanF.CustomerId;
            shipPlanLog.CustomerDivisionId = shipPlanF.CustomerDivisionId;
            shipPlanLog.MlsDivisionId = shipPlanF.MlsDivisionId;
            shipPlanLog.CustomerPn = shipPlanF.CustomerPn;
            shipPlanLog.CustomerOrderNo = shipPlanF.CustomerOrderNo;
            shipPlanLog.CustomerOrderLine = shipPlanF.CustomerOrderLine;
            shipPlanLog.SoNumber = shipPlanF.SoNumber;
            shipPlanLog.OrderQty = shipPlanF.OrderQty;
            shipPlanLog.ShipQty = shipPlanF.ShipQty;
            shipPlanLog.ShipPlanStatusId = shipPlanF.ShipPlanStatusId;
            shipPlanLog.CQStatusId = shipPlanF.CQStatusId;
            shipPlanLog.Carrier = shipPlanF.Carrier;
            shipPlanLog.TrackingInfo = shipPlanF.TrackingInfo;
            shipPlanLog.ShipToAddress = shipPlanF.ShipToAddress;
            shipPlanLog.RequestedDateTime = shipPlanF.RequestedDateTime;
            shipPlanLog.PromiseDateTime = shipPlanF.PromiseDateTime;
            shipPlanLog.ShipDateTime = shipPlanF.ShipDateTime;
            shipPlanLog.Notes = shipPlanF.Notes;

            db.ShipPlanLogs.Add(shipPlanLog);
            db.SaveChanges();
            return null;
        }

        // GET: ShipPlanFs/Edit/5
        public ActionResult Edit(int? id)
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var shipplanfs = db.ShipPlanFs.SingleOrDefault(c => c.ShipPlanFId == id);

            var statuses = db.ShipPlanStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveShipPlanFViewModel()
            {
                ShipPlanF = shipplanfs,
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
            //ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
            ShipPlanF shipPlanF = db.ShipPlanFs.Include(s => s.ShipFileDetails).SingleOrDefault(x => x.ShipPlanFId == id);
            if (shipPlanF == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(shipPlanF);
        }

        // POST: ShipPlanFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ShipPlanFId,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerOrderNo,CustomerOrderLine,SoNumber,WoNumber,CustomerPn,UhPn,PartDescription,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,ShipPlanStatusId,CQStatusId,Carrier,TrackingInfo,ShipToAddress,Notes")] ShipPlanF shipPlanF)
        public ActionResult Edit(ShipPlanF shipPlanF, string returnUrl)
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
                        ShipFileDetail shipFileDetail = new ShipFileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            ShipPLanFId = shipPlanF.ShipPlanFId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), shipFileDetail.Id + shipFileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(shipFileDetail).State = EntityState.Added;
                    }
                }

                db.Entry(shipPlanF).State = EntityState.Modified;
                db.SaveChanges();
                LogEditShipPlanActivity(shipPlanF);
                return Redirect(returnUrl);
                //return RedirectToAction("ShipPlanStatus");
            }
            return View();
            //return View(shipPlanF);
        }

        public ActionResult LogEditShipPlanActivity(ShipPlanF shipPlanF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Edit";

            ShipPlanLog shipPlanLog = new ShipPlanLog();

            shipPlanLog.User = currentUser;
            shipPlanLog.EventDateTime = logDateTime;
            shipPlanLog.EventType = eventType;
            shipPlanLog.ShipPlanId = shipPlanF.ShipPlanFId;
            shipPlanLog.OrderDateTime = shipPlanF.OrderDateTime;
            shipPlanLog.CustomerId = shipPlanF.CustomerId;
            shipPlanLog.CustomerDivisionId = shipPlanF.CustomerDivisionId;
            shipPlanLog.MlsDivisionId = shipPlanF.MlsDivisionId;
            shipPlanLog.CustomerPn = shipPlanF.CustomerPn;
            shipPlanLog.CustomerOrderNo = shipPlanF.CustomerOrderNo;
            shipPlanLog.CustomerOrderLine = shipPlanF.CustomerOrderLine;
            shipPlanLog.SoNumber = shipPlanF.SoNumber;
            shipPlanLog.OrderQty = shipPlanF.OrderQty;
            shipPlanLog.ShipQty = shipPlanF.ShipQty;
            shipPlanLog.ShipPlanStatusId = shipPlanF.ShipPlanStatusId;
            shipPlanLog.CQStatusId = shipPlanF.CQStatusId;
            shipPlanLog.Carrier = shipPlanF.Carrier;
            shipPlanLog.TrackingInfo = shipPlanF.TrackingInfo;
            shipPlanLog.ShipToAddress = shipPlanF.ShipToAddress;
            shipPlanLog.RequestedDateTime = shipPlanF.RequestedDateTime;
            shipPlanLog.PromiseDateTime = shipPlanF.PromiseDateTime;
            shipPlanLog.ShipDateTime = shipPlanF.ShipDateTime;
            shipPlanLog.Notes = shipPlanF.Notes;

            db.ShipPlanLogs.Add(shipPlanLog);
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
                ShipFileDetail shipFileDetail = db.ShipFileDetails.Find(guid);
                if (shipFileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.ShipFileDetails.Remove(shipFileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), shipFileDetail.Id + shipFileDetail.Extension);
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
        
        /*
        [HttpPost]
        public  Delete(int id, string returnUrl)
        {
            try
            {
                ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
                if (shipPlanF == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in shipPlanF.ShipFileDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.ShipPlanFs.Remove(shipPlanF);
                db.SaveChanges();
                LogDeleteShipPlanActivity(shipPlanF);
                LogDeleteShipPlanActivity(shipPlanF);
                DeleteConfirmed(id, returnUrl)
                //return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        */

        // GET: ShipPlanFs/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
            if (shipPlanF == null)
            {
                return HttpNotFound();
            }
            return View(shipPlanF);
        }

        // POST: ShipPlanFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            ShipPlanF shipPlanF = db.ShipPlanFs.Find(id);
            db.ShipPlanFs.Remove(shipPlanF);
            db.SaveChanges();
            LogDeleteShipPlanActivity(shipPlanF);
            return Redirect(returnUrl);
            //return RedirectToAction("Index");
        }
        
        public ActionResult LogDeleteShipPlanActivity(ShipPlanF shipPlanF)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Delete";

            ShipPlanLog shipPlanLog = new ShipPlanLog();

            shipPlanLog.User = currentUser;
            shipPlanLog.EventDateTime = logDateTime;
            shipPlanLog.EventType = eventType;
            shipPlanLog.ShipPlanId = shipPlanF.ShipPlanFId;
            shipPlanLog.OrderDateTime = shipPlanF.OrderDateTime;
            shipPlanLog.CustomerId = shipPlanF.CustomerId;
            shipPlanLog.CustomerDivisionId = shipPlanF.CustomerDivisionId;
            shipPlanLog.MlsDivisionId = shipPlanF.MlsDivisionId;
            shipPlanLog.CustomerPn = shipPlanF.CustomerPn;
            shipPlanLog.CustomerOrderNo = shipPlanF.CustomerOrderNo;
            shipPlanLog.CustomerOrderLine = shipPlanF.CustomerOrderLine;
            shipPlanLog.SoNumber = shipPlanF.SoNumber;
            shipPlanLog.OrderQty = shipPlanF.OrderQty;
            shipPlanLog.ShipQty = shipPlanF.ShipQty;
            shipPlanLog.ShipPlanStatusId = shipPlanF.ShipPlanStatusId;
            shipPlanLog.CQStatusId = shipPlanF.CQStatusId;
            shipPlanLog.Carrier = shipPlanF.Carrier;
            shipPlanLog.TrackingInfo = shipPlanF.TrackingInfo;
            shipPlanLog.ShipToAddress = shipPlanF.ShipToAddress;
            shipPlanLog.RequestedDateTime = shipPlanF.RequestedDateTime;
            shipPlanLog.PromiseDateTime = shipPlanF.PromiseDateTime;
            shipPlanLog.ShipDateTime = shipPlanF.ShipDateTime;
            shipPlanLog.Notes = shipPlanF.Notes;

            db.ShipPlanLogs.Add(shipPlanLog);
            db.SaveChanges();
            return null;
        }

        public ActionResult _ShipNew(int status)
        {
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == 1
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == 2
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.CQStatusId == 1
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.CQStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == division
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.CQStatusId == 1 && a.CustomerId == customer
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == 3
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == 4
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == status
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == status && a.CustomerId == customer
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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
            var queryNew = from a in db.ShipPlanFs
                           where a.ShipPlanStatusId == status && a.CustomerId == customer && a.CustomerDivisionId == division
                           orderby a.ShipDateTime ascending
                           select a;
            List<NewShipPlanFViewModel> result = new List<NewShipPlanFViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewShipPlanFViewModel
                {
                    ShipPlanFId = sp.ShipPlanFId,
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

        public ActionResult JbtStatus()
        {
            return View("JbtStatus");
        }

        public ActionResult JbtOgdenStatus()
        {
            return View("JbtOgdenStatus");
        }

        public ActionResult WbStatus()
        {
            return View("WbStatus");
        }

        public ActionResult WqStatus()
        {
            return View("WqStatus");
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

        public ActionResult BayneStatus()
        {
            return View( "BayneStatus");
        }

        public ActionResult BayneLookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 2 && a.CustomerDivisionId == 4 
                        orderby a.ShipDateTime ascending
                        select a;
            return View("BayneLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult BayneOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("BayneOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult BayneCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("BayneCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult BayneSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("BayneSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult BayneShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerDivisionId == 4
                        orderby a.ShipDateTime descending
                        select a;
            return View("BayneShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgStatus()
        {
            return View("EsgStatus");
        }

        public ActionResult EsgLookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.CustomerId == 1 && a.CustomerDivisionId != 9 && a.CustomerDivisionId != 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.ShipDateTime descending
                        select a;
            return View("EsgShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult MStatus()
        {
            return View("MStatus");
        }

        public ActionResult MLookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 2 && a.CustomerDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("MLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult MOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 1 && a.CustomerDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("MOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult MCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 1 && a.CustomerDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("MCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult MSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerDivisionId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("MSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult MShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerDivisionId == 2
                        orderby a.ShipDateTime descending
                        select a;
            return View("MShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ManitowocStatus()
        {
            return View("ManitowocStatus");
        }

        public ActionResult ManitowocPcLookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.CustomerId == 18
                        orderby a.CustomerPn ascending
                        select a;
            return View("ManitowocLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ManitowocOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 18
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ManitowocOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ManitowocCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 18
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ManitowocCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ManitowocSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 18
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ManitowocSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ManitowocShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 18 
                        orderby a.ShipDateTime descending
                        select a;
            return View("ManitowocShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcStatus()
        {
            return View("EsgPcStatus");
        }

        public ActionResult EsgPcLookUp()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.ShipPlanStatusId != 8 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.CustomerPn ascending
                        select a;
            return View("EsgPcLookUp", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgPcCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgPcSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgPcShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.ShipDateTime descending
                        select a;
            return View("EsgPcShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.CustomerId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("EsgRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult EsgRoShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 1
                        orderby a.ShipDateTime descending
                        select a;
            return View("EsgRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdRoOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 7 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOgdRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtOrlRoOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 7 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOrlRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtOrlRoShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtOrlRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdRoShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 19 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtOgdRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOpen()
        {
            var query = from a in db.ShipPlanFs
                        where (a.ShipPlanStatusId == 6 || a.ShipPlanStatusId == 7) && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerDivisionId == 11
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdenOpen()
        {
            var query = from a in db.ShipPlanFs
                        where (a.ShipPlanStatusId == 6 || a.ShipPlanStatusId == 7) && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOgdenOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult JbtOgdenCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOgdenCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdenSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime ascending
                        select a;
            return View("JbtOgdenSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult JbtOgdenShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerDivisionId == 10
                        orderby a.ShipDateTime descending
                        select a;
            return View("JbtOgdenShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbOpenDip()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpenDip", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbOpenHyd()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbOpenHyd", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbDip()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbDip", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbHyd()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbHyd", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbRoOpenWbAll()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbRoOpenWbAll", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WbCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 2
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WbSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 2
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WbRoShippedWb()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 2
                        orderby a.ShipDateTime descending
                        select a;
            return View("WbRoShippedWb", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WqOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 26
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WqOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WqOpenDip()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 26 && a.MlsDivisionId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WqOpenDip", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WqOpenHyd()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 8 && a.ShipPlanStatusId != 9 && a.CustomerId == 26 && a.MlsDivisionId == 1
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WqOpenHyd", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult WqCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 26
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WqCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WqSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 26
                        orderby a.ShipDateTime ascending
                        select a;
            return View("WqSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult WqShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 26
                        orderby a.ShipDateTime descending
                        select a;
            return View("WqShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ThiRoOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId != 5 && a.ShipPlanStatusId != 9 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiRoOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ThiCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 8
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ThiSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 8
                        orderby a.ShipDateTime descending
                        select a;
            return View("ThiShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 8
                        orderby a.ShipDateTime descending
                        select a;
            return View("ThiRoShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ChCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 21
                        orderby a.ShipDateTime ascending
                        select a;
            return View("ChSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ChShipped()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 5 && a.CustomerId == 21
                        orderby a.ShipDateTime descending
                        select a;
            return View("ChShipped", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterOpen()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 6 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult HunterCanceled()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 9 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterSlotted()
        {
            var query = from a in db.ShipPlanFs
                        where a.ShipPlanStatusId == 7 && a.CustomerId == 4
                        orderby a.ShipDateTime ascending
                        select a;
            return View("HunterSlotted", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HunterShipped()
        {
            var query = from a in db.ShipPlanFs
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
