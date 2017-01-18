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
        

        public ActionResult Index()
        {
            return View("MovieOverview");
        }

        public ActionResult MovieOverview() // haal alle films op en zet ze in een overview
        {
            IEnumerable<Movie> movies = dbMovie.GetAllMovies();
            return View(movies);
        }

        [HttpPost]
        public ActionResult MovieOverview(int? voorstellingId, Movie mInput, string button) // post een movie naar de cart vanuit movieoverview dmv input model en eventHelper
        {

            if (ModelState.IsValid)
            {
                MakeEventHelper.MakeEvent(voorstellingId.Value, mInput.Moviebestellinginputmodel.Aantal, button);
            }
            return RedirectToAction("MovieOverview");
        }


        public ActionResult MovieDetailPage(int? movie_id) // haal een specifieke film op zet hem op detailpage
        {
            if (movie_id != null)
            {
                Movie movie = dbMovie.GetMovie(movie_id.Value); // checkt of de movie met het gegeven id wel bestaat
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
                    MakeEventHelper.MakeEvent(voorstellingId.Value, mInput.Moviebestellinginputmodel.Aantal, button);
                }
                Movie movie = dbMovie.GetMovieByVoorstellingID(voorstellingId.Value);
                return View(movie);
            }
            return RedirectToAction("MovieOverview");
        }

    }
}