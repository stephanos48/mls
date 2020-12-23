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
    public class TxQohs1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TxQohs1
        public ActionResult Index()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
                        join c in db.CycleCountFs.Where(u=>u.CycleCountDateTime >= startDate) on tx.Pn equals c.CustomerPn into cr
                        join n in db.NCRs.Where(u=>u.StatusId != 2) on tx.Pn equals n.PartNumber into nr
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
                            May11Wo = (int?)sr.Select(x=>x.Qty).DefaultIfEmpty(0).Sum(),
                            May11Cc = (int?)cr.Select(x=>x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            May11Nc = (int?)nr.Select(x=>x.Quantity).DefaultIfEmpty(0).Sum(),
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum() + (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum() + (int ?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            Location = tx.Location,
                            Notes = tx.Notes
                        };

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/Index.cshtml", result);
        }

        public ActionResult Home()
        {
            return View();
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohUH()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs.Where(q=>q.MlsDivisionId == 1)
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
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

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohUH.cshtml", result);
        }

        public ActionResult TxQohDIP()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs.Where(q => q.MlsDivisionId == 4)
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
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

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohDIP.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohCL()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs.Where(q => q.MlsDivisionId == 3)
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
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

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohCL.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDTT()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs.Where(q => q.MlsDivisionId == 2)
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
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

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohDTT.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDOP()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.TxQohs.Where(q => q.MlsDivisionId == 5)
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
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

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Id = qoh.Id,
                    Pn = qoh.Pn,
                    CustomerId = qoh.Customer,
                    CustomerDivisionId = qoh.CustomerDivision,
                    MlsDivisionId = qoh.MlsDivision,
                    May11Qoh = qoh.May11Qoh,
                    May11Rec = qoh.May11Rec,
                    May11Ship = qoh.May11Ship,
                    May11Wo = qoh.May11Wo,
                    May11Cc = qoh.May11Cc,
                    May11Nc = qoh.May11Nc,
                    Qoh = qoh.Qoh,
                    Location = qoh.Location,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohDOP.cshtml", result);
        }

        // GET: TxQohs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = db.TxQohs.Find(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View(txQoh);
        }

        // GET: TxQohs1/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveTxQohViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts

            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: TxQohs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Txqohid,Pn,UhPn,Qoh,NcrQty,Notes")] TxQoh txQoh)
        public ActionResult Create(TxQoh txQoh, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.TxQohs.Add(txQoh);
                db.SaveChanges();
                LogCreateTxQohActivity(txQoh);
                return Redirect(returnUrl);
                //return RedirectToAction("Index", "WorkOrders");
            }

            //return View(txQoh);
            return View();
        }

        public ActionResult LogCreateTxQohActivity(TxQoh txQoh)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Create";

            TxQohLog txQohLog = new TxQohLog();

            txQohLog.User = currentUser;
            txQohLog.EventDateTime = logDateTime;
            txQohLog.EventType = eventType;
            txQohLog.CustomerId = txQoh.CustomerId;
            txQohLog.CustomerDivisionId = txQoh.CustomerDivisionId;
            txQohLog.MlsDivisionId = txQoh.MlsDivisionId;
            txQohLog.ActivePartId = txQoh.ActivePartId;
            txQohLog.PartTypeId = txQoh.PartTypeId;
            txQohLog.Pn = txQoh.Pn;
            txQohLog.UhPn = txQoh.UhPn;
            txQohLog.PartDescription = txQoh.PartDescription;
            txQohLog.Qoh = txQoh.Qoh;
            txQohLog.Location = txQoh.Location;
            txQohLog.Notes = txQoh.Notes;

            db.TxQohLogs.Add(txQohLog);
            db.SaveChanges();
            return null;
        }

        // GET: TxQohs1/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var txqohs = db.TxQohs.SingleOrDefault(c => c.Txqohid == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveTxQohViewModel()
            {
                TxQoh = txqohs,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = db.TxQohs.Find(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(txQoh);
        }

        // POST: TxQohs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Txqohid,Pn,UhPn,Qoh,NcrQty,Notes")] TxQoh txQoh)
        public ActionResult Edit(TxQoh txQoh, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(txQoh).State = EntityState.Modified;
                db.SaveChanges();
                LogEditTxQohActivity(txQoh);
                return Redirect(returnUrl);
                //return RedirectToAction("Index", "WorkOrders");
            }
            return View();
            //return View(txQoh);
        }

        public ActionResult LogEditTxQohActivity(TxQoh txQoh)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Edit";

            TxQohLog txQohLog = new TxQohLog();

            txQohLog.User = currentUser;
            txQohLog.EventDateTime = logDateTime;
            txQohLog.EventType = eventType;
            txQohLog.CustomerId = txQoh.CustomerId;
            txQohLog.CustomerDivisionId = txQoh.CustomerDivisionId;
            txQohLog.MlsDivisionId = txQoh.MlsDivisionId;
            txQohLog.ActivePartId = txQoh.ActivePartId;
            txQohLog.PartTypeId = txQoh.PartTypeId;
            txQohLog.Pn = txQoh.Pn;
            txQohLog.UhPn = txQoh.UhPn;
            txQohLog.PartDescription = txQoh.PartDescription;
            txQohLog.Qoh = txQoh.Qoh;
            txQohLog.Location = txQoh.Location;
            txQohLog.Notes = txQoh.Notes;

            db.TxQohLogs.Add(txQohLog);
            db.SaveChanges();
            return null;
        }

        // GET: TxQohs1/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = db.TxQohs.Find(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View(txQoh);
        }

        // POST: TxQohs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            TxQoh txQoh = db.TxQohs.Find(id);
            db.TxQohs.Remove(txQoh);
            db.SaveChanges();
            LogDeleteTxQohActivity(txQoh);
            return Redirect(returnUrl);
        }

        public ActionResult LogDeleteTxQohActivity(TxQoh txQoh)
        {
            var currentUser = User.Identity.GetUserName();
            var logDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var eventType = "Delete";

            TxQohLog txQohLog = new TxQohLog();

            txQohLog.User = currentUser;
            txQohLog.EventDateTime = logDateTime;
            txQohLog.EventType = eventType;
            txQohLog.CustomerId = txQoh.CustomerId;
            txQohLog.CustomerDivisionId = txQoh.CustomerDivisionId;
            txQohLog.MlsDivisionId = txQoh.MlsDivisionId;
            txQohLog.ActivePartId = txQoh.ActivePartId;
            txQohLog.PartTypeId = txQoh.PartTypeId;
            txQohLog.Pn = txQoh.Pn;
            txQohLog.UhPn = txQoh.UhPn;
            txQohLog.PartDescription = txQoh.PartDescription;
            txQohLog.Qoh = txQoh.Qoh;
            txQohLog.Location = txQoh.Location;
            txQohLog.Notes = txQoh.Notes;

            db.TxQohLogs.Add(txQohLog);
            db.SaveChanges();
            return null;
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
