﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopSystem.DAL;
using EShopSystem.Models;

namespace EShopSystem.Controllers
{
    public class InvoicesController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.Employee).Include(i => i.PaymentMode);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.PaymentModeId = new SelectList(db.PaymentModes, "PaymentModeId", "PaymentModeName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,InvoiceNumber,InvoiceData,CustomerId,EmployeeId,InvoiceTotal,IsPaid,PaymentModeId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", invoice.EmployeeId);
            ViewBag.PaymentModeId = new SelectList(db.PaymentModes, "PaymentModeId", "PaymentModeName", invoice.PaymentModeId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", invoice.EmployeeId);
            ViewBag.PaymentModeId = new SelectList(db.PaymentModes, "PaymentModeId", "PaymentModeName", invoice.PaymentModeId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,InvoiceNumber,InvoiceData,CustomerId,EmployeeId,InvoiceTotal,IsPaid,PaymentModeId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", invoice.EmployeeId);
            ViewBag.PaymentModeId = new SelectList(db.PaymentModes, "PaymentModeId", "PaymentModeName", invoice.PaymentModeId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
