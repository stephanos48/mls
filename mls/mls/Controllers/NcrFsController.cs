using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using Newtonsoft.Json;
using mls.ViewModels;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Collections;
using DocumentFormat.OpenXml.Drawing;
using System.Web.Helpers;
using Chart = System.Web.Helpers.Chart;

namespace mls.Controllers
{
    [Authorize]
    public class NcrFsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public ActionResult IncomingHome()
        {
            return View("");
        }

        public ActionResult graphpie()
        {
            return View();
        }

        public ActionResult getgraphdata()
        {
            int internalncr = db.NcrFs.Where(x => x.NcrTypeId == 1).Count();
            int customer = db.NcrFs.Where(x => x.NcrTypeId == 2).Count();
            int warranty = db.NcrFs.Where(x => x.NcrTypeId == 3).Count();
            int supplier = db.NcrFs.Where(x => x.NcrTypeId == 4).Count();
            int other = db.NcrFs.Where(x => x.NcrTypeId == 5).Count();
            Ratio obj = new Ratio();
            obj.internalncr = internalncr;
            obj.customer = customer;
            obj.warranty = warranty;
            obj.supplier = supplier;
            obj.other = other;

            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class Ratio
        {
            public int internalncr { get; set; }
            public int customer { get; set; }
            public int warranty { get; set; }
            public int supplier { get; set; }
            public int other { get; set; }
        }

        public IList<NcrViewModel> GetNcrList()
        {
            var ncrlist = (from ncr in db.NcrFs
                           select new NcrViewModel()).ToList();
            return ncrlist;
        }

        public ActionResult Export()
        {
            return View(this.GetNcrList());
        }

        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetNcrList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Export");
        }

        // GET: NcrFs
        public ActionResult Index()
        {

            var queryAllNcRs = from a in db.NcrFs
                               orderby a.NcrFId descending
                               select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                //return View("List", db.NCRs.ToList());
                return View("List", queryAllNcRs.ToList());
            else
                return View("ReadOnlyList", queryAllNcRs.ToList());
            //return View(db.NcrFs.ToList());
        }

        public ActionResult Dibujo()
        {
            var queryHeilNcrs = (from c in db.NcrFs
                                 where c.CustomerDivisionId == 1
                                 select c).Count();
            List<int> heilValues = new List<int>(queryHeilNcrs);
            //List<ColumnSeriesData> heilData = new List<ColumnSeriesData>();

            //heilValues.ForEach(p => heilData.Add(new ColumnSeriesData { Y = p }));

            //ViewData["heilData"] = heilData;

            return View();

        }

        public JsonResult Graph2()
        {

            var ncr = db.NcrFs.ToList();

            var chartData = new object[ncr.Count + 1];
            chartData[0] = new object[]
            {
                "Date"
            };
            int j = 0;
            foreach (var i in ncr)
            {
                j++;
                chartData[j] = new object[] { i.IssueDateTime };
            }
            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult CharterColumn()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = (from a in db.NcrFs select a);
            results.ToList().ForEach(rs => xValue.Add(rs.IssueDateTime));
            results.ToList().ForEach(rs => yValue.Add(rs.Quantity));

            new Chart(width: 600, height: 400, theme: ChartTheme.Green)
                .AddTitle("NCRs by Month [Column Chart]")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }

        public ActionResult Dashboard()
        {
            try
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(db.NcrFs.ToList(), _jsonSetting);
                return View();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
            /*var query = from a in db.NCRs
                orderby a.NcrId descending
                select a;

            return View(query.ToList());*/
        }

        public ActionResult QualityHome()
        {
            return View();
        }

        public ActionResult IsoHome()
        {
            return View();
        }

        public ActionResult IsoProcesses()
        {
            return View();
        }

        public ActionResult IsoForms()
        {
            return View();
        }

