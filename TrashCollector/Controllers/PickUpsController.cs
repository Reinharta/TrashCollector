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
    public class PickUpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUps
        public ActionResult Index()
        {
            if (User.IsInRole("Customer"))
            {
                CustomerUsers customer = db.CustomerUsers.Where(c => c.UserId == User.Identity.GetUserId().ToString()).First();
                return View(db.PickUps.Where(c => c.CustomerId == customer.CustomerId));
            }

            return View(db.PickUps.ToList());
        }
        public ActionResult SortedIndex (List<PickUps> pickUps)
        {
            return View("Index", pickUps);
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUps pickUps = db.PickUps.Find(id);
            if (pickUps == null)
            {
                return HttpNotFound();
            }
            return View(pickUps);
        }

        // GET: PickUps/Create
        public ActionResult Create(int? customerId, PickUps lastPickUp = null)
        {
            if(lastPickUp != null)
            {
                if (lastPickUp.Recurring == true && lastPickUp.EndDate.Date > DateTime.Today.Date)
                {
                    return RedirectToAction("CreateRecurring", lastPickUp);
                }
            }
            return View();
        }

        public ActionResult CreateRecurring (PickUps lastPickUp)
        {
            DateTime getPickUpDate = GetNextWeekday(lastPickUp.StartDate, lastPickUp.PickUpDay);
            PickUps nextPickUp = new PickUps()
            {
                CustomerId = lastPickUp.CustomerId,
                StreetAddress = lastPickUp.StreetAddress,
                Zipcode = lastPickUp.Zipcode,
                PickUpDay = lastPickUp.PickUpDay,
                PickUpDate = getPickUpDate,
                StartDate = lastPickUp.StartDate,
                EndDate = lastPickUp.EndDate,
                Recurring = lastPickUp.Recurring,
                Completed = false
            };
            db.PickUps.Add(nextPickUp);
            db.SaveChanges();
            return RedirectToAction("Index", "EmployeeUsers");
        }

        // POST: PickUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickUpId,PickUpDay,StartDate,EndDate,Recurring")] PickUps pickUps)
        {
            string currentUserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                CustomerUsers currentCustomer = db.CustomerUsers.Where(c => c.UserId == currentUserId).First();
                DateTime getPickUpDate = GetNextWeekday(pickUps.StartDate, pickUps.PickUpDay);

                pickUps.CustomerId = currentCustomer.CustomerId;
                pickUps.StreetAddress = currentCustomer.User.StreetAddress;
                pickUps.Zipcode = currentCustomer.User.Zipcode;
                pickUps.PickUpDate = getPickUpDate;
                pickUps.Completed = false;
 

                db.PickUps.Add(pickUps);
                db.SaveChanges();
                return RedirectToAction("Index", "PickUps", db.PickUps.Where(c=> c.CustomerId == currentCustomer.CustomerId).ToList());
            }

            return View("Index", "CustomerUsers", currentUserId);
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        // GET: PickUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUps pickUps = db.PickUps.Find(id);
            if (pickUps == null)
            {
                return HttpNotFound();
            }
            return View(pickUps);
        }

        // POST: PickUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StreetAddress,Zipcode,CustomerId,PickUpId,PickUpDay,StartDate,EndDate,Recurring,Completed")] PickUps pickUps)
        {
            string currentUserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                //CustomerUsers currentCustomer = db.CustomerUsers.Where(c => c.CustomerId == pickUps.CustomerId).First();
                DateTime getPickUpDate = GetNextWeekday(pickUps.StartDate, pickUps.PickUpDay);

                PickUps originalPickUp = db.PickUps.Where(c => c.PickUpId == pickUps.PickUpId).First();

                pickUps.PickUpDate = getPickUpDate;
                pickUps.CustomerId = originalPickUp.CustomerId;
                pickUps.Zipcode = originalPickUp.Zipcode;
                pickUps.StreetAddress = originalPickUp.StreetAddress;

                db.Entry(originalPickUp).State = EntityState.Detached;
                db.Entry(pickUps).State = EntityState.Modified;
                db.SaveChanges();

                if(pickUps.Completed == true)
                {
                    return RedirectToAction("Create", "Billings", pickUps);
                }
                else if(pickUps.Completed == false)
                {
                    return RedirectToAction("Index", "PickUps", db.PickUps.ToList());
                }
            }
            return View(pickUps);
        }

        // GET: PickUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUps pickUps = db.PickUps.Find(id);
            if (pickUps == null)
            {
                return HttpNotFound();
            }
            return View(pickUps);
        }

        // POST: PickUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickUps pickUps = db.PickUps.Find(id);
            db.PickUps.Remove(pickUps);
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
