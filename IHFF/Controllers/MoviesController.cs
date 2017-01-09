using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;


namespace IHFF.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesRepository dbMovie = new DbMovieRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();

        public ActionResult Index()
        {
            return View("MovieOverview");
        }

        public ActionResult MovieOverview()
        {
            IEnumerable<Movie> movies = dbMovie.GetAllMovies();
            return View(movies);
        }

        [HttpPost]
        public ActionResult MovieOverview(int? voorstellingId, Movie movie, string aantal, string button)
        {
            
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && movie != null)
                {
                    if (amount > 0)
                    {
                        
                        Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId.Value);
                        
                        if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
                        {
                            Event eventx = new Event();
                            Movie m = dbMovie.GetMovie(v.ItemID);
                            eventx.Aantal = amount;
                            eventx.DatumTijd = v.BeginTijd;
                            eventx.Prijs = v.Prijs;
                            eventx.Titel = m.Titel;
                            eventx.VoorstellingID = v.VoorstellingID;
                            //Event eventx = movie.GetEvent(voorstellingId.Value);
                            //eventx.Aantal = amount;
                            if (Session[button] == null)
                                Session[button] = new List<Event>();

                            List<Event> cartlist = (List<Event>)Session[button];
                            cartlist.Add(eventx);
                            Session[button] = cartlist;
                        }                  
                    }                   
                }
            }
            return RedirectToAction("MovieOverview");
        }




        public ActionResult MovieDetailPage(int? movie_id)
        {
            if (movie_id != null)
            {
                Movie movie = dbMovie.GetMovie(movie_id.Value);
                if (movie != null)
                {
                    movie.Voorstellingen = (dbVoorstelling.GetVoorstellingen(movie.ItemID));
                    return View(movie);
                }
            }
            return RedirectToAction("MovieOverview");
        }

        [HttpPost]
        public ActionResult MovieDetailPage(int? voorstellingId, Movie movie, string aantal, string button)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && movie != null)
                {
                    if (amount > 0)
                    {

                        Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId.Value);

                        if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
                        {
                            Event eventx = new Event();
                            Movie m = dbMovie.GetMovie(v.ItemID);
                            eventx.Aantal = amount;
                            eventx.DatumTijd = v.BeginTijd;
                            eventx.Prijs = v.Prijs;
                            eventx.Titel = m.Titel;
                            eventx.VoorstellingID = v.VoorstellingID;
                            //Event eventx = movie.GetEvent(voorstellingId.Value);
                            //eventx.Aantal = amount;
                            if (Session[button] == null)
                                Session[button] = new List<Event>();

                            List<Event> cartlist = (List<Event>)Session[button];
                            cartlist.Add(eventx);
                            Session[button] = cartlist;
                        }

                    }
                }

            }
            movie = dbMovie.GetMovie(movie.ItemID);
            movie.Voorstellingen = dbVoorstelling.GetVoorstellingen(movie.ItemID);
            return View(movie);
        }

        //[HttpPost]
        //[ActionName("MovieDetailPage")]
        //public ActionResult MovieDetailPagee(Movie movie, int voorstellingId)
        //{
        //    Event eventx = movie.GetEvent(voorstellingId);

        //    if (Session["wishlist"] == null)
        //        Session["wishlist"] = new List<Event>();

        //    List<Event> wishList = (List<Event>)Session["wishlist"];
        //    wishList.Add(eventx);
        //    Session["wishlist"] = wishList;

        //    movie = dbMovie.GetMovie(movie.ItemID);
        //    movie.Voorstellingen = dbVoorstelling.GetVoorstellingen(movie.ItemID);

        //    return View(movie);
        //}
    }
}