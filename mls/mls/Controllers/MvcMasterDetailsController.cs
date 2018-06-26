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
    public class MvcMasterDetailsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MvcMasterDetails
        public ActionResult Index()
        {
            return View();
        }

        //Post action for Save data to database
        [HttpPost]
        public JsonResult SaveOrder(MvcMasterDetails O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    IncomingTopLevel incomingTopLevel = new IncomingTopLevel { IncomingVesselNo = O.IncomingVesselNo, InspectionDateTime = O.InspectionDateTime, Notes = O.Notes };
                    db.IncomingTopLevels.Add(incomingTopLevel);
                    db.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };

        }

    }

}