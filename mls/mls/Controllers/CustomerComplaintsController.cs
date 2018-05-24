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
    public class CustomerComplaintsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerComplaints
        public ActionResult Index()
        {
            var query = from a in db.CustomerComplaints
                        orderby a.ComplaintDate ascending
                        select a;
            return View("Index", query);
        }

        // GET: CustomerComplaints/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerComplaint customerComplaint = db.CustomerComplaints.Find(id);
            if (customerComplaint == null)
            {
                return HttpNotFound();
            }
            return View(customerComplaint);
        }

        // GET: CustomerComplaints/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var complaintseverities = db.ComplaintSeverities.ToList();
            var complainttypes = db.ComplaintTypes.ToList();

            var viewModel = new SaveComplaintViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                ComplaintSeverities = complaintseverities,
                ComplaintTypes = complainttypes

            };
            
            return View("Create", viewModel);
        }

        // POST: CustomerComplaints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CustomerComplaintId,ComplaintDate,CustomerId,CustomerDivisionId,ComplaintSeverityId,MlsDivisionId,CustomerPn,ComplaintTypeId,CommplaintDetail,StatusId,Notes")] CustomerComplaint customerComplaint)
        public ActionResult Create(CustomerComplaint customerComplaint, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.CustomerComplaints.Add(customerComplaint);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View();
            //return View(customerComplaint);
        }

        // GET: CustomerComplaints/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customercomplaints = db.CustomerComplaints.SingleOrDefault(c => c.CustomerComplaintId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var complaintseverities = db.ComplaintSeverities.ToList();
            var complainttypes = db.ComplaintTypes.ToList();

            var viewModel = new SaveComplaintViewModel()
            {
                CustomerComplaint = customercomplaints,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                ComplaintSeverities = complaintseverities,
                ComplaintTypes = complainttypes

            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerComplaint customerComplaint = db.CustomerComplaints.Find(id);
            if (customerComplaint == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(customerComplaint);
        }

        // POST: CustomerComplaints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CustomerComplaintId,ComplaintDate,CustomerId,CustomerDivisionId,ComplaintSeverityId,MlsDivisionId,CustomerPn,ComplaintTypeId,CommplaintDetail,StatusId,Notes")] CustomerComplaint customerComplaint)
        public ActionResult Edit(CustomerComplaint customerComplaint, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerComplaint).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(customerComplaint);
        }

        // GET: CustomerComplaints/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerComplaint customerComplaint = db.CustomerComplaints.Find(id);
            if (customerComplaint == null)
            {
                return HttpNotFound();
            }
            return View(customerComplaint);
        }

        // POST: CustomerComplaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            CustomerComplaint customerComplaint = db.CustomerComplaints.Find(id);
            db.CustomerComplaints.Remove(customerComplaint);
            db.SaveChanges();
            return Redirect(returnUrl);
            //return RedirectToAction("Index");
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
