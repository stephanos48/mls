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
    [Authorize]
    public class ShipCommitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShipCommits
        public ActionResult Index()
        {
            return View(db.ShipCommits.ToList());
        }

        // GET: ShipCommits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipCommit shipCommit = db.ShipCommits.Find(id);
            if (shipCommit == null)
            {
                return HttpNotFound();
            }
            return View(shipCommit);
        }

        // GET: ShipCommits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipCommits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipCommitId,Pn,ShipCommit30,ShipCommit31,ShipCommit32,ShipCommit33,ShipCommit34,ShipCommit35,ShipCommit36,ShipCommit37,ShipCommit38,ShipCommit39,ShipCommit40,ShipCommit41,ShipCommit42,ShipCommit43,ShipCommit44,ShipCommit45,ShipCommit46,ShipCommit47,ShipCommit48,ShipCommit49,ShipCommit50,ShipCommit51,ShipCommit52,ShipCommit1,ShipCommit2,ShipCommit3,ShipCommit4,ShipCommit5,ShipCommit6,ShipCommit7,ShipCommit8,ShipCommit9,ShipCommit10,ShipCommit11,ShipCommit12,ShipCommit13,ShipCommit14,ShipCommit15,ShipCommit16,ShipCommit17,ShipCommit18,ShipCommit19,ShipCommit20,ShipCommit21,ShipCommit22,ShipCommit23,ShipCommit24,ShipCommit25,ShipCommit26,ShipCommit27,ShipCommit28,ShipCommit29,Notes")] ShipCommit shipCommit)
        {
            if (ModelState.IsValid)
            {
                db.ShipCommits.Add(shipCommit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipCommit);
        }

        // GET: ShipCommits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipCommit shipCommit = db.ShipCommits.Find(id);
            if (shipCommit == null)
            {
                return HttpNotFound();
            }
            return View(shipCommit);
        }

        // POST: ShipCommits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipCommitId,Pn,ShipCommit30,ShipCommit31,ShipCommit32,ShipCommit33,ShipCommit34,ShipCommit35,ShipCommit36,ShipCommit37,ShipCommit38,ShipCommit39,ShipCommit40,ShipCommit41,ShipCommit42,ShipCommit43,ShipCommit44,ShipCommit45,ShipCommit46,ShipCommit47,ShipCommit48,ShipCommit49,ShipCommit50,ShipCommit51,ShipCommit52,ShipCommit1,ShipCommit2,ShipCommit3,ShipCommit4,ShipCommit5,ShipCommit6,ShipCommit7,ShipCommit8,ShipCommit9,ShipCommit10,ShipCommit11,ShipCommit12,ShipCommit13,ShipCommit14,ShipCommit15,ShipCommit16,ShipCommit17,ShipCommit18,ShipCommit19,ShipCommit20,ShipCommit21,ShipCommit22,ShipCommit23,ShipCommit24,ShipCommit25,ShipCommit26,ShipCommit27,ShipCommit28,ShipCommit29,Notes")] ShipCommit shipCommit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipCommit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipCommit);
        }

        // GET: ShipCommits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipCommit shipCommit = db.ShipCommits.Find(id);
            if (shipCommit == null)
            {
                return HttpNotFound();
            }
            return View(shipCommit);
        }

        // POST: ShipCommits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShipCommit shipCommit = db.ShipCommits.Find(id);
            db.ShipCommits.Remove(shipCommit);
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
