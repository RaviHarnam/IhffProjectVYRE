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
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("ManagementWindow");
            return View("LogIn");

        }
        public ActionResult LogIn()
        {
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                return RedirectToAction("ManagementWindow");
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
                MovieInputModel mov = new MovieInputModel();
                mov.ConvertToMovieInputModel(movie);
                if (mov != null)
                    return View(mov);
            }
            return RedirectToAction("ManagementWindow");

        }
        [Authorize]
        public ActionResult EditSpecial(int? id)
        {
            //Get Special
            if (id != null)
            {
                Special special = db.GetSpecial(id.Value);
                SpecialInputModel spc = new SpecialInputModel();
                spc.ConvertToSpecialInputModel(special);
                if (spc != null)
                    return View(spc);
            }
            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        public ActionResult EditMuseum(int? id)
        {
            //Get Museum
            if (id != null)
            {
                Museum museum = db.GetMuseum(id.Value);
                MuseumInputModel mus = new MuseumInputModel();
                mus.ConvertToMuseumInputModel(museum);
                return View(mus);
            }
            return RedirectToAction("ManagementWindow");

        }
        [Authorize]
        public ActionResult EditRestaurant(int? id)
        {
            //Get Restaurant
            if (id != null)
            {
                Restaurant restaurant = db.GetRestaurant(id.Value);
                RestaurantInputModel rst = new RestaurantInputModel();
                rst.ConvertToRestaurantInputModel(restaurant);
                return View(rst);
            }
            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditMovie(MovieInputModel movie)
        {
            if (ModelState.IsValid)
            {
                Movie movToEdit = db.GetMovie(movie.ItemID);
                movToEdit.ConvertFromMovieInputModel(movie);
                //movToEdit.Edit(movToEdit);
                db.UpdateMovie(movToEdit);
            }
            else
                ModelState.AddModelError("Edit-error", "The Movie you tried to edit had some incorrectly filled fields.");
            return View(movie);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditSpecial(SpecialInputModel special)
        {
            if (ModelState.IsValid)
            {
                Special spcToEdit = db.GetSpecial(special.ItemID);
                spcToEdit.ConvertFromSpecialInputModel(special);
                //spcToEdit.Edit(spcToEdit);
                db.UpdateSpecial(spcToEdit);
            }
            else
                ModelState.AddModelError("edit-error", "The Special you tried to edit had some incorrectly filled fields.");
            return View(special);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditRestaurant(RestaurantInputModel restaurant)
        {
            if (ModelState.IsValid)
            {
                Restaurant rstToEdit = db.GetRestaurant(restaurant.RestaurantID);
                rstToEdit.ConvertFromRestaurantInputModel(restaurant);
                //rstToEdit.Edit(restaurant);
                db.UpdateRestaurant(rstToEdit);
            }
            else
                ModelState.AddModelError("edit-error", "The Restaurant you tried to edit had some incorrectly filled fields.");
            return View(restaurant);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditMuseum(MuseumInputModel museum)
        {
            if (ModelState.IsValid)
            {
                Museum musToEdit = db.GetMuseum(museum.MuseumID);
                musToEdit.ConvertFromMuseumInputModel(museum);
                //musToEdit.Edit(musToEdit);
                db.UpdateMuseum(musToEdit);
            }
            else
                ModelState.AddModelError("edit-error", "The Museum you tried to edit had some incorrectly filled fields.");
            return View(museum);
        }
        // Deleten van events
        [Authorize]
        public ActionResult DeleteMuseum(int? id)
        {
            if (id != null)
                db.DeleteMuseum(id.Value);

            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteMovie(int? id)
        {
            if (id != null)
                db.DeleteMovie(id.Value);
            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteSpecial(int? id)
        {
            if (id != null)
                db.DeleteSpecial(id.Value);
            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteRestaurant(int? id)
        {
            if (id != null)
                db.DeleteRestaurant(id.Value);
            return RedirectToAction("ManagementWindow");
        }
        // Toevoegen van events
        [Authorize]
        public ActionResult AddMovie()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddMovie(MovieInputModel m, string afbLink)
        {
            if (ModelState.IsValid)
            {
                Movie mov = new Movie();
                mov.ConvertFromAddInputModel(m);
                mov.ItemAfbeelding = new Afbeelding(mov.ItemID, null, null, afbLink, "filmbanner");
                db.AddMovie(mov);
                return RedirectToAction("ManagementWindow");
            }
            return View(m);
        }

        [Authorize]
        public ActionResult AddSpecial()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddSpecial(SpecialInputModel s, string afbLink)
        {
            if (ModelState.IsValid)
            {
                Special spc = new Special();
                spc.ConvertFromSpecialInputModel(s);
                spc.ItemAfbeelding = new Afbeelding(spc.ItemID, null, null, afbLink, "specialbanner");
                db.AddSpecial(spc);
                return RedirectToAction("ManagementWindow");
            }
            return View(s);
        }

        [Authorize]
        public ActionResult AddMuseum()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddMuseum(MuseumInputModel m, string afbLink)
        {
            m.MuseumLocatie.Naam = m.Naam;
            if (ModelState.IsValid)
            {
                Museum mus = new Museum();
                //Locatie loc = new Locatie();

                //loc.ConvertFromLocatieInputModel(l);
                mus.ConvertFromMuseumInputModel(m);
                m.MuseumLocatie.Naam = m.Naam;
                mus.MuseumAfbeelding = new Afbeelding(null, mus.MuseumID, null, afbLink, "museumbanner");
                mus.MuseumLocatie = m.MuseumLocatie;
                //mus.MuseumLocatie = loc;
                db.AddMuseum(mus);
                return RedirectToAction("ManagementWindow");
            }
            return View(m);
        }

        [Authorize]
        public ActionResult AddRestaurant()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddRestaurant(RestaurantInputModel r, string afbLink)
        {            
            if (ModelState.IsValid)
            {
                Restaurant rst = new Restaurant();
                rst.ConvertFromRestaurantInputModel(r);
                r.RestaurantLocatie.Naam = r.Naam;
                rst.RestaurantAfbeelding = new Afbeelding(null, null, rst.RestaurantID, afbLink, "Restaurantbanner");
                rst.RestaurantLocatie = r.RestaurantLocatie;
                db.AddRestaurant(rst);
                return RedirectToAction("ManagementWindow");
            }
            return View(r);
        }

        [Authorize]
        public ActionResult AddHotel()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddHotel(Hotel h)
        {
            if (ModelState.IsValid)
            {
                h.HotelAfbeelding.Type = "HotelBanner";
                h.HotelOverviewAfbeelding.Type = "HotelOverview";
                db.AddHotel(h);
            }

            return RedirectToAction("ManagementWindow");
        }
    }

}
