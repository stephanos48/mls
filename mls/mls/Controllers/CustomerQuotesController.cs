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
    [Authorize]
    public class CustomerQuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerQuotes
        public ActionResult Index()
        {
            var query = from a in db.CustomerQuotes
                           orderby a.Pn ascending
                           select a;
            return View("Index", query);
        }

        // GET: CustomerQuotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerQuote customerQuote = await db.CustomerQuotes.FindAsync(id);
            if (customerQuote == null)
            {
                return HttpNotFound();
            }
            return View(customerQuote);
        }

        // GET: CustomerQuotes/Create
        public ActionResult Create()
        {
            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatus = db.CQStatuses.ToList();

            var viewModel = new SaveCustomerQuotesViewModel()
            {

                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                CQStatuses = cqstatus
            };

            return View("Create", viewModel);
            //return View();
        }

        // POST: CustomerQuotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "CustomerQuoteId,Pn,QuoteDate,QuotedPrice,PriceBreak,Tariff,Terms,QuoteBy,Notes")] CustomerQuote customerQuote)
        public async Task<ActionResult> Create(CustomerQuote customerQuote)
        {
            if (ModelState.IsValid)
            {
                db.CustomerQuotes.Add(customerQuote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", customerQuote);
            }

            return View(customerQuote);
        }

        // GET: CustomerQuotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {

            var customerquotes = db.CustomerQuotes.SingleOrDefault(c => c.CustomerQuoteId == id);

            var customers = db.Customers.ToList();
            var customerdivisions = db.CustomerDivisions.ToList();
            var mlsdivisions = db.MlsDivisions.ToList();
            var cqstatus = db.CQStatuses.ToList();

            var viewModel = new SaveCustomerQuotesViewModel()
            {
                CustomerQuote = customerquotes,
                Customers = customers,
                CustomerDivisions = customerdivisions,
                MlsDivisions = mlsdivisions,
                CQStatuses = cqstatus
            };
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerQuote customerQuote = await db.CustomerQuotes.FindAsync(id);
            if (customerQuote == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(customerQuote);
        }

        // POST: CustomerQuotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "CustomerQuoteId,Pn,QuoteDate,QuotedPrice,PriceBreak,Tariff,Terms,QuoteBy,Notes")] CustomerQuote customerQuote)
        public async Task<ActionResult> Edit(CustomerQuote customerQuote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerQuote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", customerQuote);
            }
            return View(customerQuote);
        }

        // GET: CustomerQuotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerQuote customerQuote = await db.CustomerQuotes.FindAsync(id);
            if (customerQuote == null)
            {
                return HttpNotFound();
            }
            return View(customerQuote);
        }

        // POST: CustomerQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerQuote customerQuote = await db.CustomerQuotes.FindAsync(id);
            db.CustomerQuotes.Remove(customerQuote);
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
