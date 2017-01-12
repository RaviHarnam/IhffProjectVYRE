using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using IHFF.Helpers;
using IHFF.Models.Input;

namespace IHFF.Controllers
{
    public class MoviesController : Controller
    {
        private IMoviesRepository dbMovie = new DbMovieRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        MakeEventHelper eventHelper = MakeEventHelper.GetInstance();

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
        public ActionResult MovieOverview(int? voorstellingId, Movie mInput, string button)
        {

            if (ModelState.IsValid)
            {
                eventHelper.MakeEvent(voorstellingId.Value, mInput.Moviebestellinginputmodel.Aantal, button);
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
        public ActionResult MovieDetailPage(int? voorstellingId, Movie mInput, string button)
        {
            if (voorstellingId != null)
            {
                if (ModelState.IsValid)
                {
                    eventHelper.MakeEvent(voorstellingId.Value, mInput.Moviebestellinginputmodel.Aantal, button);
                }
                Movie m = dbMovie.GetMovieByVoorstellingID(voorstellingId.Value);
                return View(m);
            }
            return RedirectToAction("MovieOverview");
        }

    }
}