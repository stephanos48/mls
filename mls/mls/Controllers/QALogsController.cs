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
using System.IO;

namespace mls.Controllers
{
    public class QALogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QALogs
        public ActionResult Index()
        {
            return View(db.QALogs.ToList());
        }

        public ActionResult Internal()
        {
            var query = from c in db.QALogs
                        where c.QATypeId == 1
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult Supplier()
        {
            var query = from c in db.QALogs
                        where c.QATypeId == 2
                        select c;
            return View("Index", query.ToList());
        }

        // GET: QALogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QALog qALog = db.QALogs.Find(id);
            if (qALog == null)
            {
                return HttpNotFound();
            }
            return View(qALog);
        }

        // GET: QALogs/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var qatype = db.QATypes.ToList();
            var parttypes = db.PartTypes.ToList();
            var problemfound = db.ProblemFounds.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveQALogViewModel()
            {
                QATypes = qatype,
                PartTypes = parttypes,
                ProblemFounds = problemfound,  
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                CQStatuses = cqstatuses
            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: QALogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "QALogId,QACreated,QANo,QATypeId,PartTypeId,MlsDivisionId,CustomerId,CustomerDivisionId,ProblemFoundId,CustomerPn,ProblemDescription,ContainmentChina,CleanPointChina,ContainmentUSA,CleanPointUsa,NCRNo,CQStatusId,CARNo,SupplierId,CustomerCARNo,MLSChampion,SupplierChampion,Notes")] QALog qALog)
        public ActionResult Create(QALog qALog, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                List<FileQALog> fileQALogs = new List<FileQALog>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileQALog fileQALog = new FileQALog()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileQALogs.Add(fileQALog);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileQALog.Id + fileQALog.Extension);
                        file.SaveAs(path);
                    }
                }

                qALog.FileQALogs = fileQALogs;
                db.QALogs.Add(qALog);
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }

            //return View(qALog);
            return View();
        }

        // GET: QALogs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var qALogs = db.QALogs.SingleOrDefault(c => c.QALogId == id);

            var qatype = db.QATypes.ToList();
            var parttypes = db.PartTypes.ToList();
            var problemfound = db.ProblemFounds.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatuses = db.CQStatuses.ToList();

            var viewModel = new SaveQALogViewModel()
            {
                QALog = qALogs,
                QATypes = qatype,
                PartTypes = parttypes,
                ProblemFounds = problemfound,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                CQStatuses = cqstatuses
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //QALog qALog = db.QALogs.Find(id);
            QALog qALog = db.QALogs.Include(s => s.FileQALogs).SingleOrDefault(x => x.QALogId == id);
            if (qALog == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(qALog);
        }

        // POST: QALogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "QALogId,QACreated,QANo,QATypeId,PartTypeId,MlsDivisionId,CustomerId,CustomerDivisionId,ProblemFoundId,CustomerPn,ProblemDescription,ContainmentChina,CleanPointChina,ContainmentUSA,CleanPointUsa,NCRNo,CQStatusId,CARNo,SupplierId,CustomerCARNo,MLSChampion,SupplierChampion,Notes")] QALog qALog)
        public ActionResult Edit(QALog qALog, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileQALog fileQALog = new FileQALog()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            QALogId = qALog.QALogId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileQALog.Id + fileQALog.Extension);
                        file.SaveAs(path);

                        db.Entry(fileQALog).State = EntityState.Added;
                    }
                }

                db.Entry(qALog).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
            //return View(qALog);
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/images/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileQALog fileQALog = db.FileQALogs.Find(guid);
                if (fileQALog == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileQALogs.Remove(fileQALog);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileQALog.Id + fileQALog.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /*
        // GET: QALogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QALog qALog = db.QALogs.Find(id);
            if (qALog == null)
            {
                return HttpNotFound();
            }
            return View(qALog);
        }

        // POST: QALogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QALog qALog = db.QALogs.Find(id);
            db.QALogs.Remove(qALog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
