using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;

namespace mls.Controllers
{
    public class WoBuildsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WoBuilds
        public ActionResult Index()
        {
            return View(db.WoBuilds.ToList());
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
            return View();
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
