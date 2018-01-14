using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using mls.Migrations;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class PfepsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: Pfeps
        public ActionResult Index()
        {
            return View(db.Pfeps.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Wastebuilt PFEP
        public ActionResult ManagePfep()
        {
            return View(db.Pfeps.ToList());
        }

        // GET: Wastebuilt Lift Parts
        public ActionResult WB_LiftParts()
        {
            return View();
        }

        // GET: Wastebuilt PFEP
        public ActionResult PfepVsg()
        {
            return View();
        }

        // GET: DTT Trailer PFEP
        public ActionResult PfepDtt()
        {
            return View();
        }

        // GET: DTT Trailer PFEP
        public ActionResult PfepDttParts()
        {
            return View();
        }

        // GET: Wastebuilt PFEP
        public ActionResult PfepHunter()
        {
            return View();
        }

        // GET: Wastebuilt PFEP
        public ActionResult WB1Pfep()
        {
            return View();
        }

        [Authorize(Roles="Admin")]
        // GET: Wastebuilt PFEP
        public ActionResult PfepWb()
        {
            return View();
        }

        // GET: Hunter PFEP
        public ActionResult HunterPfep()
        {
            return View();
        }
        
        // GET: VSG PFEP
        public ActionResult VsgPfep()
        {
            return View();
        }

        // GET: Marathon PFEP
        public ActionResult Bayne_Cylinder()
        {
            return View();
        }

        // GET: Marathon PFEP
        public ActionResult PfepMarathon()
        {
            return View();
        }

        // GET: Heil PFEP
        public ActionResult PfepHeil()
        {
            return View();
        }

        // GET: Bayne Lift Parts PFEP
        public ActionResult Bayne_LiftParts()
        {
            return View();
        }

        // GET: Bayne Actuator PFEP
        public ActionResult Bayne_Actuator()
        {
            return View();
        }

        // GET: Bayne Actuator Parts PFEP
        public ActionResult Bayne_ActParts()
        {
            return View();
        }

        // GET: Bayne Actuator PFEP
        public ActionResult Pfep()
        {
            return View();
        }

        // GET: Pfeps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfep pfep = db.Pfeps.Find(id);
            if (pfep == null)
            {
                return HttpNotFound();
            }
            return View(pfep);
        }

        // GET: Pfeps/Create
        public ActionResult Create()
        {
            var parttypes = db.PartTypes.ToList();

            var viewModel = new Save1PfepViewModel()
            {
                PartTypes = parttypes
            };

            return View("Create", viewModel);
        }

        // POST: Pfeps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PfepId,CustomerPn,PartType,LtCustomer,LtTx,LtOcean,LtHaimen,LtAssy,PfepCustomer,PfepTx,PfepOcean,PfepHaimen,PfepAssy,Min,Max,KbQty")] Pfep pfep)
        public ActionResult Create(Pfep pfep)
        {
            if (ModelState.IsValid)
            {
                db.Pfeps.Add(pfep);
                db.SaveChanges();
                return RedirectToAction("Index", "Pfeps");
            }

            return View();
            //return View(pfep);
        }

        // GET: Pfeps/Edit/5
        public ActionResult Edit(int? id)
        {
            var pfeps = db.Pfeps.SingleOrDefault(c => c.PfepId == id);

            var parttypes = db.PartTypes.ToList();

            var viewModel = new Save1PfepViewModel()
            {
                Pfep = pfeps,
                PartTypes = parttypes
            };
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfep pfep = db.Pfeps.Find(id);
            if (pfep == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(pfep);
        }

        // POST: Pfeps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PfepId,CustomerPn,PartType,LtCustomer,LtTx,LtOcean,LtHaimen,LtAssy,PfepCustomer,PfepTx,PfepOcean,PfepHaimen,PfepAssy,Min,Max,KbQty")] Pfep pfep)
        public ActionResult Edit(Pfep pfep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pfep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pfep);
        }

        // GET: Pfeps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pfep pfep = db.Pfeps.Find(id);
            if (pfep == null)
            {
                return HttpNotFound();
            }
            return View(pfep);
        }

        // POST: Pfeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pfep pfep = db.Pfeps.Find(id);
            db.Pfeps.Remove(pfep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // GET: Pfeps/StockOut
        [HttpGet]
        public ActionResult _StockOut(int parttype, int customer, int division)
        {

            var queryNew = from mp in db.MasterPartLists
                join co in db.CustomerOrders.Where(o => o.OrderStatusId != 7) on mp.CustomerPn equals co.CustomerPn into
                ordergroup
                join pfep in db.Pfeps on mp.CustomerPn equals pfep.CustomerPn
                join ship in db.ShipIns.Where(r => r.ShipInStatusId != 3) on mp.CustomerPn equals ship.Pn into shipgroup
                join tx in db.TxQohs on mp.CustomerPn equals tx.Pn
                where pfep.PartTypeId == parttype && mp.CustomerId == customer && mp.CustomerDivisionId == division && mp.ActivePartId == 1 && tx.Qoh == 0
                orderby mp.CustomerPn
                select new
                {
                    mp.CustomerPn,
                    mp.PartDescription,
                    pfep.PfepTx,
                    pfep.KbQty,
                    tx.Qoh,
                    OO = (int?)ordergroup.Sum(c => c.OrderQty) - (int?)ordergroup.Sum(c => c.ShipQty),
                    Ocean = (int?)shipgroup.Sum(s => s.Qty)
                };

            /*var queryNew = from cp in db.MasterPartLists
                join tx in db.TxQohs on new { PartNumber = cp.CustomerPn } equals new {PartNumber = tx.Pn} into q1
                from tx in q1.DefaultIfEmpty()
                join c in db.ShipIns on new {PartNumber = cp.CustomerPn} equals new {PartNumber = c.Pn} into q2
                from c in q2.DefaultIfEmpty()
                           where c.ShipInStatusId != 3
                join d in db.Pfeps on new {PartNumber = cp.CustomerPn} equals new {PartNumber = d.CustomerPn} into q3
                from d in q3.DefaultIfEmpty()
                where cp.PartTypeId == parttype && cp.CustomerDivisionId == division && cp.ActivePartId == 1 && tx.Qoh == 0
                group new {cp, tx, c, d} by new
                {
                    cp.CustomerPn,
                    tx.Qoh,
                    cp.PartDescription,
                    d.PfepTx,
                    d.KbQty
                }
                into g
                orderby
                g.Key.CustomerPn ascending
                select new
                {
                    g.Key.CustomerPn,
                    g.Key.PartDescription,
                    PFEPTx = (int?) g.Key.PfepTx,
                    KBQty = (int?) g.Key.KbQty,
                    QOH = (int?) g.Key.Qoh,
                    Ocean = (int?) g.Sum(p => p.c.Qty)

                };*/

            /*var queryNew = (from cp in db.MasterPartLists
                join tx in db.TxQohs on cp.CustomerPn equals tx.Pn into jTxQoh
                from tx in jTxQoh.DefaultIfEmpty()
                join c in db.ShipIns.Where(r => r.ShipInStatusId != 3) on cp.CustomerPn equals c.Pn into jShipIns
                from c in jShipIns.DefaultIfEmpty()
                join d in db.Pfeps on cp.CustomerPn equals d.CustomerPn into jPfeps
                from d in jPfeps.DefaultIfEmpty()
                where d.PartTypeId == parttype && cp.CustomerId == customer && cp.CustomerDivisionId == division && cp.ActivePartId == 1 && tx.Qoh == 0
                group new {cp, d, tx, c} by new {cp.CustomerPn, tx.Qoh, cp.PartDescription, d.PfepTx, d.KbQty}
                into gcp
                orderby gcp.Key.CustomerPn
                select new
                {
                    gcp.Key.CustomerPn,
                    gcp.Key.PartDescription,
                    gcp.Key.PfepTx,
                    gcp.Key.KbQty,
                    gcp.Key.Qoh,
                    Ocean = (int?)gcp.Sum(r => r.c.Qty)
                }); */

           /* string queryNew = "SELECT cp.CustomerPn, cp.PartDescription, Pfeps.PFEPTx, Pfeps.KBQty, TxQohs.Qoh, SUM(ShipIns.Qty) AS 'Ocean' "
                              + "FROM MasterPartLists as cp "
                              + "LEFT JOIN TxQohs "
                              + "ON cp.CustomerPn = TxQohs.Pn AND TxQohs.Qoh = '0' "
                              + "LEFT JOIN ShipIns "
                              + "ON cp.CustomerPn = ShipIns.Pn AND ShipIns.ShipStatusId <> '3' "
                              + "LEFT JOIN Pfep "
                              + "ON cp.CustomerPn = Pfeps.CustomerPn "
                              + "WHERE cp.PartTypeId = parttype AND cp.CustomerDivisionId = division AND cp.ActivePartId = '1' "
                              + "Group By cp.CustomerPn, TxQohs.Qoh, cp.PartDescription, Pfeps.PfepTx, Pfeps.KbQty "
                              + "Order By cp.CustomerPn ASC "; 
            /*var result1 = db.Database.SqlQuery<dynamic>("Select * from MasterPartLists").ToArray(); */
           /*IEnumerable<StockOutGroup> data = db.Database.SqlQuery<StockOutGroup>(queryNew); */

            List<SavePfepViewModel> result = new List<SavePfepViewModel>();
            foreach (var pfep in queryNew.ToList())
            {
                result.Add(new SavePfepViewModel
                {
                    CustomerPn = pfep.CustomerPn,
                    PartDescription = pfep.PartDescription,
                    PfepTx = pfep.PfepTx,
                    KbQty = pfep.KbQty,
                    Qoh = pfep.Qoh,
                    Oo = pfep.OO,
                    Ocean = pfep.Ocean,
                });
            }

            //return PartialView("_StockOut", result);
            return View("_StockOutPartialView", result);
        }

        // GET: Pfeps/LowStock
        [HttpGet]
        public ActionResult _LowStock(int parttype, int customer, int division)
        {

            var queryNew = from mp in db.MasterPartLists
                join co in db.CustomerOrders.Where(o => o.OrderStatusId != 7) on mp.CustomerPn equals co.CustomerPn into
                ordergroup
                join pfep in db.Pfeps on mp.CustomerPn equals pfep.CustomerPn
                join ship in db.ShipIns.Where(r => r.ShipInStatusId != 3) on mp.CustomerPn equals ship.Pn into shipgroup
                join tx in db.TxQohs on mp.CustomerPn equals tx.Pn
                where pfep.PartTypeId == parttype && mp.CustomerId == customer && mp.CustomerDivisionId == division && mp.ActivePartId == 1 && tx.Qoh <= pfep.Min.Value && tx.Qoh != 0
                orderby mp.CustomerPn
                select new
                {
                    mp.CustomerPn,
                    mp.PartDescription,
                    pfep.PfepTx,
                    pfep.KbQty,
                    tx.Qoh,
                    OO = (int?) ordergroup.Sum(c => c.OrderQty) - (int?)ordergroup.Sum(c => c.ShipQty),
                    Ocean = (int?) shipgroup.Sum(s => s.Qty)
                };

            /*var queryNew = (from cp in db.MasterPartLists
                           join tx in db.TxQohs on cp.CustomerPn equals tx.Pn into jTxQoh
                           from tx in jTxQoh.DefaultIfEmpty()
                           join c in db.ShipIns.Where(r => r.ShipInStatusId != 3) on cp.CustomerPn equals c.Pn into jShipIns
                           from c in jShipIns.DefaultIfEmpty()
                           join d in db.Pfeps on cp.CustomerPn equals d.CustomerPn into jPfeps
                           from d in jPfeps.DefaultIfEmpty()
                           join e in db.CustomerOrders.Where(t => t.OrderStatusId != 7) on cp.CustomerPn equals e.CustomerPn into jCustomerOrders
                           from e in jCustomerOrders.DefaultIfEmpty()
                           where d.PartTypeId == parttype && cp.CustomerId == customer && cp.CustomerDivisionId == division && cp.ActivePartId == 1 && tx.Qoh <= d.Min.Value && tx.Qoh != 0 
                           group new { cp, d, tx, c, e } by new { cp.CustomerPn, tx.Qoh, cp.PartDescription, d.PfepTx, d.KbQty }
                           into gcp
                           orderby gcp.Key.CustomerPn
                           select
                           new
                           {
                               gcp.Key.CustomerPn,
                               gcp.Key.PartDescription,
                               gcp.Key.PfepTx,
                               gcp.Key.KbQty,
                               gcp.Key.Qoh,
                               OO = (int?)gcp.Sum(t => t.e.OrderQty),
                               Ocean = (int?)gcp.Sum(r => r.c.Qty)
                           });*/

            /*string queryNew = "SELECT cp.CustomerPn, cp.PartDescription, Pfeps.PFEPTx, Pfeps.KBQty, TxQohs.Qoh, SUM(ShipIns.Qty) AS 'Ocean' "
                              + "FROM MasterPartLists as cp "
                              + "LEFT JOIN TxQohs "
                              + "ON cp.CustomerPn = TxQohs.Pn AND TxQohs.Qoh <= '5' "
                              + "LEFT JOIN ShipIns "
                              + "ON cp.CustomerPn = ShipIns.Pn AND ShipIns.ShipInStatusId <> '3' "
                              + "LEFT JOIN Pfeps "
                              + "ON cp.CustomerPn = Pfeps.CustomerPn "
                              + "WHERE Pfeps.PartTypeId = partType AND cp.CustomerDivisionId = division AND cp.ActivePartId = '1' "
                              + "Group By cp.CustomerPn, TxQohs.Qoh, cp.PartDescription, Pfeps.PfepTx, Pfeps.KbQty "
                              + "Order By cp.CustomerPn ASC ";
           var data = db.Database.SqlQuery<SavePfepViewModel>(queryNew).ToList(); */

            /*List<SavePfepViewModel> result = new List<SavePfepViewModel>();*/

            List<SavePfepViewModel> result = new List<SavePfepViewModel>();
            foreach (var pfep in queryNew.ToList())
            {
                result.Add(new SavePfepViewModel
                {
                    CustomerPn = pfep.CustomerPn,
                    PartDescription = pfep.PartDescription,
                    PfepTx = pfep.PfepTx,
                    KbQty = pfep.KbQty,
                    Qoh = pfep.Qoh,
                    Oo = pfep.OO,
                    Ocean = pfep.Ocean,
                });
            }

            //return PartialView("_StockOut", result);
            return View("_LowStockPartialView", result); 
        }

        // GET: Pfeps/LowStock
        [HttpGet]
        public ActionResult _NeedToOrder(int parttype, int customer, int division)
        {

            var queryNew = from mp in db.MasterPartLists
                           join co in db.CustomerOrders.Where(o => o.OrderStatusId != 7) on mp.CustomerPn equals co.CustomerPn into
                           ordergroup
                           join pfep in db.Pfeps on mp.CustomerPn equals pfep.CustomerPn
                           join ship in db.ShipIns.Where(r => r.ShipInStatusId != 3) on mp.CustomerPn equals ship.Pn into shipgroup
                           join tx in db.TxQohs on mp.CustomerPn equals tx.Pn
                           where pfep.PartTypeId == parttype && mp.CustomerId == customer && mp.CustomerDivisionId == division && mp.ActivePartId == 1 && tx.Qoh <= pfep.PfepTx
                           orderby mp.CustomerPn
                           select new
                           {
                               mp.CustomerPn,
                               mp.PartDescription,
                               pfep.PfepTx,
                               pfep.KbQty,
                               tx.Qoh,
                               OO = (int?)ordergroup.Sum(c => c.OrderQty) - (int?)ordergroup.Sum(c => c.ShipQty),
                               Ocean = (int?)shipgroup.Sum(s => s.Qty)
                           };

            /*var queryNew = (from cp in db.MasterPartLists
                            join tx in db.TxQohs on cp.CustomerPn equals tx.Pn into jTxQoh
                            from tx in jTxQoh.DefaultIfEmpty()
                            join c in db.ShipIns.Where(r => r.ShipInStatusId != 3) on cp.CustomerPn equals c.Pn into jShipIns
                            from c in jShipIns.DefaultIfEmpty()
                            join d in db.Pfeps on cp.CustomerPn equals d.CustomerPn into jPfeps
                            from d in jPfeps.DefaultIfEmpty()
                            where d.PartTypeId == parttype && cp.CustomerId == customer && cp.CustomerDivisionId == division && cp.ActivePartId == 1 && tx.Qoh <= d.PfepTx
                            group new { cp, d, tx, c } by new { cp.CustomerPn, tx.Qoh, cp.PartDescription, d.PfepTx, d.KbQty }
                           into gcp
                            orderby gcp.Key.CustomerPn
                            select
                            new
                            {
                                gcp.Key.CustomerPn,
                                gcp.Key.PartDescription,
                                gcp.Key.PfepTx,
                                gcp.Key.KbQty,
                                gcp.Key.Qoh,
                                Ocean = (int?)gcp.Sum(r => r.c.Qty)
                            });*/

            /*string queryNew = "SELECT cp.CustomerPn, cp.PartDescription, Pfeps.PFEPTx, Pfeps.KBQty, TxQohs.Qoh, SUM(ShipIns.Qty) AS 'Ocean' "
                              + "FROM MasterPartLists as cp "
                              + "LEFT JOIN TxQohs "
                              + "ON cp.CustomerPn = TxQohs.Pn AND TxQohs.Qoh <= '5' "
                              + "LEFT JOIN ShipIns "
                              + "ON cp.CustomerPn = ShipIns.Pn AND ShipIns.ShipInStatusId <> '3' "
                              + "LEFT JOIN Pfeps "
                              + "ON cp.CustomerPn = Pfeps.CustomerPn "
                              + "WHERE Pfeps.PartTypeId = partType AND cp.CustomerDivisionId = division AND cp.ActivePartId = '1' "
                              + "Group By cp.CustomerPn, TxQohs.Qoh, cp.PartDescription, Pfeps.PfepTx, Pfeps.KbQty "
                              + "Order By cp.CustomerPn ASC ";
           var data = db.Database.SqlQuery<SavePfepViewModel>(queryNew).ToList(); */

            /*List<SavePfepViewModel> result = new List<SavePfepViewModel>();*/

            List<SavePfepViewModel> result = new List<SavePfepViewModel>();
            foreach (var pfep in queryNew.ToList())
            {
                result.Add(new SavePfepViewModel
                {
                    CustomerPn = pfep.CustomerPn,
                    PartDescription = pfep.PartDescription,
                    PfepTx = pfep.PfepTx,
                    KbQty = pfep.KbQty,
                    Qoh = pfep.Qoh,
                    Oo = pfep.OO,
                    Ocean = pfep.Ocean,
                });
            }

            //return PartialView("_StockOut", result);
            return View("_NeedToOrderPartialView", result);
        }


        // GET: Pfeps/AllParts
        [HttpGet]
        public ActionResult _AllParts(int parttype, int customer, int division)
        {

            var queryNew = from mp in db.MasterPartLists
                           join co in db.CustomerOrders.Where(o => o.OrderStatusId != 7) on mp.CustomerPn equals co.CustomerPn into
                           ordergroup
                           join pfep in db.Pfeps on mp.CustomerPn equals pfep.CustomerPn
                           join ship in db.ShipIns.Where(r => r.ShipInStatusId != 3) on mp.CustomerPn equals ship.Pn into shipgroup
                           join tx in db.TxQohs on mp.CustomerPn equals tx.Pn
                           where pfep.PartTypeId == parttype && mp.CustomerId == customer && mp.CustomerDivisionId == division && mp.ActivePartId == 1
                           orderby mp.CustomerPn 
                           select new
                           {
                               mp.CustomerPn,
                               mp.PartDescription,
                               pfep.PfepTx,
                               pfep.KbQty,
                               tx.Qoh,
                               OO = (int?)ordergroup.Sum(c => c.OrderQty) - (int?)ordergroup.Sum(c => c.ShipQty),
                               Ocean = (int?)shipgroup.Sum(s => s.Qty)
                           };

            /*var queryNew = from cp in db.MasterPartLists
                           join tx in db.TxQohs on cp.CustomerPn equals tx.Pn into jTxQoh
                           from tx in jTxQoh.DefaultIfEmpty()
                           join c in db.ShipIns.Where(r => r.ShipInStatusId != 3) on cp.CustomerPn equals c.Pn into jShipIns
                           from c in jShipIns.DefaultIfEmpty()
                           join e in db.CustomerOrders.Where(t => t.OrderStatusId != 7) on cp.CustomerPn equals e.CustomerPn into jCustomerOrders
                           from e in jCustomerOrders.DefaultIfEmpty()
                           join d in db.Pfeps on cp.CustomerPn equals d.CustomerPn into jPfeps
                           from d in jPfeps.DefaultIfEmpty()
                           where d.PartTypeId == parttype && cp.CustomerId == customer && cp.CustomerDivisionId == division && cp.ActivePartId == 1
                           group new { cp, tx, c, d, e } by new { cp.CustomerPn, tx.Qoh, cp.PartDescription, d.PfepTx, d.KbQty }
                           into gcp
                           orderby gcp.Key.CustomerPn
                           select
                           new
                           {
                               gcp.Key.CustomerPn,
                               gcp.Key.PartDescription,
                               gcp.Key.PfepTx,
                               gcp.Key.KbQty,
                               gcp.Key.Qoh,
                               OO = ((int?)gcp.Sum(t => t.e.OrderQty)-(int?)gcp.Sum(t => t.e.ShipQty)),
                               Ocean = (int?)gcp.Sum(r => r.c.Qty)
                           };*/

            /*string queryNew = "SELECT cp.CustomerPn, cp.PartDescription, Pfep.PFEPTx, Pfep.KBQty, TxQoh.QOH, SUM(ShipIn.Qty) AS 'Ocean'"
                              + "FROM MasterPartLists as cp"
                              + "LEFT JOIN TxQoh"
                              + "ON cp.CustomerPn = TxQoh.PN"
                              + "LEFT JOIN ShipIn"
                              + "ON cp.CustomerPn = ShipIn.Pn AND ShipIn.Status <> 'Received'"
                              + "LEFT JOIN Pfep"
                              + "ON cp.CustomerPn = Pfep.CustomerPn"
                              + "WHERE cp.PartTypeId = parttype AND cp.CustomerDivisionId = division AND cp.ActivePartId = 1 AND TX_QOH.QOH = '0'"
                              + "Group By cp.CustomerPn, TxQoh.QOH, cp.PartDescription, Pfep.PfepTx, Pfep.KbQty"
                              + "Order By cp.CustomerPn ASC";
           IEnumerable<StockOutGroup> data = db.Database.SqlQuery<StockOutGroup>(queryNew); */
           
            List<SavePfepViewModel> result = new List<SavePfepViewModel>();
            foreach (var pfep in queryNew.ToList())
            {
                result.Add(new SavePfepViewModel
                {
                    CustomerPn = pfep.CustomerPn,
                    PartDescription = pfep.PartDescription,
                    PfepTx = pfep.PfepTx,
                    KbQty = pfep.KbQty,
                    Qoh = pfep.Qoh,
                    Oo = pfep.OO,
                    Ocean = pfep.Ocean,
                });
            }

            //return PartialView("_StockOut", result);
            return View("_AllPartsPartialView", result);
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
