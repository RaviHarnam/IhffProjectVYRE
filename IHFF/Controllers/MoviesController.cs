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
        IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();

        // GET: Movies
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
        public ActionResult MovieOverview(int? voorstellingId, Movie movie, string aantal)
        {
            if (ModelState.IsValid)
            {
                int amount = 0;
                if (voorstellingId != null && int.TryParse(aantal, out amount) && movie != null)
                {
                    if (amount > 0)
                    {
                        Event eventx = movie.GetEvent(voorstellingId.Value);
                        eventx.Aantal = amount;
                        if (Session["cart"] == null)
                            Session["cart"] = new List<Event>();

                        List<Event> cartlist = (List<Event>)Session["cart"];
                        cartlist.Add(eventx);
                        Session["cart"] = cartlist;

                        //movie = dbMovie.GetMovie(movie.ItemID);
                        //movie.Voorstellingen = dbVoorstelling.GetVoorstellingen(movie.ItemID);
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
        public ActionResult MovieDetailPage(Movie movie, int voorstellingId)
        {
            Event eventx = movie.GetEvent(voorstellingId);

            if (Session["cart"] == null)
                Session["cart"] = new List<Event>();

            List<Event> cartlist = (List<Event>)Session["cart"];
            cartlist.Add(eventx);
            Session["cart"] = cartlist;

            movie = dbMovie.GetMovie(movie.ItemID);
            movie.Voorstellingen = dbVoorstelling.GetVoorstellingen(movie.ItemID);

            return View(movie);
        }
    }
}