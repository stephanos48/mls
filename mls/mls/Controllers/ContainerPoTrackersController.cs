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

namespace mls.Controllers
{
    public class ContainerPoTrackersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContainerPoTrackers
        public async Task<ActionResult> Index()
        {
            return View(await db.ContainerPoTrackers.ToListAsync());
        }

        // GET: ContainerPoTrackers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerPoTracker containerPoTracker = await db.ContainerPoTrackers.FindAsync(id);
            if (containerPoTracker == null)
            {
                return HttpNotFound();
            }
            return View(containerPoTracker);
        }

        // GET: ContainerPoTrackers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContainerPoTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ContainerPoTrackerId,PartNumber,PoNumber,Date1stDateTime,Open1stQty,ContainerQty,ConfirmedDateTime,ContainerNo,Notes")] ContainerPoTracker containerPoTracker)
        {
            if (ModelState.IsValid)
            {
                db.ContainerPoTrackers.Add(containerPoTracker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(containerPoTracker);
        }

        // GET: ContainerPoTrackers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerPoTracker containerPoTracker = await db.ContainerPoTrackers.FindAsync(id);
            if (containerPoTracker == null)
            {
                return HttpNotFound();
            }
            return View(containerPoTracker);
        }

        // POST: ContainerPoTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ContainerPoTrackerId,PartNumber,PoNumber,Date1stDateTime,Open1stQty,ContainerQty,ConfirmedDateTime,ContainerNo,Notes")] ContainerPoTracker containerPoTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(containerPoTracker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(containerPoTracker);
        }

        // GET: ContainerPoTrackers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContainerPoTracker containerPoTracker = await db.ContainerPoTrackers.FindAsync(id);
            if (containerPoTracker == null)
            {
                return HttpNotFound();
            }
            return View(containerPoTracker);
        }

        // POST: ContainerPoTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContainerPoTracker containerPoTracker = await db.ContainerPoTrackers.FindAsync(id);
            db.ContainerPoTrackers.Remove(containerPoTracker);
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
