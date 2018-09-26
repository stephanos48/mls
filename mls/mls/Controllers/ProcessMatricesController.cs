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
using System.Net.Mime;

namespace mls.Controllers
{
    public class ProcessMatricesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProcessMatrices
        public ActionResult Index()
        {
            return View(db.ProcessMatrixes.ToList());
        }

        // GET: ProcessMatrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMatrix processMatrix = db.ProcessMatrixes.Find(id);
            if (processMatrix == null)
            {
                return HttpNotFound();
            }
            return View(processMatrix);
        }

        // GET: ProcessMatrices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcessMatrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProcessMatrixId,ProcessStatusId,DocumentNo,DocumentTitle,RevLevel,SecuredStoreLocation,ProtectionMethod,RetentionPeriod,ControlledBy,ElectronicDistribution,DistributionMethod,RecordStorageLocation,RecordDispostionMethod,DocumentOwner,Notes,PicUrl")] ProcessMatrix processMatrix)
        {
            if (ModelState.IsValid)
            {
                db.ProcessMatrixes.Add(processMatrix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processMatrix);
        }

        // GET: ProcessMatrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMatrix processMatrix = db.ProcessMatrixes.Find(id);
            if (processMatrix == null)
            {
                return HttpNotFound();
            }
            return View(processMatrix);
        }

        // POST: ProcessMatrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProcessMatrixId,ProcessStatusId,DocumentNo,DocumentTitle,RevLevel,SecuredStoreLocation,ProtectionMethod,RetentionPeriod,ControlledBy,ElectronicDistribution,DistributionMethod,RecordStorageLocation,RecordDispostionMethod,DocumentOwner,Notes,PicUrl")] ProcessMatrix processMatrix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processMatrix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processMatrix);
        }

        // GET: ProcessMatrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessMatrix processMatrix = db.ProcessMatrixes.Find(id);
            if (processMatrix == null)
            {
                return HttpNotFound();
            }
            return View(processMatrix);
        }

        // POST: ProcessMatrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessMatrix processMatrix = db.ProcessMatrixes.Find(id);
            db.ProcessMatrixes.Remove(processMatrix);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGetAttribute]
        public ActionResult Download1(int Id)
        {
            var filename = db.ProcessMatrixes.First(x => x.ProcessMatrixId == Id).PicUrl;
            string path = AppDomain.CurrentDomain.BaseDirectory + "/images/";
            var attachfilepath = Path.Combine(path, filename);
            var contenttype = MimeMapping.GetMimeMapping(attachfilepath);
            var cd = new ContentDisposition { FileName = attachfilepath, Inline = false };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            var attachment = System.IO.File.ReadAllBytes(attachfilepath);
            return File(attachment, contenttype);
        }

        [HttpPost]
        public ActionResult SaveData(ProcessMatrix item)
        {

            if (item.ProcessStatus != null && item.DocumentNo != null && item.UploadImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.UploadImage.FileName);
                string extension = Path.GetExtension(item.UploadImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.PicUrl = fileName;
                item.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/images"), fileName));
                db.ProcessMatrixes.Add(item);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);
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
