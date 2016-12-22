
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
            return View();
        }

        public ActionResult MovieOverview()
        {
            IEnumerable<Movie> movies = dbMovie.GetAllMovies();
            return View(movies);
        }

        public ActionResult MovieDetailPage(int? movie_id)
        {
            if (movie_id != null)
            {
                Movie movie = dbMovie.GetMovie(movie_id.Value);
                if (movie != null)
                {
                    movie.MakeViewmodel();
                    movie.movieEvent = new Event();
                    return View(movie);
                }
            }
            return RedirectToAction("MovieOverview");
        }

        [HttpPost]
        public ActionResult MovieDetailPage(Movie movie)
        {
            if (ModelState.IsValid)
            {
                Event eventx = new Event();
                eventx.DatumTijd = movie.movieEvent.DatumTijd;
                eventx.Aantal = movie.movieEvent.Aantal;
                eventx.Prijs = dbVoorstelling.GetVoorstelling(movie.ItemID, movie.movieEvent.DatumTijd).Prijs;
                eventx.Titel = movie.Titel;

                if (Session["cart"] == null)
                    Session["cart"] = new List<Event>();

                List<Event> cartlist = (List<Event>)Session["cart"];
                cartlist.Add(eventx);
                Session["cart"] = cartlist;

            }

            return View(dbMovie.GetMovie(movie.ItemID));
        }
    }
}