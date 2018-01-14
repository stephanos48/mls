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
            else if (User.IsInRole("View"))
            {
                return View("ROIndex");
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
        public ActionResult RoDetails()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("ROWastebuilt");
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
        public ActionResult Wastebuilt()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View();
        }

        // GET: CustomerOrders/Wastebuilt
        public ActionResult DipWastebuilt()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View();
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
        public ActionResult WBQoh()
        { 
            var query = from a in db.TxQohs
                join mp in db.MasterPartLists on a.Pn equals mp.CustomerPn
                where mp.CustomerId == 2 && mp.CustomerDivisionId == 6
                orderby a.Pn descending
                select new
                {
                    PN = a.Pn,
                    QOH = a.Qoh
                };
            return View("WBQoh", query);
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
        public ActionResult WbHome()
        {
            //var query = from a in db.CustomerOrders
            //               orderby a.OrderDateTime descending
            //               select a;
            // return View("Wastebuilt", query);
            return View("WbHome");
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

            var viewModel = new SaveOrderViewModel()
            {
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                OrderStatuses = orderstatuses

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

            var viewModel = new SaveOrderViewModel()
            {
                CustomerOrder = customerorders,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                OrderStatuses = orderstatuses
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
