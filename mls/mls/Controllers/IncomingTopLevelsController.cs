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
    public class IncomingTopLevelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IncomingTopLevels
        //public ActionResult Index()
        //{
        //  return View(db.IncomingTopLevels.ToList());
        //}

        public ActionResult Index(int? id)
        {
            var viewModel = new IncomingIndexDataViewModel();
            viewModel.IncomingTopLevels = db.IncomingTopLevels
                .Include(i => i.IncomingDetails);

            if (id != null)
            {
                ViewBag.IncomingTopLevelId = id.Value;
                viewModel.IncomingDetails = viewModel.IncomingTopLevels.Single(
                    i => i.IncomingTopLevelId == id.Value).IncomingDetails;
            }

            return View(viewModel);
        }

        // GET: IncomingTopLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            if (incomingTopLevel == null)
            {
                return HttpNotFound();
            }
            return View(incomingTopLevel);
        }

        // GET: IncomingTopLevels/Create
        public ActionResult Angular()
        {
            return View();
        }

        public ActionResult ShowIncoming()
        {
            return PartialView("_ShowIncoming");
        }

        // GET: IncomingTopLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomingTopLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomingTopLevelId,IncomingVesselNo,InspectionDateTime,Notes")] IncomingTopLevel incomingTopLevel)
        {
            if (ModelState.IsValid)
            {
                db.IncomingTopLevels.Add(incomingTopLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incomingTopLevel);
        }

        // GET: IncomingTopLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            if (incomingTopLevel == null)
            {
                return HttpNotFound();
            }
            return View(incomingTopLevel);
        }

        // POST: IncomingTopLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomingTopLevelId,IncomingVesselNo,InspectionDateTime,Notes")] IncomingTopLevel incomingTopLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingTopLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incomingTopLevel);
        }

        // GET: IncomingTopLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            if (incomingTopLevel == null)
            {
                return HttpNotFound();
            }
            return View(incomingTopLevel);
        }

        // POST: IncomingTopLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingTopLevel incomingTopLevel = db.IncomingTopLevels.Find(id);
            db.IncomingTopLevels.Remove(incomingTopLevel);
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
