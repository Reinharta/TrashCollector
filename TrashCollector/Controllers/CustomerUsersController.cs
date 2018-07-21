using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }

        // GET: CustomerUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: CustomerUsers/Create
        public ViewResult Create(ApplicationUser newUser)
        {

            return View(newUser);
        }

        //POST: CustomerUsers/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       [ActionName("Create")]
        public ActionResult CreatePost([Bind (Include = "FirstName,LastName,PhoneNumber,UserId")] ApplicationUser newUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CustomerUsers newCustomer = new CustomerUsers()
                    {
                        UserId = User.Identity.GetUserId(),
                        FirstName = newUser.FirstName,
                        LastName = newUser.LastName,
                        PhoneNumber = newUser.PhoneNumber
                    };
                    db.CustomerUsers.Add(newCustomer);
                    db.SaveChanges();
                    return RedirectToAction("Index", newCustomer);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
