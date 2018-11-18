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
using System.Linq.Expressions;

namespace mls.Controllers
{
    public class DemandsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Demands
        public ActionResult Index()
        {
            return View(db.Demands.ToList());
        }

        // GET: Demands
        public ActionResult ForecastHome()
        {
            return View();
        }

        // GET: Demands
        public ActionResult HeilForecast(int condition=0)
        {
            if(condition == 0)
                ViewBag.Message = "Forecast";
            else if(condition == 1)
                ViewBag.Message = "Demand";
            else if(condition == 2)
                ViewBag.Message = "Commits";

            ViewBag.Condition = condition;
            return View();
        }

        public ActionResult Hunter()
        {
            var query = from d in db.Demands
                        join cq in db.CustomerQohs on d.Pn equals cq.Pn
                        join tx in db.TxQohs on d.Pn equals tx.Pn
                        join sc in db.ShipCommits on d.Pn equals sc.Pn
                        join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                        join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                        where mp.CustomerId == 4 && mp.CustomerDivisionId == 7
                        select new
                        {

                            CustomerPn = mp.CustomerPn,
                            COH = cq.Qoh,
                            TOH = tx.Qoh,
                            Wk1 = (cq.Qoh + tx.Qoh - d.DemandWk30 + sc.ShipCommit30),
                            Wk2 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 + sc.ShipCommit30 + sc.ShipCommit31),
                            Wk3 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32),
                            Wk4 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33),
                            Wk5 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34),
                            Wk6 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35),
                            Wk7 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36),
                            Wk8 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37),
                            Wk9 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38),
                            Wk10 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39),
                            Wk11 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40),
                            Wk12 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 - d.DemandWk41 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40 + sc.ShipCommit41),

                        };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                };

                quantities.Add(mymodel);
            }

            return View("Hunter", quantities);

            //return View(db.Demands.ToList());
        }

        // GET: Demands
        public ActionResult VSG()
        {
            var query = from d in db.Demands
                        join cq in db.CustomerQohs on d.Pn equals cq.Pn
                        join tx in db.TxQohs on d.Pn equals tx.Pn
                        join sc in db.ShipCommits on d.Pn equals sc.Pn
                        join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                        join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                        where mp.CustomerId == 3 && mp.CustomerDivisionId == 8
                        select new
                        {

                            CustomerPn = mp.CustomerPn,
                            COH = cq.Qoh,
                            TOH = tx.Qoh,
                            Wk1 = (cq.Qoh + tx.Qoh - d.DemandWk30 + sc.ShipCommit30),
                            Wk2 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 + sc.ShipCommit30 + sc.ShipCommit31),
                            Wk3 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32),
                            Wk4 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33),
                            Wk5 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34),
                            Wk6 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35),
                            Wk7 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36),
                            Wk8 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37),
                            Wk9 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38),
                            Wk10 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39),
                            Wk11 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40),
                            Wk12 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 - d.DemandWk41 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40 + sc.ShipCommit41),

                        };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                };

                quantities.Add(mymodel);
            }

            return View("Heil", quantities);

            //return View(db.Demands.ToList());
        }

        // GET: Demands
        public ActionResult Heil()
        {
            var query = from d in db.Demands
                         join cq in db.CustomerQohs on d.Pn equals cq.Pn
                         join tx in db.TxQohs on d.Pn equals tx.Pn
                         join sc in db.ShipCommits on d.Pn equals sc.Pn
                         join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                         join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                         where mp.CustomerId == 1 && mp.CustomerDivisionId == 1
                         select new
                         {

                             CustomerPn = mp.CustomerPn,
                             COH = cq.Qoh,
                             TOH = tx.Qoh,
                             Wk1 = (cq.Qoh + tx.Qoh - d.DemandWk30 + sc.ShipCommit30),
                             Wk2 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 + sc.ShipCommit30 + sc.ShipCommit31),
                             Wk3 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32),
                             Wk4 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33),
                             Wk5 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34),
                             Wk6 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35),
                             Wk7 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36),
                             Wk8 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37),
                             Wk9 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38),
                             Wk10 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39),
                             Wk11 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40),
                             Wk12 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 - d.DemandWk41 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40 + sc.ShipCommit41),

                         };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                };

                quantities.Add(mymodel);
            }

            return View("Heil", quantities);

            //return View(db.Demands.ToList());
        }

        public ActionResult _Forecast(int customer, int div, int mls)
        {
            var query = from d in db.Demands
                        join cq in db.CustomerQohs on d.Pn equals cq.Pn
                        join tx in db.TxQohs on d.Pn equals tx.Pn
                        join sc in db.ShipCommits on d.Pn equals sc.Pn
                        join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                        join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                        where mp.CustomerId == customer && mp.CustomerDivisionId == div && mp.MlsDivisionId == mls
                        select new
                        {

                            CustomerPn = mp.CustomerPn,
                            COH = cq.Qoh,
                            TOH = tx.Qoh,
                            Wk1 = (cq.Qoh + tx.Qoh - d.DemandWk30 + sc.ShipCommit30),
                            Wk2 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 + sc.ShipCommit30 + sc.ShipCommit31),
                            Wk3 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32),
                            Wk4 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33),
                            Wk5 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34),
                            Wk6 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35),
                            Wk7 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36),
                            Wk8 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37),
                            Wk9 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38),
                            Wk10 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39),
                            Wk11 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40),
                            Wk12 = (cq.Qoh + tx.Qoh - d.DemandWk30 - d.DemandWk31 - d.DemandWk32 - d.DemandWk33 - d.DemandWk34 - d.DemandWk35 - d.DemandWk36 - d.DemandWk37 - d.DemandWk38 - d.DemandWk39 - d.DemandWk40 - d.DemandWk41 + sc.ShipCommit30 + sc.ShipCommit31 + sc.ShipCommit32 + sc.ShipCommit33 + sc.ShipCommit34 + sc.ShipCommit35 + sc.ShipCommit36 + sc.ShipCommit37 + sc.ShipCommit38 + sc.ShipCommit39 + sc.ShipCommit40 + sc.ShipCommit41),

                        };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                };

                quantities.Add(mymodel);
            }

            return View("_ForecastPartialView", quantities);

            //return View(db.Demands.ToList());
        }

        public ActionResult _Demand(int customer, int div, int mls)
        {

            var query = from d in db.Demands
                        join cq in db.CustomerQohs on d.Pn equals cq.Pn
                        join tx in db.TxQohs on d.Pn equals tx.Pn
                        join sc in db.ShipCommits on d.Pn equals sc.Pn
                        join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                        join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                        where mp.CustomerId == customer && mp.CustomerDivisionId == div && mp.MlsDivisionId == mls
                        select new
                        {

                            CustomerPn = mp.CustomerPn,
                            COH = cq.Qoh,
                            TOH = tx.Qoh,
                            Wk1 = d.DemandWk30,
                            Wk2 = d.DemandWk31,
                            Wk3 = d.DemandWk32,
                            Wk4 = d.DemandWk33,
                            Wk5 = d.DemandWk34,
                            Wk6 = d.DemandWk35,
                            Wk7 = d.DemandWk36,
                            Wk8 = d.DemandWk37,
                            Wk9 = d.DemandWk38,
                            Wk10 = d.DemandWk39,
                            Wk11 = d.DemandWk40,
                            Wk12 = d.DemandWk41

                        };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                };

                quantities.Add(mymodel);
            }

            return View("_DemandPartialView", quantities);
            //return View();
        }

        public ActionResult _Commits(int customer, int div, int mls)
        {

            var query = from d in db.Demands
                        join cq in db.CustomerQohs on d.Pn equals cq.Pn
                        join tx in db.TxQohs on d.Pn equals tx.Pn
                        join sc in db.ShipCommits on d.Pn equals sc.Pn
                        join s in db.ShipIns.Where(r => r.ShipInStatusId != 3) on d.Pn equals s.Pn into incgroup
                        join mp in db.MasterPartLists on d.Pn equals mp.CustomerPn
                        where mp.CustomerId == customer && mp.CustomerDivisionId == div && mp.MlsDivisionId == mls
                        select new
                        {

                            CustomerPn = mp.CustomerPn,
                            COH = cq.Qoh,
                            TOH = tx.Qoh,
                            Wk1 = sc.ShipCommit30,
                            Wk2 = sc.ShipCommit31,
                            Wk3 = sc.ShipCommit32,
                            Wk4 = sc.ShipCommit33,
                            Wk5 = sc.ShipCommit34,
                            Wk6 = sc.ShipCommit35,
                            Wk7 = sc.ShipCommit36,
                            Wk8 = sc.ShipCommit37,
                            Wk9 = sc.ShipCommit38,
                            Wk10 = sc.ShipCommit39,
                            Wk11 = sc.ShipCommit40,
                            Wk12 = sc.ShipCommit41

                        };

            List<ForecastViewModel> quantities = new List<ForecastViewModel>();
            foreach (var f in query.ToList())
            {
                ForecastViewModel mymodel = new ForecastViewModel()
                {
                    CustomerPn = f.CustomerPn,
                    COH = f.COH,
                    TOH = f.TOH,
                    Wk1 = f.Wk1,
                    Wk2 = f.Wk2,
                    Wk3 = f.Wk3,
                    Wk4 = f.Wk4,
                    Wk5 = f.Wk5,
                    Wk6 = f.Wk6,
                    Wk7 = f.Wk7,
                    Wk8 = f.Wk8,
                    Wk9 = f.Wk9,
                    Wk10 = f.Wk10,
                    Wk11 = f.Wk11,
                    Wk12 = f.Wk12
                }; 

                quantities.Add(mymodel);
            }

            return View("_ShipCommitPartialView", quantities);
            //return View();
        }

        // GET: Demands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // GET: Demands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DemandId,Pn,PastDue,OpenPoQty,UseDate,DemandWk,DemandWk30,DemandWk31,DemandWk32,DemandWk33,DemandWk34,DemandWk35,DemandWk36,DemandWk37,DemandWk38,DemandWk39,DemandWk40,DemandWk41,DemandWk42,DemandWk43,DemandWk44,DemandWk45,DemandWk46,DemandWk47,DemandWk48,DemandWk49,DemandWk50,DemandWk51,DemandWk52,DemandWk1,DemandWk2,DemandWk3,DemandWk4,DemandWk5,DemandWk6,DemandWk7,DemandWk8,DemandWk9,DemandWk10,DemandWk11,DemandWk12,DemandWk13,DemandWk14,DemandWk15,DemandWk16,DemandWk17,DemandWk18,DemandWk19,DemandWk20,DemandWk21,DemandWk22,DemandWk23,DemandWk24,DemandWk25,DemandWk26,DemandWk27,DemandWk28,DemandWk29,Notes")] Demand demand)
        {
            if (ModelState.IsValid)
            {
                db.Demands.Add(demand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(demand);
        }

        // GET: Demands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // POST: Demands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DemandId,Pn,PastDue,OpenPoQty,UseDate,DemandWk,DemandWk30,DemandWk31,DemandWk32,DemandWk33,DemandWk34,DemandWk35,DemandWk36,DemandWk37,DemandWk38,DemandWk39,DemandWk40,DemandWk41,DemandWk42,DemandWk43,DemandWk44,DemandWk45,DemandWk46,DemandWk47,DemandWk48,DemandWk49,DemandWk50,DemandWk51,DemandWk52,DemandWk1,DemandWk2,DemandWk3,DemandWk4,DemandWk5,DemandWk6,DemandWk7,DemandWk8,DemandWk9,DemandWk10,DemandWk11,DemandWk12,DemandWk13,DemandWk14,DemandWk15,DemandWk16,DemandWk17,DemandWk18,DemandWk19,DemandWk20,DemandWk21,DemandWk22,DemandWk23,DemandWk24,DemandWk25,DemandWk26,DemandWk27,DemandWk28,DemandWk29,Notes")] Demand demand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(demand);
        }

        // GET: Demands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Demand demand = db.Demands.Find(id);
            if (demand == null)
            {
                return HttpNotFound();
            }
            return View(demand);
        }

        // POST: Demands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Demand demand = db.Demands.Find(id);
            db.Demands.Remove(demand);
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
