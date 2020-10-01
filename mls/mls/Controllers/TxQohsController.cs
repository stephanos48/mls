using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class TxQohsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TxQohs
        public async Task<ActionResult> Index()
        {
            return View(await db.TxQohs.ToListAsync());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohUH()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 1
                        select new
                        {
                            tx.Txqohid,
                            tx.Pn,
                            tx.Qoh
                        };

            List<QohViewModel> qohs = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Id = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh
                };

                qohs.Add(mymodel);
            }

            return View("~/Views/TxQohs/TxQohUH.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDIP()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 4
                        select new
                        {
                            tx.Txqohid,
                            tx.Pn,
                            tx.Qoh
                        };

            List<QohViewModel> qohs = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Id = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh
                };

                qohs.Add(mymodel);
            }

            return View("~/Views/TxQohs/TxQohDIP.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohCL()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 3
                        select new
                        {
                            tx.Txqohid,
                            tx.Pn,
                            tx.Qoh
                        };

            List<QohViewModel> qohs = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Id = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh
                };

                qohs.Add(mymodel);
            }

            return View("~/Views/TxQohs/TxQohCL.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDTT()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 2
                        select new
                        {
                            tx.Txqohid,
                            tx.Pn,
                            tx.Qoh
                        };

            List<QohViewModel> qohs = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Id = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh
                };

                qohs.Add(mymodel);
            }

            return View("~/Views/TxQohs/TxQohDTT.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult TxQohDOP()
        {
            var query = from tx in db.TxQohs
                        join mp in db.MasterPartLists on tx.Pn equals mp.CustomerPn
                        where mp.MlsDivisionId == 5
                        select new
                        {
                            tx.Txqohid,
                            tx.Pn,
                            tx.Qoh
                        };

            List<QohViewModel> qohs = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Id = qoh.Txqohid,
                    Pn = qoh.Pn,
                    Qoh = qoh.Qoh
                };

                qohs.Add(mymodel);
            }

            return View("~/Views/TxQohs/TxQohDOP.cshtml", query);
        }

        // GET: TxQohs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = await db.TxQohs.FindAsync(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View(txQoh);
        }

        // GET: TxQohs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TxQohs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Txqohid,Pn,UhPn,Qoh")] TxQoh txQoh)
        {
            if (ModelState.IsValid)
            {
                db.TxQohs.Add(txQoh);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(txQoh);
        }

        // GET: TxQohs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = await db.TxQohs.FindAsync(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View(txQoh);
        }

        // POST: TxQohs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Txqohid,Pn,UhPn,Qoh")] TxQoh txQoh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(txQoh).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(txQoh);
        }

        // GET: TxQohs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TxQoh txQoh = await db.TxQohs.FindAsync(id);
            if (txQoh == null)
            {
                return HttpNotFound();
            }
            return View(txQoh);
        }

        // POST: TxQohs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TxQoh txQoh = await db.TxQohs.FindAsync(id);
            db.TxQohs.Remove(txQoh);
            await db.SaveChangesAsync();
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
