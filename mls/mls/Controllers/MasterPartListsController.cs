using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    [Authorize]
    public class MasterPartListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        // GET: MasterPartLists
        public ActionResult Index()
        {
            return View(db.MasterPartLists.ToList());
        }

        // GET: Locations
        public ActionResult Locations()
        {
            /*var query = from mp in db.MasterPartLists
                join tx in db.TxQohs on mp.CustomerPn equals tx.Pn
                orderby mp.CustomerPn descending
                select new
                {
                   mp.CustomerPn,
                   mp.PartDescription,
                   tx.Qoh,
                   mp.Location,
                   mp.Weight,
                   mp.Notes 
                };*/
            var query = from a in db.MasterPartLists
                orderby a.CustomerPn descending
                select a;
            return View("Locations", query);
        }

        // GET: MasterPartLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View(masterPartList);
        }

        // GET: MasterPartLists/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveMasterViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: MasterPartLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PartId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartType,CustomerPn,MlsPn,PartDescription,PartPrice,PartCost,Weight,StdPack,Notes")] MasterPartList masterPartList)
        public ActionResult Create(MasterPartList masterPartList, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.MasterPartLists.Add(masterPartList);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View();
            //return View(masterPartList);
        }

        // GET: MasterPartLists/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var masterpartlists = db.MasterPartLists.SingleOrDefault(c => c.PartId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveMasterViewModel()
            {
                MasterPartList = masterpartlists,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(masterPartList);
        }

        // POST: MasterPartLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PartId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartType,CustomerPn,MlsPn,PartDescription,PartPrice,PartCost,Weight,StdPack,Notes")] MasterPartList masterPartList)
        public ActionResult Edit(MasterPartList masterPartList, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterPartList).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(masterPartList);
        }

        // GET: MasterPartLists/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View(masterPartList);
        }

        // POST: MasterPartLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            db.MasterPartLists.Remove(masterPartList);
            db.SaveChanges();
            return Redirect(returnUrl);
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
