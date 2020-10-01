using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using mls.Models;
using mls.ViewModels;
using Newtonsoft.Json;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using Chart = System.Web.Helpers.Chart;

namespace mls.Controllers
{
    [Authorize]
    public class NCRsController : Controller
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
            int internalncr = db.NCRs.Where(x => x.NcrTypeId == 1).Count();
            int customer = db.NCRs.Where(x => x.NcrTypeId == 2).Count();
            int warranty = db.NCRs.Where(x => x.NcrTypeId == 3).Count();
            int supplier = db.NCRs.Where(x => x.NcrTypeId == 4).Count();
            int other = db.NCRs.Where(x => x.NcrTypeId == 5).Count();
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
            var ncrlist = (from ncr in db.NCRs
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

        // GET: NCRs
        public ActionResult Index()
        {
            var queryAllNcRs = from a in db.NCRs
                orderby a.NcrId descending
                select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                //return View("List", db.NCRs.ToList());
                return View("List", queryAllNcRs.ToList());
            else
                return View("ReadOnlyList", queryAllNcRs.ToList());

            //return View(db.NCRs.ToList());
        }

        public ActionResult Dibujo()
        {
            var queryHeilNcrs = (from c in db.NCRs
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

            var ncr = db.NCRs.ToList();

            var chartData = new object[ncr.Count + 1];
            chartData[0] = new object[]
            {
                "Date"
            };
            int j = 0;
            foreach (var i in ncr)
            {
                j++;
                chartData[j] = new object[] {i.IssueDateTime};
            }
            return new JsonResult {Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        /*public ActionResult DotNetGraph()
        {
            //var heil = (from c in db.NCRs
            //    where c.CustomerDivisionId == 1
            //    select c).Count();

            //var bayne = (from c in db.NCRs
            //    where c.CustomerDivisionId == 4
            //    select c).Count();

            var ncrs1 = (from c in db.NCRs
                where c.IssueDateTime >= 20170101 && c.
                select c).Count();

            Highcharts chart = new Highcharts("chart")
                .SetCredits(new Credits {Enabled = false})
                //.InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
                .SetTitle(new Title {Text = "2017 NCRs by Month"})
                .SetXAxis(new XAxis
                {
                    Categories = new[] {"Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug"}
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Title = new YAxisTitle {Text = "Quantity"}
                })
                .SetTooltip(new Tooltip {Formatter = "function() { return ''+  this.series.name +': '+ this.y +''; }"})
                .SetPlotOptions(new PlotOptions {Column = new PlotOptionsColumn {Stacking = Stackings.Normal}})
                .SetSeries(new[]
                {
                    new Series {Name = "Category", Data = new Data(new object[] {heil, bayne})}
                });


            return View(chart);
        }*/
 
        public ActionResult CharterColumn()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var results = (from a in db.NCRs select a);
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
                ViewBag.DataPoints = JsonConvert.SerializeObject(db.NCRs.ToList(), _jsonSetting);
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


        /*public ActionResult Data()
        {
            var queryNew = from a in db.NCRs
                           where a.MlsDivisionId == 1
                           orderby a.IssueDateTime descending
                           select a;
            List<GraphNcrViewModel> result = new List<GraphNcrViewModel>();
            foreach (var ncr in queryNew.ToList())
            {
                result.Add(new GraphNcrViewModel
                {
                    NcrId = ncr.NcrId,
                    Customer = ncr.Customer,
                    Quantity = ncr.Quantity

                });
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }*/

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

        // GET: NCRs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NCR nCR = db.NCRs.Find(id);
            if (nCR == null)
            {
                return HttpNotFound();
            }
            return View(nCR);
        }

        // GET: NCRs/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrViewModel()
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

        /// GET: NCR/Open
        public ActionResult Open()
        {
            var queryOpen = from a in db.NCRs
                              where a.StatusId == 1
                              orderby a.NcrId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Open", queryOpen.ToList());
            else
                return View("ROOpen", queryOpen.ToList());
        }

        /// GET: NCR/Open
        public ActionResult ROOpen()
        {
            var queryOpen = from a in db.NCRs
                            where a.StatusId == 1
                            orderby a.NcrId descending
                            select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Open", queryOpen.ToList());
            else
                return View("ROOpen", queryOpen.ToList());
        }

        /// GET: NCR/Closed
        public ActionResult Closed()
        {
            var queryClosed = from a in db.NCRs
                              where a.StatusId == 2
                              orderby a.NcrId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Closed", queryClosed.ToList());
            else
                return View("ROClosed", queryClosed.ToList());
        }

        // GET: NCR/Read Only Closed
        public ActionResult ROClosed()
        {
            var queryClosed = from a in db.NCRs
                              where a.StatusId == 2
                              orderby a.NcrId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Closed", queryClosed.ToList());
            else
                return View("ROClosed", queryClosed.ToList());
        }

        // GET: NCR/RTV
        public ActionResult RTV()
        {
            var queryRtv = from a in db.NCRs
                           where a.DispositionId == 2
                           && a.StatusId != 2
                           orderby a.NcrId descending
                           select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("RTV", queryRtv.ToList());
            else
                return View("RORTV", queryRtv.ToList());
        }

        // GET: NCR/Read Only RTV
        public ActionResult RORTV()
        {
            var queryRtv = from a in db.NCRs
                           where a.DispositionId == 2
                           && a.StatusId != 2
                           orderby a.NcrId descending
                           select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("RTV", queryRtv.ToList());
            else
                return View("RORTV", queryRtv.ToList());
        }

        // GET: NCR/Rework
        public ActionResult Rework()
        {
            var queryRework = from a in db.NCRs
                              where a.DispositionId == 4
                              && a.StatusId != 2
                              orderby a.NcrId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Rework", queryRework.ToList());
            else
                return View("RORework", queryRework.ToList());
        }

        // GET: NCR/Read Only Rework
        public ActionResult RORework()
        {
            var queryRework = from a in db.NCRs
                              where a.DispositionId == 4
                              && a.StatusId != 2
                              orderby a.NcrId descending
                              select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Rework", queryRework.ToList());
            else
                return View("RORework", queryRework.ToList());
        }

        // GET: NCR/Disposition
        public ActionResult Disposition()
        {
            var queryDisposition = from a in db.NCRs
                                   where a.DispositionId == 5
                                   orderby a.NcrId descending
                                   select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Disposition", queryDisposition.ToList());
            else
                return View("RODisposition", queryDisposition.ToList());
        }

        // GET: NCR/Read Only Disposition
        public ActionResult RODisposition()
        {
            var queryDisposition = from a in db.NCRs
                                   where a.DispositionId == 5
                                   orderby a.NcrId descending
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
            var queryScrap = from a in db.NCRs
                             where a.DispositionId == 1
                             && a.StatusId != 2
                             orderby a.NcrId descending
                             select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Scrap", queryScrap.ToList());
            else
                return View("ROScrap", queryScrap.ToList());
        }

        // GET: NCR/Read Only Scrap
        public ActionResult ROScrap()
        {
            var queryScrap = from a in db.NCRs
                             where a.DispositionId == 1
                             && a.StatusId != 2
                             orderby a.NcrId descending
                             select a;
            if (User.IsInRole("Admin") || User.IsInRole("QualityAdmin"))
                return View("Scrap", queryScrap.ToList());
            else
                return View("ROScrap", queryScrap.ToList());
        }

        // POST: NCRs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "NcrId,NcrNumber,IssueDateTime,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus")] NCR nCR)
        public ActionResult Create(NCR nCR)
        {
            if (ModelState.IsValid)
            {
                db.NCRs.Add(nCR);
                db.SaveChanges();
                return RedirectToAction("Index", nCR);
            }

            return View();
        }

        // GET: NCRs/Edit/5
        public ActionResult Edit(int? id)
        {
            var ncrs = db.NCRs.SingleOrDefault(c => c.NcrId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var dispositions = db.Dispositions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var statuses = db.Statuses.ToList();
            var ncrtypes = db.NcrTypes.ToList();

            var viewModel = new SaveNcrViewModel()
            {
                Ncr = ncrs,
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
            NCR nCR = db.NCRs.Find(id);
            if (nCR == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
        }

        // POST: NCRs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "NcrId,NcrNumber,IssueDateTime,CustomerId,CustomerDivisionId,PartSupplier,PartNumber,PartDescription,SerialNumber,PartCost,Quantity,DefectDescription,DefectCode,MlsDivisionId,DispositionId,DispositionDateTime,DispositionedBy,StatusId,ReworkNumber,ReworkCompletedBy,ReworkHrs,ReworkPartsUsed,ReworkPartsScrapped,ReworkQty,ReworkStatus,ReworkNotes,ScrapNumber,ScrapQty,ScrapApprovedBy,ScrapApprovalDate,ScrappedBy,ScrapDate,ScrapNotes,ScrapStatus,RtvNumber,ShipperNumber,RgNumber,ShipDate,Carrier,TrackingInfo,ShipTo,RtvNotes,RtvStatus")] NCR nCR)
        public ActionResult Edit(NCR nCR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nCR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", nCR);
            }
            return View(nCR);
        }

        // GET: NCRs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NCR nCR = db.NCRs.Find(id);
            if (nCR == null)
            {
                return HttpNotFound();
            }
            return View(nCR);
        }

        // POST: NCRs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NCR nCR = db.NCRs.Find(id);
            db.NCRs.Remove(nCR);
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
