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
    [Authorize]
    public class MasterDocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MasterDocs
        public ActionResult Index()
        {
            return View(db.MasterDocs.ToList());
        }

        // GET: MasterDocs
        public ActionResult PendingDocs()
        {
            var query = from c in db.MasterDocs
                        where c.DocStatusId == 1
                        select c;
            return View("Index", query.ToList());
        }

        // GET: MasterDocs
        public ActionResult ActiveDocs()
        {

            var query = from c in db.MasterDocs
                        where c.DocStatusId == 2
                        select c;
            return View("Index", query.ToList());

        }

        // GET: MasterDocs
        public ActionResult ArchivedDocs()
        {
            var query = from c in db.MasterDocs
                        where c.DocStatusId == 3
                        select c;
            return View("Index", query.ToList());
        }

        // GET: MasterDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterDoc masterDoc = db.MasterDocs.Find(id);
            if (masterDoc == null)
            {
                return HttpNotFound();
            }
            return View(masterDoc);
        }

        // GET: MasterDocs/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.DocStatuses.ToList();

            var viewModel = new MasterDocViewModel()
            {
                DocStatuses = statuses,
            };

            //return View();

            return View("Create", viewModel);
        }

        // POST: MasterDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MasterDocId,DocStatusId,DocNo,DocTitle,DocOwner,RevLevel,SecuredLocation,ProtectionMethod,RetentionPeriod,LastReviewed,ReviewedBy,NextReview,ControlledBy,ElecDistribution,DistributionMethod,RecordStorageLocation,RecordDistributionMethod,AssociatedDocs,Notes")] MasterDoc masterDoc)
        public ActionResult Create (MasterDoc masterDoc)
        {
            if (ModelState.IsValid)
            {
                List<FileDocDetail> fileDocDetails = new List<FileDocDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDocDetail fileDocDetail = new FileDocDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDocDetails.Add(fileDocDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileDocDetail.Id + fileDocDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                masterDoc.FileDocDetails = fileDocDetails;
                db.MasterDocs.Add(masterDoc);
                db.SaveChanges();
                //return Redirect(returnUrl);
                return RedirectToAction("Index");
            }

            return View();
            //return View(masterDoc);
        }

        // GET: MasterDocs/Edit/5
        public ActionResult Edit(int? id)
        {

            //ViewBag.ReturnUrl = Request.UrlReferrer;
            var docs = db.MasterDocs.SingleOrDefault(c => c.MasterDocId == id);

            var statuses = db.DocStatuses.ToList();

            var viewModel = new MasterDocViewModel()
            {
                MasterDoc = docs,
                DocStatuses = statuses,
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //MasterDoc masterDoc = db.MasterDocs.Find(id);
            MasterDoc masterDoc = db.MasterDocs.Include(s => s.FileDocDetails).SingleOrDefault(x => x.MasterDocId == id);
            if (masterDoc == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(masterDoc);
        }

        // POST: MasterDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MasterDocId,DocStatusId,DocNo,DocTitle,DocOwner,RevLevel,SecuredLocation,ProtectionMethod,RetentionPeriod,LastReviewed,ReviewedBy,NextReview,ControlledBy,ElecDistribution,DistributionMethod,RecordStorageLocation,RecordDistributionMethod,AssociatedDocs,Notes")] MasterDoc masterDoc)
        public ActionResult Edit(MasterDoc masterDoc)
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
                        FileDocDetail fileDocDetail = new FileDocDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            MasterDocId = masterDoc.MasterDocId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileDocDetail.Id + fileDocDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDocDetail).State = EntityState.Added;
                    }
                }

                db.Entry(masterDoc).State = EntityState.Modified;
                db.SaveChanges();
                //return Redirect(returnUrl);
                return RedirectToAction("Index");
            }
            return View();
            //return View(masterDoc);
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
                FileDocDetail fileDocDetail = db.FileDocDetails.Find(guid);
                if (fileDocDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDocDetails.Remove(fileDocDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileDocDetail.Id + fileDocDetail.Extension);
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

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                MasterDoc masterDoc = db.MasterDocs.Find(id);
                if (masterDoc == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in masterDoc.FileDocDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.MasterDocs.Remove(masterDoc);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /*
        // GET: MasterDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterDoc masterDoc = db.MasterDocs.Find(id);
            if (masterDoc == null)
            {
                return HttpNotFound();
            }
            return View(masterDoc);
        }

        // POST: MasterDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterDoc masterDoc = db.MasterDocs.Find(id);
            db.MasterDocs.Remove(masterDoc);
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
