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
    public class VtQohsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VtQohs
        public ActionResult Index()
        {
            return View(db.VtQohs.ToList());
        }

        public ActionResult VtQoh1s()
        {
            var query = from tx in db.VtQohs
                        join it in db.InventoryTransfers.Where(a => a.FinishInvLocationId == 6) on tx.Pn equals it.CustomerPn into fit
                        join it in db.InventoryTransfers.Where(b => b.InvLocationId == 6) on tx.Pn equals it.CustomerPn into it
                        select new
                        {
                            Id = tx.VtQohId,
                            Pn = tx.Pn,
                            Qoh = tx.Qoh + (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum() + (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Qoh731 = tx.Qoh,
                            InvIn = (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum(),
                            InvOut = (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Notes = tx.Notes
                        };

            List<VtQohViewModel> result = new List<VtQohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new VtQohViewModel
                {
                    Vtqohid = qoh.Id,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    Qoh731 = qoh.Qoh731,
                    InvIn = qoh.InvIn,
                    InvOut = qoh.InvOut,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/VtQohs/VtQoh1s.cshtml", result);
        }

        public ActionResult VtQohs()
        {
            var query = from tx in db.VtQohs
                        join it in db.InventoryTransfers.Where(a => a.FinishInvLocationId == 6) on tx.Pn equals it.CustomerPn into fit
                        join it in db.InventoryTransfers.Where(b => b.InvLocationId == 6) on tx.Pn equals it.CustomerPn into it
                        select new
                        {
                            Id = tx.VtQohId,
                            Pn = tx.Pn,
                            Qoh = tx.Qoh + (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum() + (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Qoh731 = tx.Qoh,
                            InvIn = (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum(),
                            InvOut = (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Notes = tx.Notes
                        };

            List<VtQohViewModel> result = new List<VtQohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new VtQohViewModel
                {
                    Vtqohid = qoh.Id,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    Qoh731 = qoh.Qoh731,
                    InvIn = qoh.InvIn,
                    InvOut = qoh.InvOut,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/VtQohs/VtQohs.cshtml", result);
        }

        // GET: VtQohs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtQoh vtQoh = db.VtQohs.Find(id);
            if (vtQoh == null)
            {
                return HttpNotFound();
            }
            return View(vtQoh);
        }

        // GET: VtQohs/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;

            return View();
        }

        // POST: VtQohs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "VtQohId,Pn,PartDescription,Qoh,Location,Notes")] VtQoh vtQoh)
        public ActionResult Create(VtQoh vtQoh, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.VtQohs.Add(vtQoh);
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
            //return View(vtQoh);
        }

        // GET: VtQohs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtQoh vtQoh = db.VtQohs.Find(id);
            if (vtQoh == null)
            {
                return HttpNotFound();
            }
            //return View("Edit", viewModel);
            return View(vtQoh);
        }

        // POST: VtQohs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "VtQohId,Pn,PartDescription,Qoh,Location,Notes")] VtQoh vtQoh)
        public ActionResult Edit(VtQoh vtQoh, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vtQoh).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
            //return View(vtQoh);
        }

        // GET: VtQohs/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VtQoh vtQoh = db.VtQohs.Find(id);
            if (vtQoh == null)
            {
                return HttpNotFound();
            }
            return View(vtQoh);
        }

        // POST: VtQohs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            VtQoh vtQoh = db.VtQohs.Find(id);
            db.VtQohs.Remove(vtQoh);
            db.SaveChanges();
            return Redirect(returnUrl);
            //return RedirectToAction("Index");
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
