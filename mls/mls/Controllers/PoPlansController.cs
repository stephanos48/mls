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
    public class PoPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PoPlans
        public ActionResult Index()
        {
            return View(db.PoPlans.ToList());
        }

        public ActionResult PoPlanStatus()
        {
            return View("PoPlanStatus");
        }

        public ActionResult PoPlanClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("PoPlanClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 8
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("ThiRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoClosed()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 5 && a.CustomerId == 1
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("EsgRoClosed", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult PoPlanCanceled()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 7
                        orderby a.ReceiptDateTime descending
                        select a;
            return View("PoPlanCanceled", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult InTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2
                        orderby a.ContainerUh descending
                        select a;
            return View("InTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult ThiRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 8
                        orderby a.ContainerUh descending
                        select a;
            return View("ThiRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult EsgRoTransit()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 2 && a.CustomerId == 1
                        orderby a.ContainerUh descending
                        select a;
            return View("EsgRoTransit", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult HydOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 1
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("HydOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DipOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 4
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DipOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DttOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 2
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DttOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult DopOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 5
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("DopOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult ClOpen()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId == 4 && a.MlsDivisionId == 3
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("ClOpen", query);
            //return View(db.ShipPlans.ToList());
        }

        public ActionResult LookUp()
        {
            var query = from a in db.PoPlans
                        where a.PoOrderStatusId != 5
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("LookUp", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: PoPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // GET: PoPlans/Details/5
        public ActionResult RoDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // GET: PoPlans/Create
        public ActionResult Create()
        {

            var statuses = db.PoOrderStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SavePoPlanViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PoOrderStatuses = statuses,
                Suppliers = suppliers
            };

            return View("Create", viewModel);
        }

        // POST: PoPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PoPlanId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,PoOrderStatusId,Notes")] PoPlan poPlan)
        public ActionResult Create(PoPlan poPlan)
        {
            if (ModelState.IsValid)
            {
                db.PoPlans.Add(poPlan);
                db.SaveChanges();
                return RedirectToAction("PoPlanStatus");
            }

            //return View(poPlan);
            return View();
        }

        // GET: PoPlans/Edit/5
        public ActionResult Edit(int? id)
        {

            var poplans = db.PoPlans.SingleOrDefault(c => c.PoPlanId == id);

            var statuses = db.PoOrderStatuses.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SavePoPlanViewModel()
            {
                PoPlan = poplans,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PoOrderStatuses = statuses,
                Suppliers = suppliers
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(poPlan);
        }

        // POST: PoPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PoPlanId,PoNumber,PoLine,SupplierId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,PoOrderStatusId,Notes")] PoPlan poPlan)
        public ActionResult Edit(PoPlan poPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PoPlanStatus");
            }
            return View();
            //return View(poPlan);
        }

        // GET: PoPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoPlan poPlan = db.PoPlans.Find(id);
            if (poPlan == null)
            {
                return HttpNotFound();
            }
            return View(poPlan);
        }

        // POST: PoPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoPlan poPlan = db.PoPlans.Find(id);
            db.PoPlans.Remove(poPlan);
            db.SaveChanges();
            return RedirectToAction("PoPlanStatus");
        }

        public ActionResult _Issues(int status)
        {
            var queryNew = from a in db.PoPlans
                           where a.PoOrderStatusId == 3
                           orderby a.ReceiptDateTime ascending
                           select a;
            List<NewPoPlanViewModel> result = new List<NewPoPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewPoPlanViewModel
                {
                    PoPlanId = sp.PoPlanId,
                    CustomerPn = sp.CustomerPn,
                    OrderDateTime = sp.OrderDateTime,
                    PoNumber = sp.PoNumber,
                    PoLine = sp.PoLine,
                    OrderQty = sp.OrderQty,
                    ReceivedQty = sp.ReceivedQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ReceiptDateTime = sp.ReceiptDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_Issues", result);
        }

        public ActionResult _Cancel(int status)
        {
            var queryNew = from a in db.PoPlans
                           where a.PoOrderStatusId == 6
                           orderby a.ReceiptDateTime ascending
                           select a;
            List<NewPoPlanViewModel> result = new List<NewPoPlanViewModel>();
            foreach (var sp in queryNew.ToList())
            {
                result.Add(new NewPoPlanViewModel
                {
                    PoPlanId = sp.PoPlanId,
                    CustomerPn = sp.CustomerPn,
                    OrderDateTime = sp.OrderDateTime,
                    PoNumber = sp.PoNumber,
                    PoLine = sp.PoLine,
                    OrderQty = sp.OrderQty,
                    ReceivedQty = sp.ReceivedQty,
                    RequestedDateTime = sp.RequestedDateTime,
                    PromiseDateTime = sp.PromiseDateTime,
                    ReceiptDateTime = sp.ReceiptDateTime,
                    Notes = sp.Notes
                });
            }
            return PartialView("_Cancel", result);
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
