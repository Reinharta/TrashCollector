using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using TrashCollector.ViewModels;

namespace TrashCollector.Controllers
{
    public class BillingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Billings
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            CustomerUsers customer = db.CustomerUsers.Where(c => c.UserId == currentUserId).First();

            var ViewModel = new BillingIndexViewModel()
            {
                Customer = customer,
                CustomerBills = db.Billing.Where(c => c.CustomerId == customer.CustomerId && c.Paid == false).AsEnumerable(),
                CustomerPickUps = db.PickUps.Where(c => c.CustomerId == customer.CustomerId && c.Completed == true).ToList()
            };

            //var billing = db.Billing.Include(b => b.Customers).Include(b => b.PickUps);
            return View(ViewModel);
        }

        // GET: Billings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // GET: Billings/Create
        public ActionResult Create(PickUps pickUp)
        {
            ViewBag.CustomerId = pickUp.CustomerId;   //new SelectList(db.CustomerUsers, "CustomerId", "UserId");
            ViewBag.PickUpId = pickUp.PickUpId;   //new SelectList(db.PickUps, "PickUpId", "StreetAddress");
            ViewBag.Fee = 35.00;
            ViewBag.PickUpDate = pickUp.PickUpDate;
            ViewBag.CustFirstName = db.CustomerUsers.Where(c => c.CustomerId == pickUp.CustomerId).First().FirstName;
            ViewBag.CustLastName = db.CustomerUsers.Where(c => c.CustomerId == pickUp.CustomerId).First().LastName;
            return View();
        }

        // POST: Billings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransactionId,PickUpId,PickUpDate,CustomerId,Fee,Paid")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                billing.Fee = 35;
                db.Billing.Add(billing);
                db.SaveChanges();
                PickUps completedPickUp = db.PickUps.Where(c => c.PickUpId == billing.PickUpId).First();
                if (completedPickUp.Recurring == true)
                {
                    return RedirectToAction("Create", "PickUps", completedPickUp);
                }
                return RedirectToAction("Index", "EmployeeUsers");
            }

            ViewBag.CustomerId = new SelectList(db.CustomerUsers, "CustomerId", "UserId", billing.CustomerId);
            ViewBag.PickUpId = new SelectList(db.PickUps, "PickUpId", "StreetAddress", billing.PickUpId);
            return View(billing);
        }

        // GET: Billings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CustomerUsers, "CustomerId", "UserId", billing.CustomerId);
            ViewBag.PickUpId = new SelectList(db.PickUps, "PickUpId", "StreetAddress", billing.PickUpId);
            return View(billing);
        }

        // POST: Billings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransactionId,PickUpId,CustomerId,Fee,Paid")] Billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CustomerUsers, "CustomerId", "UserId", billing.CustomerId);
            ViewBag.PickUpId = new SelectList(db.PickUps, "PickUpId", "StreetAddress", billing.PickUpId);
            return View(billing);
        }

        // GET: Billings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Billing billing = db.Billing.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: Billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Billing billing = db.Billing.Find(id);
            db.Billing.Remove(billing);
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