        // GET: NcrFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NcrF ncrF = db.NcrFs.Find(id);
            if (ncrF == null)
            {
                return HttpNotFound();
            }
            return View(ncrF);
        }

        public ActionResult Open()
        {
            var queryOpen = from a in db.NcrFs
                            where a.StatusId == 1
                            orderby a.NcrFId descending
                            select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Open", queryOpen.ToList());
            else
                return View("ROOpen", queryOpen.ToList());
        }

        /// GET: NCR/Open
        public ActionResult ROOpen()
        {
            var queryOpen = from a in db.NcrFs
                            where a.StatusId == 1
                            orderby a.NcrFId descending
                            select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Open", queryOpen.ToList());
            else
                return View("ROOpen", queryOpen.ToList());
        }

        /// GET: NCR/Closed
        public ActionResult Closed()
        {
            var queryClosed = from a in db.NcrFs
                              where a.StatusId == 2
                              orderby a.NcrFId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Closed", queryClosed.ToList());
            else
                return View("ROClosed", queryClosed.ToList());
        }

        // GET: NCR/Read Only Closed
        public ActionResult ROClosed()
        {
            var queryClosed = from a in db.NcrFs
                              where a.StatusId == 2
                              orderby a.NcrFId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Closed", queryClosed.ToList());
            else
                return View("ROClosed", queryClosed.ToList());
        }

        // GET: NCR/RTV
        public ActionResult RTV()
        {
            var queryRtv = from a in db.NcrFs
                           where a.DispositionId == 2
                           && a.StatusId != 2
                           orderby a.NcrFId descending
                           select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("RTV", queryRtv.ToList());
            else
                return View("RORTV", queryRtv.ToList());
        }

        // GET: NCR/Read Only RTV
        public ActionResult RORTV()
        {
            var queryRtv = from a in db.NcrFs
                           where a.DispositionId == 2
                           && a.StatusId != 2
                           orderby a.NcrFId descending
                           select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("RTV", queryRtv.ToList());
            else
                return View("RORTV", queryRtv.ToList());
        }

        // GET: NCR/Rework
        public ActionResult Rework()
        {
            var queryRework = from a in db.NcrFs
                              where a.DispositionId == 4
                              && a.StatusId != 2
                              orderby a.NcrFId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Rework", queryRework.ToList());
            else
                return View("RORework", queryRework.ToList());
        }

        // GET: NCR/Read Only Rework
        public ActionResult RORework()
        {
            var queryRework = from a in db.NcrFs
                              where a.DispositionId == 4
                              && a.StatusId != 2
                              orderby a.NcrFId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Rework", queryRework.ToList());
            else
                return View("RORework", queryRework.ToList());
        }

        // GET: NCR/Disposition
        public ActionResult Disposition()
        {
            var queryDisposition = from a in db.NcrFs
                                   where a.DispositionId == 5
                                   orderby a.NcrFId descending
                                   select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Disposition", queryDisposition.ToList());
            else
                return View("RODisposition", queryDisposition.ToList());
        }

        // GET: NCR/Read Only Disposition
        public ActionResult RODisposition()
        {
            var queryDisposition = from a in db.NcrFs
                                   where a.DispositionId == 5
                                   orderby a.NcrFId descending
                                   select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Disposition", queryDisposition.ToList());
            else
                return View("RODisposition", queryDisposition.ToList());
        }

        // GET: NCR/Scrap
        public ActionResult Scrap()
        {
            //string query = "SELECT NCR_Number FROM NCR WHERE Status = 'Scrap'";
            //IEnumerable<ScrapGroup> data = db.Database.SqlQuery<ScrapGroup>(query);
            //return View(data.ToList());
            var queryScrap = from a in db.NcrFs
                             where a.DispositionId == 1
                             && a.StatusId != 2
                             orderby a.NcrFId descending
                             select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Scrap", queryScrap.ToList());
            else
                return View("ROScrap", queryScrap.ToList());
        }

        // GET: NCR/Read Only Scrap
        public ActionResult ROScrap()
        {
            var queryScrap = from a in db.NcrFs
                             where a.DispositionId == 1
                             && a.StatusId != 2
                             orderby a.NcrFId descending
                             select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Scrap", queryScrap.ToList());
            else
                return View("ROScrap", queryScrap.ToList());
        }

        // GET: NcrFs/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrFViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                Dispositions = dispositions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                NcrTypes = ncrtypes

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: NcrFs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "NcrFId,NcrNumber,IssueDateTime,NcrTypeId,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus,ReworkCost,ScrapCost")] NcrF ncrF)
        public ActionResult Create(NcrF ncrF)
        {
            if (ModelState.IsValid)
            {
                List<FileNcrFDetail> fileNcrFDetails = new List<FileNcrFDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = System.IO.Path.GetFileName(file.FileName);
                        FileNcrFDetail fileNcrFDetail = new FileNcrFDetail()
                        {
                            FileName = fileName,
                            Extension = System.IO.Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileNcrFDetails.Add(fileNcrFDetail);

                        var path = System.IO.Path.Combine(Server.MapPath("~/images/"), fileNcrFDetail.Id + fileNcrFDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                ncrF.FileNcrFDetails = fileNcrFDetails;
                db.NcrFs.Add(ncrF);
                db.SaveChanges();
                return RedirectToAction("Index", ncrF);
            }
            return View();
            //return View(ncrF);
        }

        // GET: NcrFs/Edit/5
        public ActionResult Edit(int? id)
        {

            var ncrs = db.NcrFs.SingleOrDefault(c => c.NcrFId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrFViewModel()
            {
                NcrF = ncrs,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                Dispositions = dispositions,
                MlsDivisions = mlsdivisions,
                Statuses = statuses,
                NcrTypes = ncrtypes

            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //NcrF ncrF = db.NcrFs.Find(id);
            NcrF ncrF = db.NcrFs.Include(s => s.FileNcrFDetails).SingleOrDefault(x => x.NcrFId == id);
            if (ncrF == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(ncrF);
        }

        // POST: NcrFs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "NcrFId,NcrNumber,IssueDateTime,NcrTypeId,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus,ReworkCost,ScrapCost")] NcrF ncrF)
        public ActionResult Edit(NcrF ncrF)
        {
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = System.IO.Path.GetFileName(file.FileName);
                        FileNcrFDetail fileNcrFDetail = new FileNcrFDetail()
                        {
                            FileName = fileName,
                            Extension = System.IO.Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            NcrFId = ncrF.NcrFId
                        };
                        var path = System.IO.Path.Combine(Server.MapPath("~/images/"), fileNcrFDetail.Id + fileNcrFDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileNcrFDetail).State = EntityState.Added;
                    }
                }

                db.Entry(ncrF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", ncrF);
            }
            return View(ncrF);
        }

        public FileResult Download(String p, String d)
        {
            return File(System.IO.Path.Combine(Server.MapPath("~/images/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
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
                FileNcrFDetail fileNcrFDetail = db.FileNcrFDetails.Find(guid);
                if (fileNcrFDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileNcrFDetails.Remove(fileNcrFDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = System.IO.Path.Combine(Server.MapPath("~/images/"), fileNcrFDetail.Id + fileNcrFDetail.Extension);
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
                NcrF ncrF = db.NcrFs.Find(id);
                if (ncrF == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in ncrF.FileNcrFDetails)
                {
                    String path = System.IO.Path.Combine(Server.MapPath("~/images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.NcrFs.Remove(ncrF);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        /*
        // GET: NcrFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NcrF ncrF = db.NcrFs.Find(id);
            if (ncrF == null)
            {
                return HttpNotFound();
            }
            return View(ncrF);
        }

        // POST: NcrFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NcrF ncrF = db.NcrFs.Find(id);
            db.NcrFs.Remove(ncrF);
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
