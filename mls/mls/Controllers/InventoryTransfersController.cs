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
    public class InventoryTransfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InventoryTransfers
        public ActionResult Index()
        {
            return View(db.InventoryTransfers.ToList().OrderByDescending(a=>a.TransferDateTime));
        }

        // GET: InventoryTransfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransfer inventoryTransfer = db.InventoryTransfers.Find(id);
            if (inventoryTransfer == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTransfer);
        }

        public ActionResult IncomingTransfers()
        {
            var query = from inv in db.InventoryTransfers
                        where inv.FinishInvLocationId == 6
                        select inv;

            return View("~/Views/InventoryTransfers/VtIncTransfers.cshtml", query);

        }

        public ActionResult OutgoingTransfers()
        {
            var query = from inv in db.InventoryTransfers
                        where inv.InvLocationId == 6
                        select inv;

            return View("~/Views/InventoryTransfers/VtOutTransfers.cshtml", query);

        }

        // GET: InventoryTransfers/Create
        public ActionResult Create()
        {

            ViewBag.ReturnUrl = Request.UrlReferrer;
            var invLocation = db.InvLocation.ToList();
            var finishInvLocation = db.FinishInvLocation.ToList();

            var viewModel = new InventoryTransferViewModel()
            {
                InvLocations = invLocation,
                FinishInvLocations = finishInvLocation
            };

            //return View();

            return View("Create", viewModel);
        }

        // POST: InventoryTransfers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "InventoryTransferId,TransferDateTime,InvLocationId,FinishInvLocationId,CustomerPn,PartDescription,TransferFromQty,TransferToQty,Carrier,TrackingInfo,ShipToAddress,Notes")] InventoryTransfer inventoryTransfer)
        public ActionResult Create(InventoryTransfer inventoryTransfer)
        {
            if (ModelState.IsValid)
            {

                List<FileInvDetail> fileInvDetails = new List<FileInvDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileInvDetail fileInvDetail = new FileInvDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileInvDetails.Add(fileInvDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileInvDetail.Id + fileInvDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                inventoryTransfer.FileInvDetails = fileInvDetails;
                db.InventoryTransfers.Add(inventoryTransfer);
                db.SaveChanges();
                //return Redirect(returnUrl);
                return RedirectToAction("Index");
            }
            return View();
            //return View(inventoryTransfer);
        }

        // GET: InventoryTransfers/Edit/5
        public ActionResult Edit(int? id)
        {
            //ViewBag.ReturnUrl = Request.UrlReferrer;
            var invtransfer = db.InventoryTransfers.SingleOrDefault(c => c.InventoryTransferId == id);

            var invLocation = db.InvLocation.ToList();
            var finishInvLocation = db.FinishInvLocation.ToList();

            var viewModel = new InventoryTransferViewModel()
            {
                InventoryTransfer = invtransfer,
                InvLocations = invLocation,
                FinishInvLocations = finishInvLocation
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //InventoryTransfer inventoryTransfer = db.InventoryTransfers.Find(id);
            InventoryTransfer inventoryTransfer = db.InventoryTransfers.Include(s => s.FileInvDetails).SingleOrDefault(x => x.InventoryTransferId == id);
            if (inventoryTransfer == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(inventoryTransfer);
        }

        // POST: InventoryTransfers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "InventoryTransferId,TransferDateTime,InvLocationId,FinishInvLocationId,CustomerPn,PartDescription,TransferFromQty,TransferToQty,Carrier,TrackingInfo,ShipToAddress,Notes")] InventoryTransfer inventoryTransfer)
        public ActionResult Edit(InventoryTransfer inventoryTransfer)
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
                        FileInvDetail fileInvDetail = new FileInvDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            InventoryTransferId = inventoryTransfer.InventoryTransferId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileInvDetail.Id + fileInvDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileInvDetail).State = EntityState.Added;
                    }
                }

                db.Entry(inventoryTransfer).State = EntityState.Modified;
                db.SaveChanges();
                //return Redirect(returnUrl);
                return RedirectToAction("Index");
            }
            return View();
            //return View(inventoryTransfer);
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
                FileInvDetail fileInvDetail = db.FileInvDetails.Find(guid);
                if (fileInvDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileInvDetails.Remove(fileInvDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileInvDetail.Id + fileInvDetail.Extension);
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
                InventoryTransfer inventoryTransfer = db.InventoryTransfers.Find(id);
                if (inventoryTransfer == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in inventoryTransfer.FileInvDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.InventoryTransfers.Remove(inventoryTransfer);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        
        // GET: InventoryTransfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryTransfer inventoryTransfer = db.InventoryTransfers.Find(id);
            if (inventoryTransfer == null)
            {
                return HttpNotFound();
            }
            return View(inventoryTransfer);
        }

        // POST: InventoryTransfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryTransfer inventoryTransfer = db.InventoryTransfers.Find(id);
            db.InventoryTransfers.Remove(inventoryTransfer);
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
