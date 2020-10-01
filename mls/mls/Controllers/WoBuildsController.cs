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
    public class WoBuildsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WoBuilds
        public ActionResult Index()
        {
            return View(db.WoBuilds.ToList().OrderByDescending(s => s.WoEnterDateTime));
        }

        // GET: WoBuilds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoBuild woBuild = db.WoBuilds.Find(id);
            if (woBuild == null)
            {
                return HttpNotFound();
            }
            return View(woBuild);
        }

        // GET: WoBuilds/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var contractors = db.Contractors.ToList();

            var viewModel = new WoBuildViewModel()
            {
                Contractors = contractors
            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: WoBuilds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "WoBuildId,WoEnterDateTime,WoNo,CustomerPn,Qty,Notes")] WoBuild woBuild)
        public ActionResult Create(WoBuild woBuild, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.WoBuilds.Add(woBuild);
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
            //return View(woBuild);
        }

        // GET: WoBuilds/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;

            var wobuilds = db.WoBuilds.SingleOrDefault(c => c.WoBuildId == id);

            var contractors = db.Contractors.ToList();

            var viewModel = new WoBuildViewModel()
            {
                WoBuild = wobuilds,
                Contractors = contractors
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoBuild woBuild = db.WoBuilds.Find(id);
            if (woBuild == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(woBuild);
        }

        // POST: WoBuilds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "WoBuildId,WoEnterDateTime,WoNo,CustomerPn,Qty,Notes")] WoBuild woBuild)
        public ActionResult Edit(WoBuild woBuild, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(woBuild).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(returnUrl);
            }
            //return View(woBuild);
            return View();
        }

        public ActionResult WoProcess()
        {
            return View();
        }

        public ActionResult ProcessBuild(int buildqty, string Pn, string WoNo, byte contractor)
        {

            List<BomLevel1> boms = new List<BomLevel1>();

            boms = db.BomLevel1s.ToList();

            WoBuild build = new WoBuild();

            WoBuild takeout = new WoBuild();

            WoBuild takeout1 = new WoBuild();

            BomLevel1 dpn = new BomLevel1();

            List<BomLevel1> selectboms = new List<BomLevel1>();

            if (boms.Any(i => i.UnitNo == Pn))
            {

                //add the built part to be assembled
                build.WoEnterDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                build.ContractorId = contractor;
                build.WoNo = WoNo;
                build.CustomerPn = Pn;
                build.Qty = buildqty;
                build.Notes = null;

                db.WoBuilds.Add(build);
                db.SaveChanges();

                //create a list of parts in bom
                foreach (BomLevel1 a in boms)
                {

                    if (a.UnitNo == Pn)
                    {
                        dpn.BomNo = a.BomNo;
                        dpn.UnitNo = a.UnitNo;
                        dpn.DetailPn = a.DetailPn;
                        dpn.Description = a.Description;
                        dpn.PurchaseMake = a.PurchaseMake;
                        dpn.PartType = a.PartType;
                        dpn.PartTypeDetail = a.PartTypeDetail;
                        dpn.QtyPer = a.QtyPer;

                        selectboms.Add(dpn);
                    }

                }

                //take out parts that were used to build assembly
                foreach (BomLevel1 b in boms)
                {
                    if (b.UnitNo == Pn)
                    {
                        takeout.WoEnterDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                        takeout.ContractorId = contractor;
                        takeout.WoNo = WoNo;
                        takeout.CustomerPn = b.DetailPn;
                        takeout.Qty = (b.QtyPer * -buildqty);
                        takeout.Notes = null;

                        db.WoBuilds.Add(takeout);
                        db.SaveChanges();
                    }
                }
                 
                //take out sub part numbers
                foreach (BomLevel1 c in boms)
                {

                    foreach (BomLevel1 d in selectboms)
                    {

                        if (c.UnitNo == d.DetailPn)
                        {
                            takeout1.WoEnterDateTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                            takeout1.ContractorId = contractor;
                            takeout1.WoNo = WoNo;
                            takeout1.CustomerPn = c.DetailPn;
                            takeout1.Qty = (c.QtyPer * -buildqty);
                            takeout1.Notes = null;

                            db.WoBuilds.Add(takeout1);
                            db.SaveChanges();
                        }

                    }
                }
                return null;
            }
            else
            {
                ViewBag.Message = "BOM does not exist.  Please create.";
                return null;
            }

        }

        // GET: WoBuilds/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WoBuild woBuild = db.WoBuilds.Find(id);
            if (woBuild == null)
            {
                return HttpNotFound();
            }
            return View(woBuild);
        }

        // POST: WoBuilds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WoBuild woBuild = db.WoBuilds.Find(id);
            db.WoBuilds.Remove(woBuild);
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
