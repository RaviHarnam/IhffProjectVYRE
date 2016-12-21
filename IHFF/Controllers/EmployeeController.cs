using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;
using IHFF.Repositories;
using System.Web.Security;
using IHFF.Models.Input;

namespace IHFF.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository db = new DbEmployeeRepository();
        // GET: Employee

        public ActionResult Index()
        {
            return View("LogIn");
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
                    ModelState.AddModelError("login-error", "The username and/or password provided is incorrect.");
            }
            return View(emp);
        }
        [Authorize]
        public ActionResult ManagementWindow()
        {
            IEnumerable<EventListRepresentation> events = db.GetAllEvents();
            return View(events);
        }
        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
        [Authorize]
        public ActionResult EditMovie(int? id)
        {
            //Get Movie
            if (id != null)
            {
                Movie movie = db.GetMovie(id.Value);
                if(movie != null)
                return View(movie);
            }
            return RedirectToAction("ManagementWindow");

        }
        [Authorize]
        public ActionResult EditSpecial(int id)
        {
            //Get Special
            Special special = db.GetSpecial(id);
            if (special == null)
                return RedirectToAction("ManagementWindow");
            return View(special);
        }
        [Authorize]
        public ActionResult EditMuseum(int id)
        {
            //Get Museum
            Museum museum = db.GetMuseum(id);
            if (museum == null)
                return RedirectToAction("ManagementWindow");
            return View(museum);
        }
        [Authorize]
        public ActionResult EditRestaurant(int id)
        {
            //Get Restaurant
            Restaurant restaurant = db.GetRestaurant(id);
            if (restaurant == null)
                return RedirectToAction("ManagementWindow");
            return View(restaurant);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Movie movToEdit = db.GetMovie(movie.ItemID);
                movToEdit.Edit(movie);
                db.UpdateMovie(movToEdit);
            }
            else
                ModelState.AddModelError("Edit-error", "The Movie you tried to edit had some incorrectly filled fields.");
            return View(movie);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditSpecial(Special special)
        {
            if (ModelState.IsValid)
                db.UpdateSpecial(special);
            else
                ModelState.AddModelError("edit-error", "The Special you tried to edit had some incorrectly filled fields.");
            return View(special);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                Restaurant rstToEdit = db.GetRestaurant(restaurant.RestaurantID);
                rstToEdit.Edit(restaurant);
                db.UpdateRestaurant(rstToEdit);
            }
            else
                ModelState.AddModelError("edit-error", "The Restaurant you tried to edit had some incorrectly filled fields.");
            return View(restaurant);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditMuseum(Museum museum)
        {
            if (ModelState.IsValid)
                db.UpdateMuseum(museum);
            else
                ModelState.AddModelError("edit-error", "The Museum you tried to edit had some incorrectly filled fields.");
            return View(museum);
        }
    }

}
