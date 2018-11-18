using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;
using mls.ViewModels;

namespace mls.Controllers
{
    public class CheckRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckRequests
        /*public async Task<ActionResult> Index()
        {
            return View(await db.CheckRequests.ToListAsync());
        }*/

        public ActionResult Index()
        {
            var query = from a in db.CheckRequests
                        where a.CheckStatusId != 4
                        orderby a.CheckRequestId descending
                        select a;
            return View("Index", query);
            //return View(await db.CheckRequests.ToListAsync());
        }

        public ActionResult Closed()
        {
            var query = from a in db.CheckRequests
                        where a.CheckStatusId == 4 
                        orderby a.CheckRequestId descending
                        select a;
            return View("Closed", query);
            //return View(await db.CheckRequests.ToListAsync());
        }

        // GET: CheckRequests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequest checkRequest = await db.CheckRequests.FindAsync(id);
            if (checkRequest == null)
            {
                return HttpNotFound();
            }
            return View(checkRequest);
        }

        // GET: CheckRequests/Create
        public ActionResult Create()
        {

            var checkstatuses = db.CheckStatuses.ToList();
            
            var viewModel = new SaveCheckRequestViewModel()
            {

                CheckStatuses = checkstatuses,

            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: CheckRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "CheckRequestId,MlsCo,CheckStatus,PurchaseOrderNumber,PartNumber,PartDescription,CheckNo,Customer,Supplier,RequestDateTime,MailDateTime,ActualMailDateTime,ShipMethod,TrackingInfo,Notes")] CheckRequest checkRequest)
        public async Task<ActionResult> Create(CheckRequest checkRequest)
        {
            if (ModelState.IsValid)
            {
                db.CheckRequests.Add(checkRequest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", checkRequest);
            }

            return View();
        }

        // GET: CheckRequests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var checkrequests = db.CheckRequests.SingleOrDefault(c => c.CheckRequestId == id);

            var checkstatus = db.CheckStatuses.ToList();

            var viewModel = new SaveCheckRequestViewModel()
            {
                CheckRequest = checkrequests,
                CheckStatuses = checkstatus
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequest checkRequest = await db.CheckRequests.FindAsync(id);
            if (checkRequest == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(checkRequest);
        }

        // POST: CheckRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "CheckRequestId,MlsCo,CheckStatus,PurchaseOrderNumber,PartNumber,PartDescription,CheckNo,Customer,Supplier,RequestDateTime,MailDateTime,ActualMailDateTime,ShipMethod,TrackingInfo,Notes")] CheckRequest checkRequest)
        public async Task<ActionResult> Edit(CheckRequest checkRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkRequest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", checkRequest);
            }
           return View(checkRequest);
        }

        // GET: CheckRequests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckRequest checkRequest = await db.CheckRequests.FindAsync(id);
            if (checkRequest == null)
            {
                return HttpNotFound();
            }
            return View(checkRequest);
        }

        // POST: CheckRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CheckRequest checkRequest = await db.CheckRequests.FindAsync(id);
            db.CheckRequests.Remove(checkRequest);
            await db.SaveChangesAsync();
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
