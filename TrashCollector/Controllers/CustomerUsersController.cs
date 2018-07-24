using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using TrashCollector.ViewModels;

namespace TrashCollector.Controllers
{
    public class CustomerUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: CustomerUsers
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            CustomerUsers customer = db.CustomerUsers.Where(c => c.UserId == currentUserId).First();
            var ViewModel = new CustomerUsersIndexViewModel
            {
                Customer = customer,
                CustomerPickUps = db.PickUps.ToList().Where(c => c.CustomerId == customer.CustomerId && c.Completed == false).AsEnumerable()
            };
            return View(ViewModel);
        }

        // GET: CustomerUsers/Details/5
        public ActionResult Details(int id)
        {
            CustomerUsers customer = db.CustomerUsers.Where(c => c.CustomerId == id).First();
            return View(customer);
        }

        //GET: CustomerUsers/Create
        //public ViewResult Create(ApplicationUser newUser)
        //{
        //    IEnumerable<CustomerUsers> newCustomer 
        //    {
        //        UserId = User.Identity.GetUserId(),
        //        FirstName = newUser.FirstName,
        //        LastName = newUser.LastName,
        //        PhoneNumber = newUser.PhoneNumber
        //    };

        //    return View(newCustomer);
        //}

        //POST: CustomerUsers/Create
       //[HttpPost]
       //[ValidateAntiForgeryToken]
       [ActionName("Create")]
        public ActionResult CreatePost([Bind (Include = "FirstName,LastName,PhoneNumber,UserId")] ApplicationUser newUser)
        {
            if (ModelState.IsValid)
            {
                CustomerUsers newCustomer = new CustomerUsers()
                {
                    UserId = User.Identity.GetUserId(),
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    PhoneNumber = newUser.PhoneNumber,
                };

                db.CustomerUsers.Add(newCustomer);
                db.SaveChanges();

                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == newCustomer.UserId);

                var ViewModel = new CustomerUsersCreateViewModel
                {
                    Customer = newCustomer,
                    AppUser = currentUser
                };
                return View("Create", ViewModel);
            }

            return RedirectToAction("Index", "Home", newUser);
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
