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

namespace mls.Controllers
{
    public class CycleCountFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CycleCountFs
        public ActionResult Index()
        {
            return View(db.CycleCountFs.ToList().OrderByDescending(s => s.CycleCountDateTime));
        }

        // GET: CycleCountFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCountF cycleCountF = db.CycleCountFs.Find(id);
            if (cycleCountF == null)
            {
                return HttpNotFound();
            }
            return View(cycleCountF);
        }

        // GET: CycleCountFs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CycleCountFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CycleCountFId,CycleCountDateTime,CustomerPn,SageQty,PortalQty,ActualQty,SageAdjQty,PortalAdjQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,CorrectedDateTime,Notes")] CycleCountF cycleCountF)
        {
            if (ModelState.IsValid)
            {
                List<FileCycleCount> fileCycleCounts = new List<FileCycleCount>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileCycleCount fileCycleCount = new FileCycleCount()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileCycleCounts.Add(fileCycleCount);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileCycleCount.Id + fileCycleCount.Extension);
                        file.SaveAs(path);
                    }
                }

                cycleCountF.FileCycleCounts = fileCycleCounts;
                db.CycleCountFs.Add(cycleCountF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
            //return View(cycleCountF);
        }

        // GET: CycleCountFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCountF cycleCountF = db.CycleCountFs.Include(s => s.FileCycleCounts).SingleOrDefault(x => x.CycleCountFId == id);
            //CycleCountF cycleCountF = db.CycleCountFs.Find(id);
            if (cycleCountF == null)
            {
                return HttpNotFound();
            }
            return View(cycleCountF);
        }

        // POST: CycleCountFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CycleCountFId,CycleCountDateTime,CustomerPn,SageQty,PortalQty,ActualQty,SageAdjQty,PortalAdjQty,LocationsCounted,CountedBy,AuditedBy,CountOff,CorrectedBy,CorrectedDateTime,Notes")] CycleCountF cycleCountF)
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
                        FileCycleCount fileCycleCount = new FileCycleCount()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            CycleCountFId = cycleCountF.CycleCountFId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileCycleCount.Id + fileCycleCount.Extension);
                        file.SaveAs(path);

                        db.Entry(fileCycleCount).State = EntityState.Added;
                    }
                }


                db.Entry(cycleCountF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cycleCountF);
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
                FileCycleCount fileCycleCount = db.FileCycleCounts.Find(guid);
                if (fileCycleCount == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileCycleCounts.Remove(fileCycleCount);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileCycleCount.Id + fileCycleCount.Extension);
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
                CycleCountF cycleCountF = db.CycleCountFs.Find(id);
                if (cycleCountF == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in cycleCountF.FileCycleCounts)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.CycleCountFs.Remove(cycleCountF);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /*
        // GET: CycleCountFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CycleCountF cycleCountF = db.CycleCountFs.Find(id);
            if (cycleCountF == null)
            {
                return HttpNotFound();
            }
            return View(cycleCountF);
        }

        // POST: CycleCountFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CycleCountF cycleCountF = db.CycleCountFs.Find(id);
            db.CycleCountFs.Remove(cycleCountF);
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
