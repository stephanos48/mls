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
    public class SafetyIncidentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SafetyIncidents
        public ActionResult Index()
        {
            return View(db.SafetyIncidents.ToList());
        }

        // GET: SafetyIncidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyIncident safetyIncident = db.SafetyIncidents.Find(id);
            if (safetyIncident == null)
            {
                return HttpNotFound();
            }
            return View(safetyIncident);
        }

        // GET: SafetyIncidents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SafetyIncidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SafetyIncidentId,IncidentDate,IncidentDetails,Employee,IncidentType,CorrectieAction,Notes")] SafetyIncident safetyIncident)
        {
            if (ModelState.IsValid)
            {
                db.SafetyIncidents.Add(safetyIncident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(safetyIncident);
        }

        // GET: SafetyIncidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyIncident safetyIncident = db.SafetyIncidents.Find(id);
            if (safetyIncident == null)
            {
                return HttpNotFound();
            }
            return View(safetyIncident);
        }

        // POST: SafetyIncidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SafetyIncidentId,IncidentDate,IncidentDetails,Employee,IncidentType,CorrectieAction,Notes")] SafetyIncident safetyIncident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safetyIncident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(safetyIncident);
        }

        // GET: SafetyIncidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SafetyIncident safetyIncident = db.SafetyIncidents.Find(id);
            if (safetyIncident == null)
            {
                return HttpNotFound();
            }
            return View(safetyIncident);
        }

        // POST: SafetyIncidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SafetyIncident safetyIncident = db.SafetyIncidents.Find(id);
            db.SafetyIncidents.Remove(safetyIncident);
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
