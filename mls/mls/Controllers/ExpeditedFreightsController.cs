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

        public ActionResult ExpFreightHome()
        {
            return View();
        }

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

        public ActionResult Paid()
        {
            var query = from a in db.ExpeditedFreights
                        where a.StatusId == 2
                        orderby a.ExpeditedFreightId descending
                        select a;
            return View("Paid", query);
        }

        public ActionResult Open()
        {
            var query = from a in db.ExpeditedFreights
                        where a.StatusId != 2
                        orderby a.ExpeditedFreightId descending
                        select a;
            return View("Open", query);
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

            var statuses = db.Statuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveExpFreightViewModel()
            {
                Statuses = statuses,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions
            };

            return View("Create", viewModel);
        }

        // POST: ExpeditedFreights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ExpeditedFreightId,ExpeditedFreightNo,PartNumber,StatusId, ExpeditedFreightType,RequestedBy,RequestDateTime,NeedDateTime,InvoiceNo, Destination,Reason,Notes")] ExpeditedFreight expeditedFreight)
        public ActionResult Create(ExpeditedFreight expeditedFreight)
        {
            if (ModelState.IsValid)
            {
                db.ExpeditedFreights.Add(expeditedFreight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //return View(expeditedFreight);
        }

        // GET: ExpeditedFreights/Edit/5
        public ActionResult Edit(int? id)
        {
            var expeditedfreights = db.ExpeditedFreights.SingleOrDefault(c => c.ExpeditedFreightId == id);

            var statuses = db.Statuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveExpFreightViewModel()
            {
                ExpeditedFreight = expeditedfreights,
                Statuses = statuses,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpeditedFreight expeditedFreight = db.ExpeditedFreights.Find(id);
            if (expeditedFreight == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(expeditedFreight);
        }

        // POST: ExpeditedFreights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ExpeditedFreightId,ExpeditedFreightNo,StatusId, PartNumber,ExpeditedFreightType,RequestedBy,RequestDateTime,InvoiceNo, NeedDateTime,Destination,Reason,Notes")] ExpeditedFreight expeditedFreight)
        public ActionResult Edit(ExpeditedFreight expeditedFreight)
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
