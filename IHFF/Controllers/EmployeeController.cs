using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;
using System.Web.Security;

namespace IHFF.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository db = new DbEmployeeRepository();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (db.EmployeeExist(emp))
                {
                    FormsAuthentication.SetAuthCookie(emp.Gebruikersnaam, false);
                    Session["loggedin_employee"] = emp;
                    return RedirectToAction("ManagementWindow", "Employee");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The username or password provided is incorrect.");
                }
            }
            return View(emp);
        }
        [Authorize]
        public ActionResult ManagementWindow()
        {
            IEnumerable <EventListRepresentation> events = db.GetAllEvents();
            return View(events);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        public ActionResult EditItem(int id)
        {
            // GEt item
            Item item = db.GetItem(id);
            return View();
        }

        public ActionResult EditCulture(int id)
        {
            // Get Culture
            Culture culture = db.GetCultureEvent(id);
            return View();
        }
        public ActionResult EditRestaurant(int id)
        {
            // Get Restaurant
            Restaurant restaurant = db.GetRestaurant(id);
            return View();
        }
    }
}