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
        INewsMessageRepository dbNews = new DbNewsMessageRepository();
        // GET: Employee

        public ActionResult Index()
        {
            //Doorverwijzen naar managementwindow als gebruiker al ingelogd is
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated && Session["loggedin_employee"] != null)
                return RedirectToAction("ManagementWindow");
            return View("LogIn"); //Gaan naar inlogPagina

        }
        public ActionResult LogIn()
        {
            //Doorverwijzen naar managementwindow als de gebruiker al ingelogd is
            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated && Session["loggedin_employee"] != null)
                return RedirectToAction("ManagementWindow");
            return View(); //Gaan naar inlogpagna
        }
        [HttpPost]
        public ActionResult LogIn(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (db.EmployeeExist(emp))
                {

                    FormsAuthentication.SetAuthCookie(emp.Gebruikersnaam, false); //Maken cookie
                    Session["loggedin_employee"] = emp; //Session met ingelogde gebruiker maken.           
                    return RedirectToAction("ManagementWindow", "Employee");
                }
                else //Gebruiker bestaat niet
                    ModelState.AddModelError("login-error", "The username and/or password provided is incorrect.");
            }
            return View(emp);
        }
        [Authorize]
        public ActionResult ManagementWindow()
        {
            if (Session["loggedin_employee"] == null) //Check of de Session niet bestaat, workaround voor Cookie bug
            {
                FormsAuthentication.SignOut(); //Clear cookie omdat gebruiker niet ingelogd is.(MVC bug)
                return RedirectToAction("LogIn");
            }
            IEnumerable<EventListRepresentation> events = db.GetAllEvents(); //Session is niet leeg dus kunnen we doorgaan
            return View(events);
        }
        [HttpPost]
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut(); //Uitloggen          
            Session["loggedin_employee"] = null; //Session leegmaken
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult EditMovie(int? id)
        {
            //Get Movie
            if (id != null)
            {
                Movie movie = db.GetMovie(id.Value);
                if (movie != null)
                {
                    MovieInputModel mov = new MovieInputModel();
                    mov.ConvertToMovieInputModel(movie);
                    return View(mov);
                }
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
                if (special != null)
                {
                    SpecialInputModel spc = new SpecialInputModel();
                    spc.ConvertToSpecialInputModel(special);
                    return View(spc);
                }
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
                if (museum != null)
                {
                    MuseumInputModel mus = new MuseumInputModel();
                    mus.ConvertToMuseumInputModel(museum);
                    return View(mus);
                }
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
                if (restaurant != null)
                {
                    RestaurantInputModel rst = new RestaurantInputModel();
                    rst.ConvertToRestaurantInputModel(restaurant);
                    return View(rst);
                }
            }
            return RedirectToAction("ManagementWindow");
        }

        public ActionResult EditHotel(int? id)
        {
            if (id != null)
            {
                Hotel hotel = db.GetHotel(id.Value);
                HotelInputModel hotelInputModel = new HotelInputModel(hotel);
                return View(hotelInputModel);
            }
            return RedirectToAction("ManagementWindow");
        }

        public ActionResult EditNews(int? id)
        {
            if(id != null)
            {
                NewsMessage msg = db.GetNewsMessage(id.Value);
                return View(msg);
            }
            return RedirectToAction("ManagementWindow");
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditMovie(MovieInputModel movie)
        {
            if (ModelState.IsValid) //Alles goed ingevuld
            {
                Movie movToEdit = db.GetMovie(movie.ItemID);
                movToEdit.ConvertFromMovieInputModel(movie); //Maken van Movie van input model
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
                spcToEdit.ConvertFromSpecialInputModel(special); //Make special from input model
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
                rstToEdit.ConvertFromRestaurantInputModel(restaurant); //Make restaurant from input model              
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
                musToEdit.ConvertFromMuseumInputModel(museum); //Make museum from input model
                db.UpdateMuseum(musToEdit);
            }
            else
                ModelState.AddModelError("edit-error", "The Museum you tried to edit had some incorrectly filled fields.");
            return View(museum);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditHotel(HotelInputModel hotel)
        {

            if (ModelState.IsValid)
            {
                Hotel hotelToEdit = db.GetHotel(hotel.HotelId);
                hotelToEdit.ConvertFromInputModel(hotel);
                db.UpdateHotel(hotelToEdit);
            }
            else
            {
                ModelState.AddModelError("edit-error", "The Hotel you tried to edit had some incorrectly filled fields.");
            }
            return View(hotel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditNews(NewsMessage msg)
        {
            if (ModelState.IsValid && db.GetNewsMessage(msg.Id) != null)
            {
                db.UpdateNews(msg);
            }
            else
                ModelState.AddModelError("edit-error", "The News message you tried to edit had some incorrectly filled fields.");

            return View(msg);
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
        [Authorize]
        [HttpPost]
        public ActionResult DeleteHotel(int? id)
        {
            if (id != null)
                db.DeleteHotel(id.Value);
            return RedirectToAction("ManagementWindow");
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteNews(int? id)
        {
            if (id != null)
                db.DeleteNews(id.Value);
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
        public ActionResult AddMovie(MovieInputModel m, string afbLink, string afbLinkOverview)
        {
            if (ModelState.IsValid)
            {
                Movie mov = new Movie();
                mov.ConvertFromAddInputModel(m); //Maak een Movie van de input
                mov.ItemAfbeelding = new Afbeelding(mov.ItemID, null, null, afbLink, "filmbanner");
                mov.OverviewAfbeelding = new Afbeelding(mov.ItemID, null, null, afbLinkOverview, "filmoverview");
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
        public ActionResult AddSpecial(SpecialInputModel s, string afbLink, string afbLinkOverview)
        {
            if (ModelState.IsValid)
            {
                Special spc = new Special();
                spc.ConvertFromSpecialInputModel(s); //Maak een Special van de input
                spc.ItemAfbeelding = new Afbeelding(spc.ItemID, null, null, afbLink, "specialbanner");
                spc.OverviewAfbeelding = new Afbeelding(spc.ItemID, null, null, afbLinkOverview, "specialoverview");
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
        public ActionResult AddMuseum(MuseumInputModel m, string afbLink, string afbLinkOverview)
        {
            m.MuseumLocatie.Naam = m.Naam;
            if (ModelState.IsValid)
            {
                Museum mus = new Museum();

                mus.ConvertFromAddInputModel(m);
                m.MuseumLocatie.Naam = m.Naam;
                mus.MuseumAfbeelding = new Afbeelding(null, mus.MuseumID, null, afbLink, "museumbanner");
                mus.OverviewAfbeelding = new Afbeelding(null, mus.MuseumID, null, afbLinkOverview, "museumoverview");

                mus.MuseumLocatie = m.MuseumLocatie;
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
        public ActionResult AddRestaurant(RestaurantInputModel r, string afbLink, string afbLinkOverview)

        {
            if (ModelState.IsValid)
            {
                Restaurant rst = new Restaurant();
                rst.ConvertFromAddInputModel(r); //Maken van een Restaurant van input model
                r.RestaurantLocatie.Naam = r.Naam;
                rst.RestaurantAfbeelding = new Afbeelding(null, null, rst.RestaurantID, afbLink, "restaurantbanner");
                rst.OverviewAfbeelding = new Afbeelding(null, null, rst.RestaurantID, afbLinkOverview, "restaurantoverview");
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

        [Authorize]
        public ActionResult AddNews()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddNews(NewsMessage msg)
        {
            if (ModelState.IsValid)
            {
                msg.TimeOfPost = DateTime.Now;
                db.AddNews(msg);

            }
            return RedirectToAction("ManagementWindow");
        }
    }

}
