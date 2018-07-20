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

namespace TrashCollector.Controllers
{
    public class CustomerUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerUsers
        public ActionResult Index()
        {
            return View(db.CustomerUsers.ToList());
        }

        // GET: CustomerUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerUsers customerUsers = db.CustomerUsers.Find(id);
            if (customerUsers == null)
            {
                return HttpNotFound();
            }
            return View(customerUsers);
        }

        // GET: CustomerUsers/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CustomerUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "UserRole")] ApplicationUser newUser)
        {//may need to exclude aspNet id from Bind
            if (ModelState.IsValid)
            {
                CustomerUsers newCustomerUser = new CustomerUsers()
                {
                    Id = User.Identity.GetUserId(),
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PhoneNumber = newUser.PhoneNumber,
                    AddressId = db.Addresses.Where(c => c.StreetAddress == newUser.StreetAddress && c.Zipcode == newUser.Zipcode).First().Id,

                };
                db.CustomerUsers.Add(newCustomerUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: CustomerUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerUsers customerUsers = db.CustomerUsers.Find(id);
            if (customerUsers == null)
            {
                return HttpNotFound();
            }
            return View(customerUsers);
        }

        // POST: CustomerUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,UserId,FirstName,LastName,Address,PhoneNumber")] CustomerUsers customerUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerUsers);
        }

        // GET: CustomerUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerUsers customerUsers = db.CustomerUsers.Find(id);
            if (customerUsers == null)
            {
                return HttpNotFound();
            }
            return View(customerUsers);
        }

        // POST: CustomerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerUsers customerUsers = db.CustomerUsers.Find(id);
            db.CustomerUsers.Remove(customerUsers);
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
