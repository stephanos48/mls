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
    [Authorize]
    public class BomTrackersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BomTrackers
        public ActionResult Index()
        {
            return View(db.BomTrackers.ToList());
        }

        public ActionResult New()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 1
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult PendingExcel()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 2
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult PendingSage()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 3
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult PendingPortal()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 4
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult Approved()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 5
                        select c;
            return View("Index", query.ToList());
        }

        public ActionResult Archived()
        {
            var query = from c in db.BomTrackers
                        where c.BomStatusId == 6
                        select c;
            return View("Index", query.ToList());
        }

        // GET: BomTrackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BomTracker bomTracker = db.BomTrackers.Find(id);
            if (bomTracker == null)
            {
                return HttpNotFound();
            }
            return View(bomTracker);
        }

        // GET: BomTrackers/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.BomStatuses.ToList();

            var viewModel = new SaveBomTrackerViewModel()
            {
                BomStatuses = statuses,
            };

            //return View();

            return View("Create", viewModel);
        }

        // POST: BomTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BomTrackerId,BomStatusId,BomPn,Description,RevLevel,BomCreatorExcel,DateCreatedExcel,BomCreatorSage,DateCreatedSage,BomCreatorPortal,DateCreatedPortal,ApprovedBy,DateApproved,Notes")] BomTracker bomTracker)
        public ActionResult Create(BomTracker bomTracker)
        {
            if (ModelState.IsValid)
            {
                List<FileBomDetail> fileBomDetails = new List<FileBomDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileBomDetail fileBomDetail = new FileBomDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileBomDetails.Add(fileBomDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileBomDetail.Id + fileBomDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                bomTracker.FileBomDetails = fileBomDetails;
                db.BomTrackers.Add(bomTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //return View(bomTracker);
        }

        // GET: BomTrackers/Edit/5
        public ActionResult Edit(int? id)
        {
            var boms = db.BomTrackers.SingleOrDefault(c => c.BomTrackerId == id);

            var statuses = db.BomStatuses.ToList();

            var viewModel = new SaveBomTrackerViewModel()
            {
                BomTracker = boms,
                BomStatuses = statuses,
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BomTracker bomTracker = db.BomTrackers.Find(id);
            BomTracker bomTracker = db.BomTrackers.Include(s => s.FileBomDetails).SingleOrDefault(x => x.BomTrackerId == id);
            if (bomTracker == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(bomTracker);
        }

        // POST: BomTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "BomTrackerId,BomStatusId,BomPn,Description,RevLevel,BomCreatorExcel,DateCreatedExcel,BomCreatorSage,DateCreatedSage,BomCreatorPortal,DateCreatedPortal,ApprovedBy,DateApproved,Notes")] BomTracker bomTracker)
        public ActionResult Edit(BomTracker bomTracker)
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
                        FileBomDetail fileBomDetail = new FileBomDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            BomTrackerId = bomTracker.BomTrackerId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileBomDetail.Id + fileBomDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileBomDetail).State = EntityState.Added;
                    }
                }

                db.Entry(bomTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(bomTracker);
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
                FileBomDetail fileBomDetail = db.FileBomDetails.Find(guid);
                if (fileBomDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileBomDetails.Remove(fileBomDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileBomDetail.Id + fileBomDetail.Extension);
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
                BomTracker bomTracker = db.BomTrackers.Find(id);
                if (bomTracker == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in bomTracker.FileBomDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.BomTrackers.Remove(bomTracker);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        /*
        // GET: BomTrackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BomTracker bomTracker = db.BomTrackers.Find(id);
            if (bomTracker == null)
            {
                return HttpNotFound();
            }
            return View(bomTracker);
        }

        // POST: BomTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BomTracker bomTracker = db.BomTrackers.Find(id);
            db.BomTrackers.Remove(bomTracker);
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
