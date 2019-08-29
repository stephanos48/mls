using System;
using System.Collections;
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
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace mls.Controllers
{
    [Authorize]
    public class CustomerOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerOrders
        public ActionResult Index()
        {
            //return View(db.CustomerOrders.ToList());
            if (User.IsInRole("Admin"))
            {
                return View("Index", db.CustomerOrders.ToList());
            }
            else if (User.IsInRole("Wastebuilt"))
            {
                return View("WBHome");
            }
            else if (User.IsInRole("LogisticsBasic"))
            {
                return View("LogisticsBasic");
            }
            else if (User.IsInRole("Nov"))
            {
                return View("NovHome");
            }
            else if (User.IsInRole("Thi"))
            {
                return View("NewThiHome");
            }
            else if (User.IsInRole("View"))
            {
                return View("Index1");
            }
            else if (User.IsInRole("QualityAdmin"))
            {
                return View("Index");
            }
            else if (User.IsInRole("Sales"))
            {
                return View("Index");
            }
            else if (User.IsInRole("OpsPower"))
            {
                return View("Index");
            }
            else if (User.IsInRole("InvPower"))
            {
                return View("Index");
            }
            else if (User.IsInRole("PurPower"))
            {
                return View("Index");
            }
            else if (User.IsInRole("EngPower"))
            {
                return View("Index");
            }
            else if (User.IsInRole("Columbus"))
            {
                return View("ChHome");
            }
            else if (User.IsInRole("JbtOrlando"))
            {
                return View("JBT_OrlandoHome");
            }
            else if (User.IsInRole("Heil"))
            {
                return View("HeilHome");
            }
            else if (User.IsInRole("Pc"))
            {
                return View("PcHome");
            }
            else if (User.IsInRole("Esg"))
            {
                return View("NewEsgHome");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // GET: CustomerOrders/LogisticsBasic
        public ActionResult LogisticsBasic()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("LogisticsBasic");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult Nov()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("Nov");
        }

        public ActionResult OldSales()
        {
            return View("OldSales");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult HydSales()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("HydSales");
        }

        public ActionResult DipSales()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("DipSales");
        }

        // GET: CustomerOrders/Pc
        public ActionResult PcHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("PcHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult JbtOrlando()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("JBT_Orlando");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult JBT_OrlandoHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("JBT_OrlandoHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROJbtOrlando()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ROJbtOrlando");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult JbtOgden()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("JBT_Ogden");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult THI()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("THI");
        }

        // GET: CustomerOrders/
        public ActionResult NovHyd()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("Nov_Hyd");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROWastebuiltDip()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ROWastebuiltDip");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult DOP()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("DOP");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult RoNov()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("RONov");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult Index1()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("~/Views/CustomerOrders/Index1.cshtml");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult RoThi()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ROThi");
        }
        
        // GET: CustomerOrders/Details/5
        public ActionResult WbDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder wbdetails = db.CustomerOrders.Find(id);
            if (wbdetails == null)
            {
                return HttpNotFound();
            }
            return View(wbdetails);
        }

        // GET: CustomerOrders/Details/5
        public ActionResult HeilDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder heildetails = db.CustomerOrders.Find(id);
            if (heildetails == null)
            {
                return HttpNotFound();
            }
            return View(heildetails);
        }

        
        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROWastebuilt()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ROWastebuilt");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult RoColumbus1()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("RoColumbus1");
        }

        
        // GET: CustomerOrders/Wastebuilt
        public ActionResult Wastebuilt()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult SalesAll()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("SalesAll");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult Vsg()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult Forecast()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 2 || mp.CustomerId == 1 && mp.CustomerDivisionId == 6 || mp.CustomerDivisionId == 1
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("WBQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult PcQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 1 && mp.CustomerDivisionId == 9
                        orderby a.Pn ascending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("PcQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult JbtOrlQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 19
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("JbtOrlQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult WBQoh()
        { 
            var query = from a in db.TxQohs
                join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                where mp.CustomerId == 2 || mp.CustomerId == 1 && mp.CustomerDivisionId == 6 || mp.CustomerDivisionId == 1
                orderby a.Pn descending
                select new
                {
                    PN = a.Pn,
                    QOH = a.Qoh
                };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };
                
                quantities.Add(mymodel);
            }

            return View("WBQoh", quantities);
            //return View();
        }

        public ActionResult EsgQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 1
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("EsgQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ChQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 21
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("ChQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ThiQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 8
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("ThiQoh", quantities);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult HeilQoh()
        {
            var query = from a in db.TxQohs
                        join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                        where mp.CustomerId == 1 && mp.CustomerDivisionId == 1
                        orderby a.Pn descending
                        select new
                        {
                            PN = a.Pn,
                            QOH = a.Qoh
                        };

            List<QohViewModel> quantities = new List<QohViewModel>();
            foreach (var qoh in query.ToList())
            {
                QohViewModel mymodel = new QohViewModel()
                {
                    Pn = qoh.PN,
                    Qoh = qoh.QOH
                };

                quantities.Add(mymodel);
            }

            return View("HeilQoh", quantities);
            //return View();
        }

        public ActionResult RoHeil()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1 && a.OrderStatusId != 7
                        orderby a.OrderDateTime descending
                        select a;
            return View("RoHeil", query);
            //return View();
        }

        public ActionResult RoHeil1()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 1 && co.CustomerDivisionId == 1 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ROHeil1", result);
        
            /*var query = from a in db.CustomerOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("RoHeil1", query);*/
            //return View();
        }

        public ActionResult RoHeil1Closed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 1 && co.CustomerDivisionId == 1 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("RoHeil1Closed", result);

            /*var query = from a in db.CustomerOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("RoHeil1", query);*/
            //return View();
        }

        public ActionResult RoPc1()
        {
            //var query = from a in db.CustomerOrders
            //            where a.CustomerId == 1 && a.CustomerDivisionId == 9
            //            orderby a.OrderDateTime descending
            //            select a;
            //return View("RoPc1", query);
            return View();
        }

        public ActionResult RoPc()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.OrderDateTime descending
                        select a;
            return View("RoPc", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult WB1()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 2 && a.CustomerDivisionId == 6 && a.OrderStatusId != 7 && a.MlsDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("WB1", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROWastebuilt1()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 2 && a.CustomerDivisionId == 6 && a.OrderStatusId != 7 && a.MlsDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("ROWastebuilt1", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult RoColumbus()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 21 && a.CustomerDivisionId == 7 && a.OrderStatusId != 7 && a.MlsDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("RoColumbus", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult WastebuiltDip1()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 2 && a.CustomerDivisionId == 6 && a.OrderStatusId != 7 && a.MlsDivisionId == 4
                        orderby a.OrderDateTime descending
                        select a;
            return View("WastebuiltDip1", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROWastebuiltDip1()
        {
            var query = from a in db.CustomerOrders
                        where a.CustomerId == 2 && a.CustomerDivisionId == 6 && a.OrderStatusId != 7 && a.MlsDivisionId == 4
                        orderby a.OrderDateTime descending
                        select a;
            return View("ROWastebuiltDip1", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ROIndex()
        {
            var query = from a in db.CustomerOrders
                        orderby a.OrderDateTime descending
                        select a;
            return View("Wastebuilt", query);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ThiHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ThiHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult NewThiHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewThiHome");
        }

        public ActionResult NewEsgHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewEsgHome");
        }

        public ActionResult HeilHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("HeilHome");
        }

        public ActionResult NewHeilHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewHeilHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult WbHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("WbHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult NewWbHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewWbHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult ChHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ChHome");
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult NewChHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewChHome");
        }

        // GET: CustomerOrders/NOV
        public ActionResult NovHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NovHome");
        }

        // GET: CustomerOrders/NOV
        public ActionResult NewNovHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("NewNovHome");
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _PNewOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PNewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _NewOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                        where a.OrderStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                        select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
              result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_NewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _RONewOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_RONewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _PpNewOrder()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 1
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PNewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult _PReview(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 9 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PReviewPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult _Review(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 9 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_ReviewPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/ROReview
        [HttpGet]
        public ActionResult _ROReview(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 9 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_ROReviewPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult _PpReview()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 9 
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PReviewPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/StockOut
        [HttpGet]
        public ActionResult _StockOut(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 8 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_StockOutPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/StockOut
        [HttpGet]
        public ActionResult _PStockOut(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 8 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PStockOutPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/StockOut
        [HttpGet]
        public ActionResult _ROStockOut(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 8 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_ROStockOutPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/StockOut
        [HttpGet]
        public ActionResult _PpStockOut()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 8 
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    SoNumber = order.SoNumber,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_PStockOutPartialView", result);
        }

        [HttpGet]
        // GET: CustomerOrders/Wastebuilt/Sample
        public ActionResult _Sample(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 2 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_SamplePartialView", result);
        }

        [HttpGet]
        // GET: CustomerOrders/Wastebuilt/Sample
        public ActionResult _ROSample(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 2 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_ROSamplePartialView", result);
        }

        [HttpGet]
        // GET: CustomerOrders/Wastebuilt/Sample
        public ActionResult _PpSample()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 2 
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_SamplePartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Design
        [HttpGet]
        public ActionResult _Design(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 3 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_DesignPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Design
        [HttpGet]
        public ActionResult _PpDesign()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 3
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_DesignPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Design
        [HttpGet]
        public ActionResult _RODesign(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 3 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }

            return PartialView("_RODesignPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Production
        public ActionResult _Production(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 4 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ProductionPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Production
        public ActionResult _PProduction(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 4 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PProductionPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Production
        public ActionResult _PpProduction()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 4
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PProductionPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Production
        public ActionResult _ROProduction(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 4 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ROProductionPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Ocean
        public ActionResult _POcean(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 5 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_POceanPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Ocean
        public ActionResult _PpOcean()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 5
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_POceanPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Ocean
        public ActionResult _Ocean(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 5 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_OceanPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Ocean
        public ActionResult _ROOcean(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 5 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ROOceanPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Tx
        public ActionResult _Tx(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 6 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_TxPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Tx
        public ActionResult _PTx(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 6 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PTxPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Tx
        public ActionResult _PpTx()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 6 
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PTxPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Tx
        public ActionResult _ROTx(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 6 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ROTxPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Closed
        public ActionResult _PClosed(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 7 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PClosedPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Closed
        public ActionResult _PpClosed()
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 7
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_PClosedPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/Closed
        public ActionResult _Closed(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 7 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ClosedPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/ROClosed
        public ActionResult _ROClosed(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.CustomerOrders
                           where a.OrderStatusId == 7 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.OrderDateTime descending
                           select a;
            List<NewOrderViewModel> result = new List<NewOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    OrderDateTime = order.OrderDateTime,
                    CustomerPn = order.CustomerPn,
                    PartDescription = order.PartDescription,
                    SoNumber = order.SoNumber,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ShipDateTime = order.ShipDateTime,
                    Notes = order.Notes
                });
            }
            return PartialView("_ROClosedPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult Heil()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View();
        }

        // GET: CustomerOrders/Sales
        public ActionResult Sales()
        {
            return View();
        }

        // GET: CustomerOrders/Ops
        public ActionResult Ops()
        {
            return View();
        }

        // GET: CustomerOrders/SC
        public ActionResult SC()
        {
            return View();
        }

        // GET: CustomerOrders/Quality
        public ActionResult Quality()
        {
            return View();
        }

        // GET: CustomerOrders/Hunter
        public ActionResult Hunter()
        {
            return View();
        }

        // GET: CustomerOrders/Forum 
        public ActionResult Forum()
        {
            return View();
        }

        // GET: CustomerOrders/Forum 
        public ActionResult Columbus()
        {
            return View();
        }

        // GET: CustomerOrders/Bayne
        public ActionResult Bayne()
        {
            return View();
        }

        // GET: CustomerOrders/Simonson
        public ActionResult Simonson()
        {
            return View();
        }

        // GET: CustomerOrders/DTT
        public ActionResult DTT()
        {
            return View();
        }

        // GET: CustomerOrders/DTT
        public ActionResult PartsCentral()
        {
            return View();
        }

        // GET: CustomerOrders/CL
        public ActionResult CL()
        {
            return View();
        }

        // GET: CustomerOrders/PC
        public ActionResult PC()
        {
            return View();
        }

        // GET: CustomerOrders/Marathon
        public ActionResult Marathon()
        {
            return View();
        }

        public ActionResult Logistics()
        {
            return View("~/Views/ShipIns/Index.cshtml");
        }

        // GET: CustomerOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: CustomerOrders/Details/5
        public ActionResult RoDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // GET: CustomerOrders/Create
        public ActionResult Create()
        {
            /*
            //var customers = GetAllCustomers();
            //var divisions = GetAllDivisions();
            //var mlsdivisions = GetAllMlsDivisions();
            //var statuss = GetAllStatuss();

            //var model = new Order();

            //model.Customers = GetSelectListItems(customers);
            //model.CustomerDivisions = GetSelectListItems(divisions);
            //model.MlsDivisions = GetSelectListItems(mlsdivisions);
            //model.Statuss = GetSelectListItems(statuss);
            */

            //drop down list feed coded here
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var orderstatuses = db.OrderStatuses.ToList();
            var cordertypes = db.COrderTypes.ToList();

            var viewModel = new SaveOrderViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                OrderStatuses = orderstatuses,
                COrderTypes = cordertypes

            };

            return View("Create", viewModel);
        }

        // POST: CustomerOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CustomerOrderId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,StatusId,Notes")] CustomerOrder customerOrder)
        public ActionResult Create(CustomerOrder customerOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.CustomerOrders.Add(customerOrder);
                db.SaveChanges();
                return Redirect(returnUrl);
            }

            return View();
            //return View(customerOrder);
        }

        // GET: CustomerOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var customerorders = db.CustomerOrders.SingleOrDefault(c => c.CustomerOrderId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var orderstatuses = db.OrderStatuses.ToList();
            var cordertypes = db.COrderTypes.ToList();

            var viewModel = new SaveOrderViewModel()
            {
                CustomerOrder = customerorders,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                OrderStatuses = orderstatuses,
                COrderTypes = cordertypes
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }

            return View("Edit", viewModel);
            //return View(customerOrder);
        }

        // POST: CustomerOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CustomerOrderId,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ShipQty,RequestedDateTime,PromiseDateTime,ShipDateTime,OrderStatusId,Notes")] CustomerOrder customerOrder)
        public ActionResult Edit(CustomerOrder customerOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrder).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
        }

        // GET: CustomerOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            if (customerOrder == null)
            {
                return HttpNotFound();
            }
            return View(customerOrder);
        }

        // POST: CustomerOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string returnUrl)
        {
            CustomerOrder customerOrder = db.CustomerOrders.Find(id);
            db.CustomerOrders.Remove(customerOrder);
            db.SaveChanges();
            return Redirect(returnUrl);
        }

        public ActionResult NewPartial()
        {
            return NewPartial();
        }

        public ActionResult Home()
        {
            return Home();
        }
        
        // GET: CustomerOrders/Wastebuilt
        public ActionResult SalesAllAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("SalesAllAlt", result);
            //return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult SalesClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("SalesClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HeilAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 1 && co.CustomerDivisionId == 1 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HeilAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HeilAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 1 && co.CustomerDivisionId == 1 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HeilAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PickSchedule()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.OrderStatusId != 7 && co.COrderTypeId == 1
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               CustomerDivision = co.CustomerDivisionId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerDivisionId = order.CustomerDivision,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PickSchedule", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PickScheduleClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.OrderStatusId == 7 && co.COrderTypeId == 1
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               CustomerDivision = co.CustomerDivisionId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerDivisionId = order.CustomerDivision,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PickScheduleClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PcPickSchedule()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.OrderStatusId != 7 && co.COrderTypeId == 1 && co.CustomerDivisionId == 9
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               CustomerDivision = co.CustomerDivisionId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerDivisionId = order.CustomerDivision,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PcPickSchedule", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PcPickScheduleClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.OrderStatusId == 7 && co.COrderTypeId == 1 && co.CustomerDivisionId == 9
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               CustomerDivision = co.CustomerDivisionId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerDivisionId = order.CustomerDivision,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PcPickScheduleClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult AssemblySchedule()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.OrderStatusId != 7 && co.COrderTypeId == 2
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("AssemblySchedule", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ClosedAssembly()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.OrderStatusId == 7 && co.COrderTypeId == 2
                           orderby co.ShipDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ClosedAssembly", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PcAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 1 && co.CustomerDivisionId == 9 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PcAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult PcAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 1 && co.CustomerDivisionId == 9 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("PcAltClosed", result);
        }

                // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HydSalesAllAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.MlsDivisionId == 1 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HydSalesAllAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HydSalesAllAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.MlsDivisionId == 1 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HydSalesAllAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ClAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.MlsDivisionId == 3 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ClAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ClAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.MlsDivisionId == 3 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ClAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DttSales()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.MlsDivisionId == 2 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DttSales", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DttSalesClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.MlsDivisionId == 2 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DttSalesClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DopSales()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.MlsDivisionId == 5 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DopSales", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DopSalesClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.MlsDivisionId == 5 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DopSalesClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DipSalesAll()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.MlsDivisionId == 4 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DipSalesAll", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult DipSalesClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.MlsDivisionId == 4 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               PoLine = co.CustomerOrderLine,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    CustomerOrderLine = order.PoLine,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("DipSalesClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ColumbusAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 21 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ColumbusAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ColumbusAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 21 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ColumbusAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HunterAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 4 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HunterAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult HunterAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 4 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("HunterAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult MarathonAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 1 && co.CustomerDivisionId == 2 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("MarathonAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult MarathonAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 1 && co.CustomerDivisionId == 2 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("MarathonAltClosed", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ThiAlt()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           join tx in db.TxQohs on co.CustomerPn equals tx.Pn
                           where co.CustomerId == 8 && co.OrderStatusId != 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OhQty = tx.Qoh,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OhQty = order.OhQty,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ThiAlt", result);
        }

        // GET: CustomerOrders/Wastebuilt/Review
        [HttpGet]
        public ActionResult ThiAltClosed()
        {
            var queryNew = from co in db.CustomerOrders
                           join so in db.ShipOuts on new { x1 = co.CustomerOrderNumber, x2 = co.CustomerPn } equals new { x1 = so.PoNumber, x2 = so.Pn } into g
                           where co.CustomerId == 8 && co.OrderStatusId == 7
                           orderby co.OrderDateTime ascending
                           select new
                           {
                               CustomerOrderId = co.CustomerOrderId,
                               OrderStatus = co.OrderStatusId,
                               SoNo = co.SoNumber,
                               CustomerPo = co.CustomerOrderNumber,
                               OrderDate = co.OrderDateTime,
                               CustomerPn = co.CustomerPn,
                               OrderQty = co.OrderQty,
                               ShipQty = (int?)g.Sum(x => x.Quantity),
                               RequestDate = co.RequestedDateTime,
                               PromiseDate = co.PromiseDateTime,
                               ShipDate = co.ShipDateTime,
                               Notes = co.Notes
                           };
            List<OpenOrderViewModel> result = new List<OpenOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new OpenOrderViewModel
                {
                    CustomerOrderId = order.CustomerOrderId,
                    OrderStatusId = order.OrderStatus,
                    CustomerPo = order.CustomerPo,
                    OrderDateTime = order.OrderDate,
                    SoNumber = order.SoNo,
                    CustomerPn = order.CustomerPn,
                    OrderQty = order.OrderQty,
                    ShipQty = order.ShipQty,
                    RequestedDateTime = order.RequestDate,
                    PromiseDateTime = order.PromiseDate,
                    ShipDateTime = order.ShipDate,
                    Notes = order.Notes
                });
            }

            return View("ThiAltClosed", result);
        }

        /*
        public IList <WbOrderViewModel> GetWbOrderList()
        {
            var wborderlist = (from e in db.CustomerOrders where e.CustomerId == 2 && e.CustomerDivisionId == 6 && e.MlsDivisionId == 1 select new WbOrderViewModel { 
            CustomerOrderId = e.CustomerOrderId,
            CustomerOrderNumber = e.CustomerOrderNumber,
            SoNumber = e.SoNumber,
            OrderDateTime = e.OrderDateTime,
            CustomerPn = e.CustomerPn,
            OrderQty = e.OrderQty,
            ShipQty = e.ShipQty,
            PromiseDateTime = e.PromiseDateTime,
            ShipDateTime = e.ShipDateTime,
            Notes = e.Notes
            }).ToList();
            return wborderlist;
        }
        public ActionResult ExportWb()
        {
            var gv = new GridView();
            gv.DataSource = this.GetWbOrderList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; GetWbOrderList.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("WB1");
        }
        */
        /*[HttpPost]
        public FileResult ExportCOWB()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[11] 
            { new DataColumn("CustomerOrderId"),
              new DataColumn("CustomerOrderNumber"),
              new DataColumn("SoNumber"),
              new DataColumn("OrderDateTime"),
              new DataColumn("CustomerPn"),
              new DataColumn("OrderQty"),
              new DataColumn("ShipQty"),
              new DataColumn("PromiseDateTime"),
              new DataColumn("ShipDateTime"),
              new DataColumn("OrderStatusId"),
              new DataColumn("Notes") });

            var customerorders = from co in db.CustomerOrders
                                 where co.CustomerId == 2 && co.CustomerDivisionId == 6 && co.OrderStatusId == 7
                                 select co;

            foreach (var customerorder in customerorders)
            {
                dt.Rows.Add(customerorder.CustomerOrderId, customerorder.CustomerOrderNumber, customerorder.SoNumber, customerorder.OrderDateTime, customerorder.CustomerPn, customerorder.OrderQty, customerorder.ShipQty, customerorder.PromiseDateTime, customerorder.ShipDateTime, customerorder.OrderStatusId, customerorder.Notes);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xslx");
                }
            }

        }*/

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
