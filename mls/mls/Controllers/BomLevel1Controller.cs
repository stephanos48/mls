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
    public class BomLevel1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BomLevel1
        public ActionResult Index(string search)
        {
            return View(db.BomLevel1s.Where(x => x.UnitNo.Contains(search) || search == null).ToList());
            //return View();
        }

        // GET: BomLevel1
        public ActionResult Search()
        {
            return View(db.BomLevel1s);
            //return View();
        }

        // GET: BomLevel1
        public ActionResult EngHome()
        {
            return View();
            //return View();
        }

        // GET: BomLevel1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BomLevel1 bomLevel1 = db.BomLevel1s.Find(id);
            if (bomLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(bomLevel1);
        }

        public ActionResult BuildAbility(string search)
        {
            //LocationViewModel1 mymodel = new LocationsViewModel1();

            var startDate = DateTime.Parse("5/11/2020");
            var query = from a in db.BomLevel1s
                        join tx in db.TxQohs on a.DetailPn equals tx.Pn
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlans.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
                        join c in db.CycleCounts.Where(u => u.CycleCountDateTime >= startDate) on tx.Pn equals c.CustomerPn into cr
                        join n in db.NCRs.Where(u => u.StatusId != 2) on tx.Pn equals n.PartNumber into nr
                        orderby tx.Pn
                        orderby a.BomNo ascending
                        select new
                        {
                            a.BomNo,
                            a.UnitNo,
                            a.DetailPn,
                            a.Description,
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum() + (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum() + (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                            a.QtyPer,
                            NcrQty = (int?)nr.Select(x => x.Quantity).DefaultIfEmpty(0).Sum(),
                        };


            /*var query = from a in db.BomLevel1s
                        join tx in db.TxQohs on a.DetailPn equals tx.Pn
                        orderby a.BomNo ascending
                        select new
                        {
                            a.BomNo,
                            a.UnitNo,
                            a.DetailPn,
                            a.Description,
                            tx.Qoh,
                            a.QtyPer,
                            tx.NcrQty
                        };*/

            //new LocationViewModel1
            //{
            //    a.CustomerPn, a.PartDescription, a.Location, tx.Qoh
            //            }

            List<BomViewModel> boms = new List<BomViewModel>();
            foreach (var bom in query.ToList())
            {
                BomViewModel mymodel = new BomViewModel()
                {
                    BomNo = bom.BomNo,
                    UnitNo = bom.UnitNo,
                    DetailPn = bom.DetailPn,
                    Description = bom.Description,
                    Qoh = bom.Qoh,
                    QtyPer = bom.QtyPer,
                    NcrQty = bom.NcrQty,
                    BuildAbility = (bom.Qoh / bom.QtyPer)
                };


                boms.Add(mymodel);
            }


            return View("~/Views/BomLevel1/BuildAbility.cshtml", boms.Where(x => x.UnitNo.Contains(search) || search == null).ToList());
        }

        /*public ActionResult BuildAbility(string pn)
        {

            List<BomLevel1> bom = (from b in db.BomLevel1s
                                   where b.UnitNo == pn
                                   select b).ToList();
            return View(bom);

        }*/



        // GET: BomLevel1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BomLevel1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BomLevel1Id,BomNo,UnitNo,DetailPn,Description,QtyPer,Qoh")] BomLevel1 bomLevel1)
        {
            if (ModelState.IsValid)
            {
                db.BomLevel1s.Add(bomLevel1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Search", bomLevel1);
            //return View(bomLevel1);
        }

        // GET: BomLevel1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BomLevel1 bomLevel1 = db.BomLevel1s.Find(id);
            if (bomLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(bomLevel1);
        }

        // POST: BomLevel1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BomLevel1Id,BomNo,UnitNo,DetailPn,Description,QtyPer,Qoh")] BomLevel1 bomLevel1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bomLevel1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bomLevel1);
        }

        // GET: BomLevel1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BomLevel1 bomLevel1 = db.BomLevel1s.Find(id);
            if (bomLevel1 == null)
            {
                return HttpNotFound();
            }
            return View(bomLevel1);
        }

        // POST: BomLevel1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BomLevel1 bomLevel1 = db.BomLevel1s.Find(id);
            db.BomLevel1s.Remove(bomLevel1);
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
