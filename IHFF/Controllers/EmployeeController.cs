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
                    return RedirectToAction("ManagementWindow");
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
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}