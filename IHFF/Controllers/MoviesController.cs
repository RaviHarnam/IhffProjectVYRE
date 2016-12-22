
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

        public ActionResult MovieDetailPage(int? movie_id)
        {
            if (movie_id != null)
            {
                Movie movie = dbMovie.GetMovie(movie_id.Value);
                if (movie != null)
                {
                    movie.Voorstellingen = (dbVoorstelling.GetVoorstellingen(movie.ItemID));
                    List<SelectListItem> listItems = new List<SelectListItem>();
                    foreach (DateTime dateTime in movie.Tijden)
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = dateTime.ToString();
                        item.Value = dateTime.ToString();
                        listItems.Add(item);
                    }

                    return View(movie);
                }
            }
            return RedirectToAction("MovieOverview");


        }

        [HttpPost]
        public ActionResult MovieDetailPage(Movie movie, int voorstellingId)
        {
            Voorstelling voorstelling = new Voorstelling();
            voorstelling = dbVoorstelling.GetVoorstelling(voorstellingId);
            movie.Titel = dbMovie.GetMovie(voorstelling.ItemId).Titel;

            if (ModelState.IsValid)
            {
                Event eventx = new Event();
                eventx.MakeEvent(movie, voorstelling);

                if (Session["cart"] == null)
                    Session["cart"] = new List<Event>();

                List<Event> cartlist = (List<Event>)Session["cart"];
                cartlist.Add(eventx);
                Session["cart"] = cartlist;

                movie.Voorstellingen = (dbVoorstelling.GetVoorstellingen(movie.ItemID));
            }

            return View(movie);
        }
    }
}