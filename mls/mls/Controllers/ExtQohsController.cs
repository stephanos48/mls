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
    public class ExtQohsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExtQohs
        public ActionResult Index()
        {
            return View(db.ExtQohs.ToList());
        }

        public ActionResult ExtQoh1s()
        {
            var startDate = DateTime.Parse("12/16/2020");
            var query = from tx in db.ExtQohs
                        join it in db.InventoryTransfers.Where(c => c.TransferDateTime >= startDate).Where(a => a.FinishInvLocationId == 5) on tx.Pn equals it.CustomerPn into fit
                        join it in db.InventoryTransfers.Where(c => c.TransferDateTime >= startDate).Where(b => b.InvLocationId == 5) on tx.Pn equals it.CustomerPn into it
                        join wo in db.WoBuilds.Where(c => c.WoEnterDateTime >= startDate).Where(d => d.ContractorId == 2) on tx.Pn equals wo.CustomerPn into w
                        //join wo in db.WoBuilds.Where(d => d.ContractorId == 2) on tx.Pn equals wo.CustomerPn into w
                        orderby tx.Pn ascending
                        select new
                        {
                            Id = tx.ExtQohId,
                            Pn = tx.Pn,
                            Qoh = tx.Qoh + (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum() + (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum() + (int?)w.Select(x => x.Qty).DefaultIfEmpty(0).Sum(),
                            Qoh731 = tx.Qoh,
                            InvIn = (int?)fit.Select(x => x.TransferToQty).DefaultIfEmpty(0).Sum(),
                            InvOut = (int?)it.Select(x => x.TransferFromQty).DefaultIfEmpty(0).Sum(),
                            Wo = (int?)w.Select(x => x.Qty).DefaultIfEmpty(0).Sum(),
                            Notes = tx.Notes
                        };

            List<ExtQohViewModel> result = new List<ExtQohViewModel>();
            foreach (var qoh in query.ToList())
            {
                result.Add(new ExtQohViewModel
                {
                    ExtQohId = qoh.Id,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh,
                    Qoh731 = qoh.Qoh731,
                    InvIn = qoh.InvIn,
                    InvOut = qoh.InvOut,
                    Wo = qoh.Wo,
                    Notes = qoh.Notes
                });
            }

            return View("~/Views/ExtQohs/ExtQoh1s.cshtml", result);
        }

        // GET: ExtQohs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtQoh extQoh = db.ExtQohs.Find(id);
            if (extQoh == null)
            {
                return HttpNotFound();
            }
            return View(extQoh);
        }

        // GET: ExtQohs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtQohs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExtQohId,Pn,PartDescription,Qoh,Location,Notes")] ExtQoh extQoh)
        {
            if (ModelState.IsValid)
            {
                db.ExtQohs.Add(extQoh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extQoh);
        }

        // GET: ExtQohs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtQoh extQoh = db.ExtQohs.Find(id);
            if (extQoh == null)
            {
                return HttpNotFound();
            }
            return View(extQoh);
        }

        // POST: ExtQohs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExtQohId,Pn,PartDescription,Qoh,Location,Notes")] ExtQoh extQoh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extQoh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extQoh);
        }

        // GET: ExtQohs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtQoh extQoh = db.ExtQohs.Find(id);
            if (extQoh == null)
            {
                return HttpNotFound();
            }
            return View(extQoh);
        }

        // POST: ExtQohs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtQoh extQoh = db.ExtQohs.Find(id);
            db.ExtQohs.Remove(extQoh);
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
