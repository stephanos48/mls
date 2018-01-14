using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;
using System.Data.Entity;
using System.Net;

namespace mls.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //if (User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Index", "CustomerOrders");
            //}
            //else if (User.IsInRole("Wastebuilt"))
            //{
            //    return RedirectToAction("WbHome", "CustomerOrders");
            //}
            //else if (User.IsInRole("LogisticsBasic"))
            //{
            //    return RedirectToAction("LogisticsBasic", "CustomerOrders");
            //}
            //else if (User.IsInRole("Nov"))
            //{
            //    return RedirectToAction("NovHome", "CustomerOrders");
            //}
            //else if (User.IsInRole("View"))
            //{
            //    return RedirectToAction("ROIndex", "CustomerOrders");
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home");
            //}
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}