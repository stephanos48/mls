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
    public class TxQohs1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TxQohs1
        public ActionResult Index()
        {
            return View(db.TxQohs.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohUH()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 1
                        select tx;

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Txqohid = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    NcrQty = qoh.NcrQty,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohUH.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDIP()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 4
                        select tx;

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Txqohid = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    NcrQty = qoh.NcrQty,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohDIP.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohCL()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 3
                        select tx;

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Txqohid = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    NcrQty = qoh.NcrQty,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohCL.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDTT()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 2
                        select tx;

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Txqohid = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    NcrQty = qoh.NcrQty,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/TxQohs1/TxQohDTT.cshtml", result);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDOP()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 5
                        select tx;

            List<QohViewModel> result = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new QohViewModel
                {
                    Txqohid = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    NcrQty = qoh.NcrQty,
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
            return View();
        }

        // POST: TxQohs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Txqohid,Pn,UhPn,Qoh,NcrQty,Notes")] TxQoh txQoh)
        {
            if (ModelState.IsValid)
            {
                db.TxQohs.Add(txQoh);
                db.SaveChanges();
                return RedirectToAction("Index", "WorkOrders");
            }

            return View(txQoh);
        }

        // GET: TxQohs1/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: TxQohs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Txqohid,Pn,UhPn,Qoh,NcrQty,Notes")] TxQoh txQoh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(txQoh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "WorkOrders");
            }
            return View(txQoh);
        }

        // GET: TxQohs1/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: TxQohs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TxQoh txQoh = db.TxQohs.Find(id);
            db.TxQohs.Remove(txQoh);
            db.SaveChanges();
            return RedirectToAction("Index", "WorkOrders");
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
