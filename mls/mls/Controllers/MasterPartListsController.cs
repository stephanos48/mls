using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using mls.Models;
using mls.ViewModels;
using System.Dynamic;
using System.IO;

namespace mls.Controllers
{
    [Authorize]
    public class MasterPartListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin, InvPower")]
        // GET: MasterPartLists
        public ActionResult Index()
        {
            var query = db.MasterPartLists.ToList();
            return View("~/Views/MasterPartLists/Index.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult UHMasterPartList()
        {
            var query = from mp in db.MasterPartLists
                        where mp.MlsDivisionId == 1
                        select mp;
            return View("~/Views/MasterPartLists/UHMasterPartList.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DipMasterPartList()
        {
            var query = from mp in db.MasterPartLists
                        where mp.MlsDivisionId == 4
                        select mp;
            return View("~/Views/MasterPartLists/DipMasterPartList.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DopMasterPartList()
        {
            var query = from mp in db.MasterPartLists
                        where mp.MlsDivisionId == 5
                        select mp;
            return View("~/Views/MasterPartLists/DopMasterPartList.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult CLMasterPartList()
        {
            var query = from mp in db.MasterPartLists
                        where mp.MlsDivisionId == 3
                        select mp;
            return View("~/Views/MasterPartLists/CLMasterPartList.cshtml", query);
        }

        [Authorize(Roles = "Admin, InvPower")]
        public ActionResult DttMasterPartList()
        {
            var query = from mp in db.MasterPartLists
                        where mp.MlsDivisionId == 2
                        select mp;
            return View("~/Views/MasterPartLists/DttMasterPartList.cshtml", query);
        }

        // GET: Locations
        /*public ActionResult Locations()
        {
            var query = from a in db.MasterPartLists
                //join tx in TxQohs on a.CustomerPn equals tx.Pn
                orderby a.CustomerPn descending
                select a;
            return View("~/Views/MasterPartLists/Locations.cshtml", query);
        }*/


        public ActionResult Locations()
        {
            //LocationViewModel1 mymodel = new LocationsViewModel1();

            var startDate = DateTime.Parse("5/11/2020");
            var query = from a in db.MasterPartLists
                        join tx in db.TxQohs on a.CustomerPn equals tx.Pn
                        //join tx in db.TxQohs on a.CustomerPn equals tx.Pn
                        join r in db.PoPlans.Where(a => a.ReceiptDateTime >= startDate).Where(y => y.PoOrderStatusId == 5) on tx.Pn equals r.CustomerPn into g
                        join s in db.ShipPlanFs.Where(u => u.ShipDateTime >= startDate).Where(z => z.ShipPlanStatusId == 5) on tx.Pn equals s.CustomerPn into gr
                        join j in db.WoBuilds.Where(u => u.WoEnterDateTime >= startDate) on tx.Pn equals j.CustomerPn into sr
                        join c in db.CycleCounts.Where(u => u.CycleCountDateTime >= startDate) on tx.Pn equals c.CustomerPn into cr
                        join n in db.NCRs.Where(u => u.StatusId != 2) on tx.Pn equals n.PartNumber into nr
                        orderby a.CustomerPn descending
                        select new
                        {
                            a.CustomerPn,
                            a.PartDescription,
                            a.Location,
                            Qoh = tx.Qoh + (int?)g.Select(x => x.ReceivedQty).DefaultIfEmpty(0).Sum() - (int?)gr.Select(x => x.ShipQty).DefaultIfEmpty(0).Sum() + (int?)sr.Select(x => x.Qty).DefaultIfEmpty(0).Sum() + (int?)cr.Select(x => x.PortalAdjQty).DefaultIfEmpty(0).Sum(),
                        };
            //new LocationViewModel1
            //{
            //    a.CustomerPn, a.PartDescription, a.Location, tx.Qoh
            //            }
            
            List<LocationViewModel1> locations = new List<LocationViewModel1>();
            foreach (var loc in query.ToList())
            {
                LocationViewModel1 mymodel = new LocationViewModel1()
                {
                    Qoh = loc.Qoh,
                    Location = loc.Location,
                    CustomerPn = loc.CustomerPn,
                    PartDescription = loc.PartDescription
                };


                locations.Add(mymodel);
            }


            return View("~/Views/MasterPartLists/Locations.cshtml", locations);
        }

        // GET: MasterPartLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View(masterPartList);
        }

        // GET: MasterPartLists/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveMasterViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: MasterPartLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PartId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartType,CustomerPn,MlsPn,PartDescription,PartPrice,PartCost,Weight,StdPack,Notes")] MasterPartList masterPartList)
        public ActionResult Create(MasterPartList masterPartList, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /*List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/images/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }
                masterPartList.FileDetails = fileDetails;*/
                db.MasterPartLists.Add(masterPartList);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View();
            //return View(masterPartList);
        }

        // GET: MasterPartLists/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var masterpartlists = db.MasterPartLists.SingleOrDefault(c => c.PartId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var parttypes = db.PartTypes.ToList();
            var activeparts = db.ActiveParts.ToList();

            var viewModel = new SaveMasterViewModel()
            {
                MasterPartList = masterpartlists,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                PartTypes = parttypes,
                ActiveParts = activeparts
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Support support = db.Supports.Include(s => s.FileDetails).SingleOrDefault(x => x.SupportId == id);
            //MasterPartList masterPartList = db.MasterPartLists.Include(s => s.FileDetails).SingleOrDefault(x => x.PartId == id); 
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(masterPartList);
        }

        // POST: MasterPartLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PartId,CustomerId,CustomerDivisionId,MlsDivisionId,ActivePartId,PartType,CustomerPn,MlsPn,PartDescription,PartPrice,PartCost,Weight,StdPack,Notes")] MasterPartList masterPartList)
        public ActionResult Edit(MasterPartList masterPartList, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                //New Files
                /*for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            PartId = masterPartList.PartId
                        };
                        var path = Path.Combine(Server.MapPath("~/images/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }*/

                db.Entry(masterPartList).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(masterPartList);
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
                FileDetail fileDetail = db.FileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDetails.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/images/"), fileDetail.Id + fileDetail.Extension);
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

        // GET: MasterPartLists/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterPartList masterPartList = db.MasterPartLists.Find(id);
            if (masterPartList == null)
            {
                return HttpNotFound();
            }
            return View(masterPartList);
        }

        // POST: MasterPartLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            MasterPartList masterPartList = db.MasterPartLists.Find(id);

            //delete files from the file system
            /*
            foreach (var item in masterPartList.FileDetails)
            {
                String path = Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            */
            db.MasterPartLists.Remove(masterPartList);
            db.SaveChanges();
            return Redirect(returnUrl);
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
