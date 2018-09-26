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

namespace mls.Controllers
{
    [Authorize]
    public class PurchaseOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchaseOrders
        public ActionResult Index()
        {
            return View(db.PurchaseOrders.ToList());
        }

        public ActionResult Columbus()
        {
            return View("Columbus");
        }

        public ActionResult PoHome()
        {
            return View("PoHome");
        }

        public ActionResult HualinCustomer()
        {
            return View("HualinCustomer");
        }

        public ActionResult LishenCustomer()
        {
            return View("LishenCustomer");
        }

        public ActionResult HeilPos()
        {
            return View("HeilPos");
        }

        public ActionResult MarathonPos()
        {
            return View("MarathonPos");
        }

        public ActionResult BaynePos()
        {
            return View("BaynePos");
        }

        public ActionResult PcPos()
        {
            return View("PcPos");
        }

        public ActionResult WbHydPos()
        {
            return View();
        }

        public ActionResult WbDipPos()
        {
            return View();
        }

        public ActionResult VsgPos()
        {
            return View();
        }

        public ActionResult HunterPos()
        {
            return View();
        }

        public ActionResult ThiPos()
        {
            return View();
        }

        public ActionResult JbtOrlando()
        {
            return View();
        }

        public ActionResult JbtOgden()
        {
            return View();
        }

        public ActionResult DttPos()
        {
            return View();
        }

        public ActionResult ClPos()
        {
            return View();
        }

        public ActionResult HualinOrders()
        {
            return View();
        }

        public ActionResult LishenOrders()
        {
            return View();
        }

        public ActionResult DipPos()
        {
            return View();
        }

        public ActionResult HeilPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 1
                        orderby a.OrderDateTime descending
                        select a;
            return View("HeilPo", query);
        }

        public ActionResult MarathonPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 2
                        orderby a.OrderDateTime descending
                        select a;
            return View("MarathonPo", query);
        }

        public ActionResult BaynePo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 4
                        orderby a.OrderDateTime descending
                        select a;
            return View("BaynePo", query);
        }

        public ActionResult PcPo()
        {
            var query = from a in db.PurchaseOrders
                        where a.CustomerId == 1 && a.CustomerDivisionId == 9
                        orderby a.OrderDateTime descending
                        select a;
            return View("PcPo", query);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _NewOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 1 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_NewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _CompNewOrder(int MlsSupplier)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 1 && a.SupplierId == MlsSupplier
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_CompNewOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _BusNewOrder(int MlsDivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 1 && a.MlsDivisionId == MlsDivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_BusNewOrderPartialView", result);
        }


        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _HotOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 2 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_HotOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _CompHotOrder(int MlsSupplier)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 2 && a.SupplierId == MlsSupplier
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_CompHotOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _BusHotOrder(int MlsDivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 2 && a.MlsDivisionId == MlsDivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_BusHotOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _PastDueOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 3 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_PastDueOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _CompPastDueOrder(int MlsSupplier)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 3 && a.SupplierId == MlsSupplier
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_CompPastDueOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _BusPastDueOrder(int MlsDivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 3 && a.MlsDivisionId == MlsDivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_BusPastDueOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _OpenOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 4 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_OpenOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _CompOpenOrder(int MlsSupplier)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 4 && a.SupplierId == MlsSupplier
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_CompOpenOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _BusOpenOrder(int MlsDivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 4 && a.MlsDivisionId == MlsDivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_BusOpenOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _ClosedOrder(int customer, int division, int mlsdivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 5 && a.CustomerId == customer && a.CustomerDivisionId == division && a.MlsDivisionId == mlsdivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_ClosedOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _CompClosedOrder(int MlsSupplier)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 5 && a.SupplierId == MlsSupplier
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_CompClosedOrderPartialView", result);
        }

        // GET: CustomerOrders/Wastebuilt/NewOrder
        [HttpGet]
        public ActionResult _BusClosedOrder(int MlsDivision)
        {
            var queryNew = from a in db.PurchaseOrders
                           where a.PoOrderStatusId == 5 && a.MlsDivisionId == MlsDivision
                           orderby a.CustomerPn ascending
                           select a;
            List<NewPurchaseOrderViewModel> result = new List<NewPurchaseOrderViewModel>();
            foreach (var order in queryNew.ToList())
            {
                result.Add(new NewPurchaseOrderViewModel
                {
                    PurchaseOrderId = order.PurchaseOrderId,
                    PoNumber = order.PoNumber,
                    Supplier = order.Supplier,
                    ShipToAddress = order.ShipToAddress,
                    ConfirmTo = order.ConfirmTo,
                    ShipVia = order.ShipVia,
                    FOB = order.FOB,
                    Terms = order.Terms,
                    Reference = order.Reference,
                    CustomerOrderNumber = order.CustomerOrderNumber,
                    SoNumber = order.SoNumber,
                    OrderDateTime = order.OrderDateTime,
                    Customer = order.Customer,
                    CustomerDivision = order.CustomerDivision,
                    MlsDivision = order.MlsDivision,
                    CustomerPn = order.CustomerPn,
                    UhPn = order.UhPn,
                    PartDescription = order.PartDescription,
                    PartPrice = order.PartPrice,
                    OrderQty = order.OrderQty,
                    ReceivedQty = order.ReceivedQty,
                    RequestedDateTime = order.RequestedDateTime,
                    PromiseDateTime = order.PromiseDateTime,
                    ReceiptDateTime = order.ReceiptDateTime,
                    PoOrderStatus = order.PoOrderStatus,
                    Notes = order.Notes
                });
            }

            return PartialView("_BusClosedOrderPartialView", result);
        }

        // GET: PurchaseOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public ActionResult Create()
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;

            var suppliers = db.Suppliers.ToList();
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var poorderstatuses = db.PoOrderStatuses.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();

            var viewModel = new SavePurchaseOrderViewModel()
            {
                Suppliers = suppliers,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                PoOrderStatuses = poorderstatuses,
                MlsDivisions = mlsdivisions
            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PurchaseOrderId,PoNumber,SupplierId,ShipToAddress,ConfirmTo,ShipVia,FOB,Terms,Reference,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,OrderStatusId,Notes")] PurchaseOrder purchaseOrder)
        public ActionResult Create(PurchaseOrder purchaseOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseOrder);
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            var purchaseorders = db.PurchaseOrders.SingleOrDefault(c => c.PurchaseOrderId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var poorderstatuses = db.PoOrderStatuses.ToList();
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SavePurchaseOrderViewModel()
            {
                PurchaseOrder = purchaseorders,
                Suppliers = suppliers,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                PoOrderStatuses = poorderstatuses,
                MlsDivisions = mlsdivisions
            };
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PurchaseOrderId,PoNumber,SupplierId,ShipToAddress,ConfirmTo,ShipVia,FOB,Terms,Reference,CustomerOrderNumber,SoNumber,OrderDateTime,CustomerId,CustomerDivisionId,MlsDivisionId,CustomerPn,UhPn,PartDescription,PartPrice,OrderQty,ReceivedQty,RequestedDateTime,PromiseDateTime,ReceiptDateTime,OrderStatusId,Notes")] PurchaseOrder purchaseOrder)
        public ActionResult Edit(PurchaseOrder purchaseOrder, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseOrder).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View();
            //return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.ReturnUrl = Request.UrlReferrer;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseOrder purchaseOrder = db.PurchaseOrders.Find(id);
            db.PurchaseOrders.Remove(purchaseOrder);
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
