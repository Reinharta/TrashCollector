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
    public class EmployeeUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeUsers
        public ActionResult Index()
        {
            return View(db.EmployeeUsers.ToList());
        }

        // GET: EmployeeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUsers employeeUsers = db.EmployeeUsers.Find(id);
            if (employeeUsers == null)
            {
                return HttpNotFound();
            }
            return View(employeeUsers);
        }

        // GET: EmployeeUsers/Create
        public ActionResult Create()
        {
            EmployeeUsers employee = new EmployeeUsers();
            return View(employee);
        }

        // POST: EmployeeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,UserId,Address")] ApplicationUser newUser)
        {
            if (ModelState.IsValid)
            {
                EmployeeUsers newEmployee = new EmployeeUsers()
                {
                   
                    //FirstName = newUser.
                };
                db.EmployeeUsers.Add(newEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(newUser);
        }

        // GET: EmployeeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUsers employeeUsers = db.EmployeeUsers.Find(id);
            if (employeeUsers == null)
            {
                return HttpNotFound();
            }
            return View(employeeUsers);
        }

        // POST: EmployeeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,UserId,Address")] EmployeeUsers employeeUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeUsers);
        }

        // GET: EmployeeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeUsers employeeUsers = db.EmployeeUsers.Find(id);
            if (employeeUsers == null)
            {
                return HttpNotFound();
            }
            return View(employeeUsers);
        }

        // POST: EmployeeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeUsers employeeUsers = db.EmployeeUsers.Find(id);
            db.EmployeeUsers.Remove(employeeUsers);
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
