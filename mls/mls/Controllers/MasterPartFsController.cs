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
    public class MasterPartFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MasterPartFs
        public ActionResult Index()
        {
            var query = from c in db.MasterPartFs
                        where c.DocStatusId == 2
                        select c;
            return View("Index", query.ToList());
            //return View(db.MasterPartFs.ToList());
        }

        public ActionResult PendingParts()
        {
            var query = from c in db.MasterPartFs
                        where c.DocStatusId == 1
                        select c;
            return View("Index", query.ToList());
        }

        // GET: MasterDocs
        public ActionResult ActiveParts()
        {

            var query = from c in db.MasterPartFs
                        where c.DocStatusId == 2
                        select c;
            return View("Index", query.ToList());

        }

        // GET: MasterDocs
        public ActionResult ArchivedParts()
        {
            var query = from c in db.MasterPartFs
                        where c.DocStatusId == 3
                        select c;
            return View("Index", query.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult UHMasterPartF()
        {
            var query = from mp in db.MasterPartFs
                        where mp.MlsDivisionId == 1
                        select mp;
            return View("Index", query.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DipMasterPartF()
        {
            var query = from mp in db.MasterPartFs
                        where mp.MlsDivisionId == 4
                        select mp;
            return View("Index", query.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DopMasterPartF()
        {
            var query = from mp in db.MasterPartFs
                        where mp.MlsDivisionId == 5
                        select mp;
            return View("Index", query.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult CLMasterPartF()
        {
            var query = from mp in db.MasterPartFs
                        where mp.MlsDivisionId == 3
                        select mp;
            return View("Index", query.ToList());
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DttMasterPartF()
        {
            var query = from mp in db.MasterPartFs
                        where mp.MlsDivisionId == 2
                        select mp;
            return View("Index", query.ToList());
        }

        // GET: MasterPartFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartF masterPartF = db.MasterPartFs.Find(id);
            if (masterPartF == null)
            {
                return HttpNotFound();
            }
            return View(masterPartF);
        }

        // GET: MasterPartFs/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();
            var statuses = db.DocStatuses.ToList();

            var viewModel = new SaveMasterPartFViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts,
                DocStatuses = statuses

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: MasterPartFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "MasterPartFId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartTypeId,DocStatusId,CustomerPn,MlsPn,PartDescription,Weight,HtsCode,Notes")] MasterPartF masterPartF)
        public ActionResult Create(MasterPartF masterPartF)
        {
            if (ModelState.IsValid)
            {
                List<FileMasterPartF> fileMasterPartFs = new List<FileMasterPartF>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileMasterPartF fileMasterPartF = new FileMasterPartF()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileMasterPartFs.Add(fileMasterPartF);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileMasterPartF.Id + fileMasterPartF.Extension);
                        file.SaveAs(path);
                    }
                }

                masterPartF.FileMasterPartFs = fileMasterPartFs;
                db.MasterPartFs.Add(masterPartF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(masterPartF);
        }

        // GET: MasterPartFs/Edit/5
        public ActionResult Edit(int? id)
        {

            var masterparts = db.MasterPartFs.SingleOrDefault(c => c.MasterPartFId == id);

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();
            var statuses = db.DocStatuses.ToList();

            var viewModel = new SaveMasterPartFViewModel()
            {
                MasterPartF = masterparts,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts,
                DocStatuses = statuses

            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartF masterPartF = db.MasterPartFs.Include(s => s.FileMasterPartFs).SingleOrDefault(x => x.MasterPartFId == id);
            //MasterPartF masterPartF = db.MasterPartFs.Find(id);
            if (masterPartF == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(masterPartF);
        }

        // POST: MasterPartFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "MasterPartFId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartTypeId,DocStatusId,CustomerPn,MlsPn,PartDescription,Weight,HtsCode,Notes")] MasterPartF masterPartF)
        public ActionResult Edit(MasterPartF masterPartF)
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
                        FileMasterPartF fileMasterPartF = new FileMasterPartF()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            MasterPartFId = masterPartF.MasterPartFId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileMasterPartF.Id + fileMasterPartF.Extension);
                        file.SaveAs(path);

                        db.Entry(fileMasterPartF).State = EntityState.Added;
                    }
                }

                db.Entry(masterPartF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            //return View(masterPartF);
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
                FileMasterPartF fileMasterPartF = db.FileMasterPartFs.Find(guid);
                if (fileMasterPartF == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileMasterPartFs.Remove(fileMasterPartF);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileMasterPartF.Id + fileMasterPartF.Extension);
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
                MasterPartF masterPartF = db.MasterPartFs.Find(id);
                if (masterPartF == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in masterPartF.FileMasterPartFs)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.MasterPartFs.Remove(masterPartF);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /*
        // GET: MasterPartFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartF masterPartF = db.MasterPartFs.Find(id);
            if (masterPartF == null)
            {
                return HttpNotFound();
            }
            return View(masterPartF);
        }

        // POST: MasterPartFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterPartF masterPartF = db.MasterPartFs.Find(id);
            db.MasterPartFs.Remove(masterPartF);
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
