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
    public class VtPfepsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VtPfeps
        public ActionResult Index()
        {
            return View(db.VtPfeps.ToList());
        }

        public ActionResult IncomingTransfers()
        {
            var query = from inv in db.InventoryTransfers
                        where inv.FinishInvLocationId == 6 
                        select inv;

            return View("~/Views/InventoryTransfers/VtIncTransfers.cshtml", query);

        }

        public ActionResult OutgoingTransfers()
        {
            var query = from inv in db.InventoryTransfers
                        where inv.InvLocationId == 6 
                        select inv;

            return View("~/Views/InventoryTransfers/VtOutTransfers.cshtml", query);

        }

        public ActionResult VtQoh()
        {
            var query = from tx in db.VtPfeps
                        join mp in db.MasterPartLists on tx.CustomerPn equals mp.CustomerPn
                        where mp.CustomerDivisionId == 1 && mp.CustomerDivisionId == 9 && mp.ActivePartId == 4
                        select tx;

            List<VtQohViewModel> result = new List<VtQohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new VtQohViewModel
                {
                    Vtqohid = qoh.VtPfepId,
                    Pn = qoh.CustomerPn,
                    Qoh = qoh.QohVt,
                    NcrQty = qoh.NcrQtyVt,
                    PfepEsg = qoh.PfepEsg,
                    PfepVt = qoh.PfepVt,
                    MinVt = qoh.MinVt,
                    MaxVt = qoh.MaxVt,
                    KbQty = qoh.KbQty
                });
            }

            return View("~/Views/VtPfeps/VtQoh.cshtml", result);
        }

        public ActionResult VtQoh1()
        {
            var query = from tx in db.VtQohs
                        join it in db.InventoryTransfers.Where(a => a.FinishInvLocationId == 6) on tx.Pn equals it.CustomerPn into fit
                        join it in db.InventoryTransfers.Where(b => b.InvLocationId == 6) on tx.Pn equals it.CustomerPn into it
                        select new
                        {
                            Id = tx.VtQohId,
                            Pn = tx.Pn,
                            Qoh = tx.Qoh + (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum() - (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Notes = tx.Notes
                        };

            List <VtQohViewModel> result = new List<VtQohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new VtQohViewModel
                {
                    Vtqohid = qoh.Id,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/VtQohs/Index.cshtml", result);
        }

        // GET: VtPfeps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtPfep vtPfep = db.VtPfeps.Find(id);
            if (vtPfep == null)
            {
                return HttpNotFound();
            }
            return View(vtPfep);
        }

        // GET: VtPfeps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VtPfeps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VtPfepId,CustomerPn,PartTypeId,QohVt,NcrQtyVt,PfepEsg,PfepVt,MinVt,MaxVt,KbQty")] VtPfep vtPfep)
        {
            if (ModelState.IsValid)
            {
                db.VtPfeps.Add(vtPfep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vtPfep);
        }

        // GET: VtPfeps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtPfep vtPfep = db.VtPfeps.Find(id);
            if (vtPfep == null)
            {
                return HttpNotFound();
            }
            return View(vtPfep);
        }

        // POST: VtPfeps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VtPfepId,CustomerPn,PartTypeId,QohVt,NcrQtyVt,PfepEsg,PfepVt,MinVt,MaxVt,KbQty")] VtPfep vtPfep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vtPfep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vtPfep);
        }

        // GET: VtPfeps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtPfep vtPfep = db.VtPfeps.Find(id);
            if (vtPfep == null)
            {
                return HttpNotFound();
            }
            return View(vtPfep);
        }

        // POST: VtPfeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VtPfep vtPfep = db.VtPfeps.Find(id);
            db.VtPfeps.Remove(vtPfep);
            db.SaveChanges();
            return RedirectToAction("Index");
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
