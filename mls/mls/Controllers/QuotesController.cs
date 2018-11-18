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
    public class QuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quotes
        public async Task<ActionResult> Index()
        {
            return View(await db.Quotes.ToListAsync());
        }

        // GET: Quotes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            var suppliers = db.Suppliers.ToList();

            var viewModel = new SaveQuoteViewModel()
            {

                Suppliers = suppliers
            };

            return View("Create", viewModel);

            //return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "QuoteId,Pn,SupplierId,QuoteDate,QuotedPrice,PriceBreak,Tariff,Terms,QuoteBy,Notes")] Quote quote)
        public async Task<ActionResult> Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Quotes.Add(quote);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", quote);
            }

            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            var quotes = db.Quotes.SingleOrDefault(c => c.QuoteId == id);

            var suppliers = db.Suppliers.ToList();

            var viewModel = new SaveQuoteViewModel()
            {
                Quote = quotes,
                Suppliers = suppliers
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View("Edit", viewModel);
            //return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "QuoteId,Pn,SupplierId,QuoteDate,QuotedPrice,PriceBreak,Tariff,Terms,QuoteBy,Notes")] Quote quote)
        public async Task<ActionResult> Edit(Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", quote);
            }
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quote quote = await db.Quotes.FindAsync(id);
            db.Quotes.Remove(quote);
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
