using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Migrations;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class NcrChinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NcrChinas
        public ActionResult Index()
        {
            return View(db.NcrChinas.ToList());
        }

        // GET: HualinDisposition
        public ActionResult HualinDisposition()
        {
            return View();
        }

        // GET: HualinRework
        public ActionResult HualinRework()
        {
            return View();
        }

        // GET: HualinDisposition
        public ActionResult HualinScrap()
        {
            return View();
        }

        // GET: HualinDisposition
        public ActionResult HualinRTV()
        {
            return View();
        }

        // GET: HualinDisposition
        public ActionResult HualinClosed()
        {
            return View();
        }

        // GET: NcrChinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NcrChina ncrChina = db.NcrChinas.Find(id);
            if (ncrChina == null)
            {
                return HttpNotFound();
            }
            return View(ncrChina);
        }

        // GET: NcrChinas/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrChinaViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                Dispositions = dispositions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                NcrTypes = ncrtypes

            };
            return View(viewModel);
        }

        // POST: NcrChinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Create([Bind(Include = "NcrChinaId,NcrNumber,IssueDateTime,NcrTypeId,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus")] NcrChina ncrChina)
        public ActionResult Create(NcrChina ncrChina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NcrChinas.Add(ncrChina);
                    db.SaveChanges();
                    return RedirectToAction("Index", ncrChina);
                }
            }
            catch (RetryLimitExceededException)
            {
                //Log the error
                ModelState.AddModelError("", "Unable to save changes.  Try again, and if the problem persists, see your system adminstrator.");
            }
            return View();
        }

        // GET: NcrChinas/Edit/5
        public ActionResult Edit(int? id)
        {
            var ncrChinas = db.NcrChinas.SingleOrDefault(c => c.NcrChinaId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrChinaViewModel()
            {
                NcrChina = ncrChinas,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                Dispositions = dispositions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                NcrTypes = ncrtypes

            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NcrChina ncrChina = db.NcrChinas.Find(id);
            if (ncrChina == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: NcrChinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Edit([Bind(Include = "NcrChinaId,NcrNumber,IssueDateTime,NcrTypeId,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus")] NcrChina ncrChina)
        public ActionResult Edit(NcrChina ncrChina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ncrChina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", ncrChina);
            }

            return View(ncrChina);
        }

        // GET: NcrChinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NcrChina ncrChina = db.NcrChinas.Find(id);
            if (ncrChina == null)
            {
                return HttpNotFound();
            }
            return View(ncrChina);
        }

        // POST: NcrChinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NcrChina ncrChina = db.NcrChinas.Find(id);
            db.NcrChinas.Remove(ncrChina);
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
