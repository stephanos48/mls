﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mls.Models;

namespace mls.Controllers
{
    [Authorize]
    public class SupplierContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupplierContacts
        public ActionResult Index()
        {
            var supplierContacts = db.SupplierContacts.Include(s => s.Suppliers);
            return View(supplierContacts.ToList());
        }

        // GET: SupplierContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierContact supplierContact = db.SupplierContacts.Find(id);
            if (supplierContact == null)
            {
                return HttpNotFound();
            }
            return View(supplierContact);
        }

        // GET: SupplierContacts/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: SupplierContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierContactId,SupplierContactName,SupplierContactTitle,SupplierContactCell,SupplierContactPhone,SupplierContactFax,SupplierContactEmail,Notes,SupplierId")] SupplierContact supplierContact)
        {
            if (ModelState.IsValid)
            {
                db.SupplierContacts.Add(supplierContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", supplierContact.SupplierId);
            return View(supplierContact);
        }

        // GET: SupplierContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierContact supplierContact = db.SupplierContacts.Find(id);
            if (supplierContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", supplierContact.SupplierId);
            return View(supplierContact);
        }

        // POST: SupplierContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierContactId,SupplierContactName,SupplierContactTitle,SupplierContactCell,SupplierContactPhone,SupplierContactFax,SupplierContactEmail,Notes,SupplierId")] SupplierContact supplierContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", supplierContact.SupplierId);
            return View(supplierContact);
        }

        // GET: SupplierContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierContact supplierContact = db.SupplierContacts.Find(id);
            if (supplierContact == null)
            {
                return HttpNotFound();
            }
            return View(supplierContact);
        }

        // POST: SupplierContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierContact supplierContact = db.SupplierContacts.Find(id);
            db.SupplierContacts.Remove(supplierContact);
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
