using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using System.IO;
using mls.ViewModels;

namespace mls.Controllers
{
    public class CheckRequestFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckRequestFs
        public ActionResult Index()
        {
            var query = from a in db.CheckRequestFs
                        where a.CheckStatusId != 5 || a.CheckStatusId != 6
                        orderby a.CheckRequestFId descending
                        select a;
            return View("Index", query);
            //return View(await db.CheckRequestFs.ToListAsync());
        }

        public ActionResult Closed()
        {
            var query = from a in db.CheckRequestFs
                        where a.CheckStatusId == 5
                        orderby a.CheckRequestFId descending
                        select a;
            return View("Closed", query);
            //return View(await db.CheckRequests.ToListAsync());
        }

        public ActionResult Denied()
        {
            var query = from a in db.CheckRequestFs
                        where a.CheckStatusId == 6
                        orderby a.CheckRequestFId descending
                        select a;
            return View("Closed", query);
            //return View(await db.CheckRequests.ToListAsync());
        }

        public ActionResult Tiered()
        {
            return View("TieredView");
            //return View(await db.CheckRequests.ToListAsync());
        }

        // GET: CheckRequestFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequestF checkRequestF = db.CheckRequestFs.Find(id);
            if (checkRequestF == null)
            {
                return HttpNotFound();
            }
            return View(checkRequestF);
        }

        // GET: CheckRequestFs/Create
        public ActionResult Create()
        {

            var checkstatuses = db.CheckStatuses.ToList();

            var viewModel = new SaveCheckRequestFViewModel()
            {
                CheckStatuses = checkstatuses
            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: CheckRequestFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CheckRequestFId,MlsCo,CheckStatusId,PurchaseOrderNumber,PartNumber,PartDescription,CheckNo,Amount,Customer,Supplier,RequestDateTime,MailDateTime,ActualMailDateTime,ShipMethod,TrackingInfo,Notes")] CheckRequestF checkRequestF)
        public ActionResult Create(CheckRequestF checkRequestF)
        {
            if (ModelState.IsValid)
            {

                List<FileCheckRequestFDetail> fileCheckRequestFDetails = new List<FileCheckRequestFDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileCheckRequestFDetail fileCheckRequestFDetail = new FileCheckRequestFDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileCheckRequestFDetails.Add(fileCheckRequestFDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileCheckRequestFDetail.Id + fileCheckRequestFDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                checkRequestF.FileCheckRequestFDetails = fileCheckRequestFDetails;
                db.CheckRequestFs.Add(checkRequestF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //return View(checkRequestF);
        }

        // GET: CheckRequestFs/Edit/5
        public ActionResult Edit(int? id)
        {

            var checkrequestFs = db.CheckRequestFs.SingleOrDefault(c => c.CheckRequestFId == id);

            var checkstatuses = db.CheckStatuses.ToList();

            var viewModel = new SaveCheckRequestFViewModel()
            {
                CheckRequestF = checkrequestFs,
                CheckStatuses = checkstatuses
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequestF checkRequestF = db.CheckRequestFs.Include(s => s.FileCheckRequestFDetails).SingleOrDefault(x => x.CheckRequestFId == id);
            //CheckRequestF checkRequestF = db.CheckRequestFs.Find(id);
            if (checkRequestF == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(checkRequestF);
        }

        // POST: CheckRequestFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CheckRequestFId,MlsCo,CheckStatusId,PurchaseOrderNumber,PartNumber,PartDescription,CheckNo,Amount,Customer,Supplier,RequestDateTime,MailDateTime,ActualMailDateTime,ShipMethod,TrackingInfo,Notes")] CheckRequestF checkRequestF)
        public ActionResult Edit(CheckRequestF checkRequestF)
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
                        FileCheckRequestFDetail fileCheckRequestFDetail = new FileCheckRequestFDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            CheckRequestFId = checkRequestF.CheckRequestFId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileCheckRequestFDetail.Id + fileCheckRequestFDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileCheckRequestFDetail).State = EntityState.Added;
                    }
                }

                db.Entry(checkRequestF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(checkRequestF);
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
                FileCheckRequestFDetail fileCheckRequestFDetail = db.FileCheckRequestFDetails.Find(guid);
                if (fileCheckRequestFDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileCheckRequestFDetails.Remove(fileCheckRequestFDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileCheckRequestFDetail.Id + fileCheckRequestFDetail.Extension);
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

        // GET: CheckRequestFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequestF checkRequestF = db.CheckRequestFs.Find(id);
            if (checkRequestF == null)
            {
                return HttpNotFound();
            }
            return View(checkRequestF);
        }

        // POST: CheckRequestFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckRequestF checkRequestF = db.CheckRequestFs.Find(id);
            db.CheckRequestFs.Remove(checkRequestF);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult _CheckRequest(int status)
        {
            var queryNew = from a in db.CheckRequestFs
                           where a.CheckStatusId == status
                           orderby a.RequestDateTime descending
                           select a;

            List<NewCheckRequestFViewModel> result = new List<NewCheckRequestFViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewCheckRequestFViewModel
                {
                    CheckRequestFId = order.CheckRequestFId,
                    MlsCo = order.MlsCo,
                    CheckStatusId = order.CheckStatusId,
                    PurchaseOrderNumber = order.PurchaseOrderNumber,
                    PartNumber = order.PartNumber,
                    PartDescription = order.PartDescription,
                    CheckNo = order.CheckNo,
                    Amount = order.Amount,
                    Customer = order.Customer,
                    Supplier = order.Supplier,
                    RequestDateTime = order.RequestDateTime,
                    MailDateTime = order.MailDateTime,
                    ActualMailDateTime = order.ActualMailDateTime,
                    ShipMethod = order.ShipMethod,
                    TrackingInfo = order.TrackingInfo,
                    Notes = order.Notes
                });
            }
            return PartialView("_CheckRequestPartialView", result);
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
