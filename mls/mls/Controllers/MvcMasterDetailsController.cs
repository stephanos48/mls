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
        public JsonResult SaveOrder11(MvcMasterDetails O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    IncomingTopLevel incomingTopLevel = new IncomingTopLevel { IncomingVesselNo = O.IncomingVesselNo, InspectionDateTime = O.InspectionDateTime, Notes = O.Notes };
                    db.IncomingTopLevels.Add(incomingTopLevel);
                    //IncomingDetail incomingDetail = new IncomingDetail { PartNumber = IncomingDetail.PartNumber, InspectorName = incomingDetail.InspectorName }
                    //db.IncomingDetails.Add(incomingDetail);
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

        public ActionResult MvcMasterDetails()
        {
            List<IncomingTopLevel> IncomingTopLevelandDetailList = db.IncomingTopLevels.ToList();
            return View(IncomingTopLevelandDetailList);
        }

        [HttpPost]
        public ActionResult SaveOrder(string incomingVesselNo, DateTime date, string notes, IncomingDetail[] incomingDetail)
        {
            string result = "Error! Order Is Not Complete!";
            if (incomingVesselNo != null && date != null && notes != null)
            {
                IncomingTopLevel model = new IncomingTopLevel();
                model.IncomingVesselNo = incomingVesselNo;
                model.InspectionDateTime = date;
                model.Notes = notes;
                db.IncomingTopLevels.Add(model);

                foreach (var item in incomingDetail)
                {
                    IncomingDetail O = new IncomingDetail ();
                    O.PartNumber = item.PartNumber;
                    O.InspectorName = item.InspectorName;
                    O.Notes = item.Notes;
                    O.QtyReceived = item.QtyReceived;
                    O.QtyInspected = item.QtyInspected;
                    O.QtyGood = item.QtyGood;
                    O.QtyBad = item.QtyBad;
                    db.IncomingDetails.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }

}