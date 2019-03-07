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
    public class DownReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DownReports
        public ActionResult Index()
        {
            return View(db.DownReports.ToList());
        }
        
        public ActionResult Uh()
        {
            return View();
        }

        public ActionResult Dtt()
        {
            return View();
        }

        public ActionResult Cl()
        {
            return View();
        }

        // GET: DownReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownReport downReport = db.DownReports.Find(id);
            if (downReport == null)
            {
                return HttpNotFound();
            }
            return View(downReport);
        }

        // GET: DownReports/Create
        public ActionResult Create()
        {

            var downstatuses = db.DownStatuses.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveDownViewModel()
            {
                DownStatuses = downstatuses,
                MlsDivisions = mlsdivisions
            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: DownReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DownReportId,CreationDateTime,CustomerPn,QtyNeeded,MlsWo,CustomerPo,EstArrivalDateTime,Status,Reason,Notes")] DownReport downReport)
        public ActionResult Create(DownReport downReport)
        {
            if (ModelState.IsValid)
            {
                db.DownReports.Add(downReport);
                db.SaveChanges();
                return RedirectToAction("DownAlt", "WorkOrders");
            }

            return View();
            //return View(downReport);
        }

        // GET: DownReports/Edit/5
        public ActionResult Edit(int? id)
        {
            var downreports = db.DownReports.SingleOrDefault(c => c.DownReportId == id);

            var downstatuses = db.DownStatuses.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SaveDownViewModel()
            {
                DownReport = downreports,
                MlsDivisions = mlsdivisions,
                DownStatuses = downstatuses
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownReport downReport = db.DownReports.Find(id);
            if (downReport == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(downReport);
        }

        // POST: DownReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DownReportId,CreationDateTime,CustomerPn,QtyNeeded,MlsWo,CustomerPo,EstArrivalDateTime,Status,Reason,Notes")] DownReport downReport)
        public ActionResult Edit(DownReport downReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DownAlt");
            }
            //return View(downReport);
            return View();
        }

        // GET: DownReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownReport downReport = db.DownReports.Find(id);
            if (downReport == null)
            {
                return HttpNotFound();
            }
            return View(downReport);
        }

        // POST: DownReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownReport downReport = db.DownReports.Find(id);
            db.DownReports.Remove(downReport);
            db.SaveChanges();
            return RedirectToAction("DownAlt");
        }

        public ActionResult _ClosedDownPartialView()
        {

        var queryNew = from a in db.DownReports
                where a.DownStatusId == 4
                orderby a.CreationDateTime descending
                select a;
        List<NewDownViewModel> result = new List<NewDownViewModel>();
        foreach (var down in queryNew.ToList())
        {
            result.Add(new NewDownViewModel()
            {
                DownReportId = down.DownReportId,
                MlsDivision = down.MlsDivision,
                CreationDateTime = down.CreationDateTime,
                CustomerPn = down.CustomerPn,
                QtyNeeded = down.QtyNeeded,
                MlsWo = down.MlsWo,
                CustomerPo = down.CustomerPo,
                EstArrivalDateTime = down.EstArrivalDateTime,
                DownStatusId = down.DownStatusId,
                Reason = down.Reason,
                Notes = down.Notes
            });
        }

        return PartialView("_ClosedDownPartialView", result);

        //return View();
        }

        public ActionResult _InProcessDownPartialView()
        {
            var queryNew = from a in db.DownReports
                           where a.DownStatusId == 3
                           orderby a.CreationDateTime descending
                           select a;
            List<NewDownViewModel> result = new List<NewDownViewModel>();
            foreach (var down in queryNew.ToList())
            {
                result.Add(new NewDownViewModel()
                {
                    DownReportId = down.DownReportId,
                    MlsDivision = down.MlsDivision,
                    CreationDateTime = down.CreationDateTime,
                    CustomerPn = down.CustomerPn,
                    QtyNeeded = down.QtyNeeded,
                    MlsWo = down.MlsWo,
                    CustomerPo = down.CustomerPo,
                    EstArrivalDateTime = down.EstArrivalDateTime,
                    DownStatusId = down.DownStatusId,
                    Reason = down.Reason,
                    Notes = down.Notes
                });
            }

            return PartialView("_InProcessDownPartialView", result);
        }

        public ActionResult _ResponseDownPartialView()
        {
            var queryNew = from a in db.DownReports
                           where a.DownStatusId == 2
                           orderby a.CreationDateTime descending
                           select a;
            List<NewDownViewModel> result = new List<NewDownViewModel>();
            foreach (var down in queryNew.ToList())
            {
                result.Add(new NewDownViewModel()
                {
                    DownReportId = down.DownReportId,
                    MlsDivision = down.MlsDivision,
                    CreationDateTime = down.CreationDateTime,
                    CustomerPn = down.CustomerPn,
                    QtyNeeded = down.QtyNeeded,
                    MlsWo = down.MlsWo,
                    CustomerPo = down.CustomerPo,
                    EstArrivalDateTime = down.EstArrivalDateTime,
                    DownStatusId = down.DownStatusId,
                    Reason = down.Reason,
                    Notes = down.Notes
                });
            }

            return PartialView("_ResponseDownPartialView", result);
        }

        public ActionResult _NewDownPartialView()
        {
            var queryNew = from a in db.DownReports
                           where a.DownStatusId == 1
                           orderby a.CreationDateTime descending
                           select a;
            List<NewDownViewModel> result = new List<NewDownViewModel>();
            foreach (var down in queryNew.ToList())
            {
                result.Add(new NewDownViewModel()
                {
                    DownReportId = down.DownReportId,
                    MlsDivision = down.MlsDivision,
                    CreationDateTime = down.CreationDateTime,
                    CustomerPn = down.CustomerPn,
                    QtyNeeded = down.QtyNeeded,
                    MlsWo = down.MlsWo,
                    CustomerPo = down.CustomerPo,
                    EstArrivalDateTime = down.EstArrivalDateTime,
                    DownStatusId = down.DownStatusId,
                    Reason = down.Reason,
                    Notes = down.Notes
                });
            }

            return PartialView("_NewDownPartialView", result);
        }

        [HttpGet]
        public ActionResult DownAlt()
        {
            var queryNew = from co in db.DownReports
                           where co.DownStatusId != 4
                           orderby co.CreationDateTime ascending
                           select new
                           {
                               DownReportId = co.DownReportId,
                               MlsDivisionId = co.MlsDivisionId,
                               CreationDateTime = co.CreationDateTime,
                               CustomerPn = co.CustomerPn,
                               CustomerPo = co.CustomerPo,
                               QtyNeeded = co.QtyNeeded,
                               MlsWo = co.MlsWo,
                               EstArrivalDateTime = co.EstArrivalDateTime,
                               DownStatusId = co.DownStatusId,
                               Reason = co.Reason,
                               Notes = co.Notes
                           };
            List<OpenDownViewModel> result = new List<OpenDownViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenDownViewModel
                {
                    DownReportId = order.DownReportId,
                    MlsDivisionId = order.MlsDivisionId,
                    CreationDateTime = order.CreationDateTime,
                    CustomerPn = order.CustomerPn,
                    CustomerPo = order.CustomerPo,
                    QtyNeeded = order.QtyNeeded,
                    MlsWo = order.MlsWo,
                    EstArrivalDateTime = order.EstArrivalDateTime,
                    DownStatusId = order.DownStatusId,
                    Reason = order.Reason,
                    Notes = order.Notes
                });
            }

            return View("Index", result);
        }

        [HttpGet]
        public ActionResult DownAltClosed()
        {
            var queryNew = from co in db.DownReports
                           where co.DownStatusId == 4
                           orderby co.CreationDateTime ascending
                           select new
                           {
                               DownReportId = co.DownReportId,
                               MlsDivisionId = co.MlsDivisionId,
                               CreationDateTime = co.CreationDateTime,
                               CustomerPn = co.CustomerPn,
                               CustomerPo = co.CustomerPo,
                               QtyNeeded = co.QtyNeeded,
                               MlsWo = co.MlsWo,
                               EstArrivalDateTime = co.EstArrivalDateTime,
                               DownStatusId = co.DownStatusId,
                               Reason = co.Reason,
                               Notes = co.Notes
                           };
            List<OpenDownViewModel> result = new List<OpenDownViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenDownViewModel
                {
                    DownReportId = order.DownReportId,
                    MlsDivisionId = order.MlsDivisionId,
                    CreationDateTime = order.CreationDateTime,
                    CustomerPn = order.CustomerPn,
                    CustomerPo = order.CustomerPo,
                    QtyNeeded = order.QtyNeeded,
                    MlsWo = order.MlsWo,
                    EstArrivalDateTime = order.EstArrivalDateTime,
                    DownStatusId = order.DownStatusId,
                    Reason = order.Reason,
                    Notes = order.Notes
                });
            }

            return View("Closed", result);
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
