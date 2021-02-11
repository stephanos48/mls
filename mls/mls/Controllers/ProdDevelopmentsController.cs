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
    public class ProdDevelopmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdDevelopments
        public ActionResult Index()
        {
            return View(db.ProdDevelopments.ToList());
        }

        public ActionResult Queue()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 1 
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult Received()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 2
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult RDesign()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 3
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult Quote()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 4
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult Po()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 5
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult FDesign()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 6
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult SignOff()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 7
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult Proto()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 8
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult LTest()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 9
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult CTest()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 10
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult FTrial()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 11
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        public ActionResult Approved()
        {
            var query = from a in db.ProdDevelopments
                        where a.ProdDevelopStatusId == 12
                        orderby a.ReceiptDateTime ascending
                        select a;
            return View("Index", query);
        }

        // GET: ProdDevelopments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdDevelopment prodDevelopment = db.ProdDevelopments.Find(id);
            if (prodDevelopment == null)
            {
                return HttpNotFound();
            }
            return View(prodDevelopment);
        }

        // GET: ProdDevelopments/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var statuses = db.ProdDevelopStatuses.ToList();
            var customers = db.Customers.ToList();

            var viewModel = new SaveProdDevelopmentViewModel()
            {
                Customers = customers,
                ProdDevelopStatuses = statuses
            };

            return View("Create", viewModel);
        }

        // POST: ProdDevelopments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ProdDevelopmentId,CustomerId,ReverseLocation,ReceiptDateTime,IncCarrier,IncTrackingInfo,CustomerPn,UhPn,PartDescription,SerialNo,ReceiptQty,ProdDevelopStatusId,ShipDateTime,ShipCarrier,ShipTrackingInfo,ShipToLocation,RoughDesignBomCompletionDateTime,QuoteCompletionDateTime,CustomerPoDateTime,FinalDesignCompletionDateTime,CustomerSignOffDateTime,PrototypeCompletionDateTime,LabTestCompletionDateTime,CustomerTestCompletionDateTime,FieldTrialCompletionDateTime,ApprovedForProductionDateTime,Notes")] ProdDevelopment prodDevelopment)
        public ActionResult Create(ProdDevelopment prodDevelopment, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                List<FileProdDevelop> fileProdDevelops = new List<FileProdDevelop>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileProdDevelop fileProdDevelop = new FileProdDevelop()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileProdDevelops.Add(fileProdDevelop);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileProdDevelop.Id + fileProdDevelop.Extension);
                        file.SaveAs(path);
                    }
                }

                prodDevelopment.FileProdDevelops = fileProdDevelops;
                db.ProdDevelopments.Add(prodDevelopment);
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ProdDevelopments/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var proddevelops = db.ProdDevelopments.SingleOrDefault(c => c.ProdDevelopmentId == id);

            var statuses = db.ProdDevelopStatuses.ToList();
            var customers = db.Customers.ToList();

            var viewModel = new SaveProdDevelopmentViewModel()
            {
                ProdDevelopment = proddevelops,
                Customers = customers,
                ProdDevelopStatuses = statuses,
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ProdDevelopment prodDevelopment = db.ProdDevelopments.Find(id);
            ProdDevelopment prodDevelopment = db.ProdDevelopments.Include(s => s.FileProdDevelops).SingleOrDefault(x => x.ProdDevelopmentId == id);
            if (prodDevelopment == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(prodDevelopment);
        }

        // POST: ProdDevelopments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ProdDevelopmentId,CustomerId,ReverseLocation,ReceiptDateTime,IncCarrier,IncTrackingInfo,CustomerPn,UhPn,PartDescription,SerialNo,ReceiptQty,ProdDevelopStatusId,ShipDateTime,ShipCarrier,ShipTrackingInfo,ShipToLocation,RoughDesignBomCompletionDateTime,QuoteCompletionDateTime,CustomerPoDateTime,FinalDesignCompletionDateTime,CustomerSignOffDateTime,PrototypeCompletionDateTime,LabTestCompletionDateTime,CustomerTestCompletionDateTime,FieldTrialCompletionDateTime,ApprovedForProductionDateTime,Notes")] ProdDevelopment prodDevelopment)
        public ActionResult Edit(ProdDevelopment prodDevelopment, string returnUrl)
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
                        FileProdDevelop fileProdDevelop = new FileProdDevelop()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            ProdDevelopmentId = prodDevelopment.ProdDevelopmentId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileProdDevelop.Id + fileProdDevelop.Extension);
                        file.SaveAs(path);

                        db.Entry(fileProdDevelop).State = EntityState.Added;
                    }
                }

                db.Entry(prodDevelopment).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
                //return RedirectToAction("Index");
            }
            return View();
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
                FileProdDevelop fileProdDevelop = db.FileProdDevelops.Find(guid);
                if (fileProdDevelop == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileProdDevelops.Remove(fileProdDevelop);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileProdDevelop.Id + fileProdDevelop.Extension);
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

        // GET: ProdDevelopments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdDevelopment prodDevelopment = db.ProdDevelopments.Find(id);
            if (prodDevelopment == null)
            {
                return HttpNotFound();
            }
            return View(prodDevelopment);
        }

        // POST: ProdDevelopments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdDevelopment prodDevelopment = db.ProdDevelopments.Find(id);
            db.ProdDevelopments.Remove(prodDevelopment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
