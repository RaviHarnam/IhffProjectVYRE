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
        private IItemRepository dbMovie = new DbItemRepository();
        private IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
      
        public ActionResult Index()
        {
            return View("MovieOverview");
        }

        public ActionResult MovieOverviewByDay(int dag)
        {
            IEnumerable<Movie> movies = dbMovie.getMoviesByDay(dag);

            if (!movies.Any())
            {
                return View(); // view dat zegt dat er geen films op die dag draaien
            }
            else
            {
                return View("MovieOverview", movies); // hier kun je gewoon naar MovieOverview verwijzen
            }   

        }
        public ActionResult MovieOverview() // haal alle films op en zet ze in een overview
        {
            IEnumerable<Movie> movies = dbMovie.GetAllMovies();
            return View(movies);
        }

        [HttpPost]
        public ActionResult MovieOverview(int? voorstellingId, int Aantal) // post een movie naar de cart vanuit movieoverview dmv input model en eventHelper listType geeft aan om welke lijst het gaat (wishlist of cart)
        {
            if (ModelState.IsValid)
            {
                
                Cart cart = new Cart();
                cart.AddItem(voorstellingId, Aantal); // returned een cart object en geeft dit mee aan de sessie
                
            }
            return RedirectToAction("MovieOverview");
        }


        public ActionResult MovieDetailPage(int movie_id) // haal een specifieke film op zet hem op detailpage
        {
            

                Movie movie = dbMovie.GetMovie(movie_id); // haalt movie op met movie_id (movie waarop geklikt is) en zet deze in movieobject
                if (movie != null)
                {
                    movie.Voorstellingen = (dbVoorstelling.GetVoorstellingen(movie.ItemID));
                    return View(movie); // als een film is ophehaald geef die dan aan de view terug.
                }
            
            return RedirectToAction("MovieOverview"); //mocht deze niet opgehaald zijn ga dan terug naar action MovieOverview en haal dan alle films weer op.
        }

        [HttpPost]
        public ActionResult MovieDetailPage(int voorstellingId, int Aantal) // Deze actionresult zorgt ervoor dat er vanaf de detailpage een film in de cart gedaan kan worden
        {

                if (ModelState.IsValid)
                {
                    Cart cart = new Cart();
                    cart.AddItem(voorstellingId, Aantal);
                }
                Movie movie = dbMovie.GetMovieByVoorstellingID(voorstellingId); // als de movie niet geadd is aan de cart haal dan weer dezelfde movie op om deze weer te tonen in de view
                return View(movie); // als de film dus correct is opgehaald, dan wordt hij aan de view MovieDetailPage gegeven en in die view geladen
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditMovie(MovieInputModel movie)
        {
            if (ModelState.IsValid) //Alles goed ingevuld
            {
                Movie movToEdit = dbMovie.GetMovie(movie.ItemID);
                movToEdit.ConvertFromMovieInputModel(movie); //Maken van Movie van input model
                dbMovie.UpdateMovie(movToEdit);
            }
            else
                ModelState.AddModelError("Edit-error", "The Movie you tried to edit had some incorrectly filled fields.");
            return View(movie);
        }

    }
}