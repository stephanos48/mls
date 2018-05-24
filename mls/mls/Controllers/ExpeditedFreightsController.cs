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
    public class ExpeditedFreightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExpeditedFreights
        //public ActionResult Index()
        //{
        //  return View(db.ExpeditedFreights.ToList());
        //}

        public ActionResult Index(int? id)
        {
            var viewModel = new ExpeditedFreightDataViewModel();
            viewModel.ExpeditedFreights = db.ExpeditedFreights
                .Include(i => i.ExpFreightDetails);

            if (id != null)
            {
                ViewBag.ExpeditedFreightId = id.Value;
                viewModel.ExpFreightDetails = viewModel.ExpeditedFreights.Single(
                    i => i.ExpeditedFreightId == id.Value).ExpFreightDetails;
            }

            return View(viewModel);
        }

        // GET: ExpeditedFreights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpeditedFreight expeditedFreight = db.ExpeditedFreights.Find(id);
            if (expeditedFreight == null)
            {
                return HttpNotFound();
            }
            return View(expeditedFreight);
        }

        // GET: ExpeditedFreights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpeditedFreights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpeditedFreightId,ExpeditedFreightNo,PartNumber,ExpeditedFreightType,RequestedBy,RequestDateTime,NeedDateTime,Destination,Reason,Notes")] ExpeditedFreight expeditedFreight)
        {
            if (ModelState.IsValid)
            {
                db.ExpeditedFreights.Add(expeditedFreight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expeditedFreight);
        }

        // GET: ExpeditedFreights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpeditedFreight expeditedFreight = db.ExpeditedFreights.Find(id);
            if (expeditedFreight == null)
            {
                return HttpNotFound();
            }
            return View(expeditedFreight);
        }

        // POST: ExpeditedFreights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpeditedFreightId,ExpeditedFreightNo,PartNumber,ExpeditedFreightType,RequestedBy,RequestDateTime,NeedDateTime,Destination,Reason,Notes")] ExpeditedFreight expeditedFreight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expeditedFreight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expeditedFreight);
        }

        // GET: ExpeditedFreights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpeditedFreight expeditedFreight = db.ExpeditedFreights.Find(id);
            if (expeditedFreight == null)
            {
                return HttpNotFound();
            }
            return View(expeditedFreight);
        }

        // POST: ExpeditedFreights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpeditedFreight expeditedFreight = db.ExpeditedFreights.Find(id);
            db.ExpeditedFreights.Remove(expeditedFreight);
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
