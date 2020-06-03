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
    public class PracticesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practices
        public ActionResult Index()
        {
            return View(db.Practices.ToList());
        }

        public ActionResult Download()
        {
            return View(db.Practices.ToList());
        }

        public ActionResult UploadPic()
        {
            return View("Upload2");
        }

        public ActionResult Upload2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View("SaveData", practice);
        }

        [HttpPost]
        public ActionResult Upload2(Practice item)
        {

            var currentUrl = item.PicUrl;
            
            if (item.Name != null && item.UploadImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.UploadImage.FileName);
                string extension = Path.GetExtension(item.UploadImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.PicUrl = fileName;
                item.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/images/currentUrl"), fileName));
                db.Practices.Add(item);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return View("Download", Json(result, JsonRequestBehavior.AllowGet));
        }

        public ActionResult Upload()
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/images/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                }
            }
            return View("Upload");
        }

        [HttpGetAttribute]
        public ActionResult Download1 (int Id)
        {
            var filename = db.Practices.First(x => x.PracticeId == Id).PicUrl;
            string path = AppDomain.CurrentDomain.BaseDirectory + "/images/";
            var attachfilepath = Path.Combine(path, filename);
            var contenttype = MimeMapping.GetMimeMapping(attachfilepath);
            var cd = new ContentDisposition { FileName = attachfilepath, Inline = false };
            Response.AppendHeader("Content-Disposition", cd.ToString());
            var attachment = System.IO.File.ReadAllBytes(attachfilepath);
            return File(attachment, contenttype);
        }

        [HttpPost]
        public ActionResult SaveData(Practice item)
        {

            if (item.Name != null && item.UploadImage != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.UploadImage.FileName);
                string extension = Path.GetExtension(item.UploadImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                item.PicUrl = fileName;
                item.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/images"), fileName));
                db.Practices.Add(item);
                db.SaveChanges();
            }
            var result = "Successfully Added";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Practices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // GET: Practices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Practices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PracticeId,Name,Price,PicUrl")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                db.Practices.Add(practice);
                db.SaveChanges();
                return RedirectToAction("Download");
            }

            return View(practice);
        }

        // GET: Practices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PracticeId,Name,Price,PicUrl")] Practice practice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Downlaod");
            }
            return View(practice);
        }

        // GET: Practices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Practice practice = db.Practices.Find(id);
            db.Practices.Remove(practice);
            db.SaveChanges();
            return RedirectToAction("Download");
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
