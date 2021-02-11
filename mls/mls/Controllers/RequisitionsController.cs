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
    public class RequisitionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requisitions
        public ActionResult Index()
        {
            var query = from a in db.Requisitions
                        where a.ReqStatusId != 5
                        orderby a.RequisitionId descending
                        select a;
            return View("Index", query);
            //return View(db.Requisitions.ToList());
        }

        public ActionResult Closed()
        {
            var query = from a in db.Requisitions
                        where a.ReqStatusId == 5
                        orderby a.RequisitionId descending
                        select a;
            return View("Closed", query);
            //return View(db.Requisitions.ToList());
        }

        // GET: Requisitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: Requisitions/Create
        public ActionResult Create()
        {
            var statuses = db.ReqStatuses.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveReqViewModel()
            {
                ReqStatuses = statuses,
                MlsDivisions = mlsdivisions
            };

            return View("Create", viewModel);
        }

        // POST: Requisitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "RequisitionId,StatusId,Supplier,Description,PartNumber,RequestDate,NeedDate,EtaDate,Requestor,Notes")] Requisition requisition)
        public ActionResult Create(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Requisitions.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("ReqStatus");
            }

            //return View(requisition);
            return View();
        }

        // GET: Requisitions/Edit/5
        public ActionResult Edit(int? id)
        {
            var requisitions = db.Requisitions.SingleOrDefault(c => c.RequisitionId == id);

            var statuses = db.ReqStatuses.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveReqViewModel()
            {
                Requisition = requisitions,
                MlsDivisions = mlsdivisions,
                ReqStatuses = statuses
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(requisition);
        }

        // POST: Requisitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "RequisitionId,StatusId,Supplier,Description,PartNumber,RequestDate,NeedDate,EtaDate,Requestor,Notes")] Requisition requisition)
        public ActionResult Edit(Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ReqStatus");
            }
            return View();
            //return View(requisition);
        }

        // GET: Requisitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // POST: Requisitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requisition requisition = db.Requisitions.Find(id);
            db.Requisitions.Remove(requisition);
            db.SaveChanges();
            return RedirectToAction("ReqStatus");
        }

        public ActionResult _ReqNew(int status)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqNew", result);
        }

        public ActionResult _ReqSupplierSearch(int status)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqSupplierSearch", result);
        }

        public ActionResult _ReqPayment(int status)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqPayment", result);
        }

        public ActionResult _ReqOrdered(int status)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqOrdered", result);
        }

        public ActionResult _ReqNew1(int status, int div)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status && a.MlsDivisionId == div
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqNew1", result);
        }

        public ActionResult _ReqSupplierSearch1(int status, int div)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status && a.MlsDivisionId == div
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqSupplierSearch1", result);
        }

        public ActionResult _ReqPayment1(int status, int div)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status && a.MlsDivisionId == div
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqPayment1", result);
        }

        public ActionResult _ReqOrdered1(int status, int div)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status && a.MlsDivisionId == div
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqOrdered1", result);
        }

        public ActionResult _ReqComplete(int status, int div)
        {
            var queryNew = from a in db.Requisitions
                           where a.ReqStatusId == status && a.MlsDivisionId == div
                           select a;
            List<NewReqViewModel> result = new List<NewReqViewModel>();
            foreach (var req in queryNew.ToList())
            {
                result.Add(new NewReqViewModel
                {
                    RequisitionId = req.RequisitionId,
                    PartNumber = req.PartNumber,
                    Description = req.Description,
                    Quantity = req.Quantity,
                    RequestDate = req.RequestDate,
                    NeedDate = req.NeedDate,
                    EtaDate = req.EtaDate,
                    Requestor = req.Requestor,
                    Notes = req.Notes
                });
            }
            return PartialView("_ReqComplete", result);
        }

        public ActionResult ReqStatus()
        {
            return View("ReqStatus");
        }

        public ActionResult ReqHyd()
        {
            return View("ReqHyd");
        }

        public ActionResult ReqDip()
        {
            return View("ReqDip");
        }

        public ActionResult ReqSpy()
        {
            return View("ReqSpy");
        }

        public ActionResult ReqDtt()
        {
            return View("ReqDtt");
        }

        public ActionResult ReqDop()
        {
            return View("ReqDop");
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
