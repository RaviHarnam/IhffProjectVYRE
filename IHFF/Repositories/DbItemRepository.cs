using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.Data.Entity;

namespace IHFF.Repositories
{
    public class DbItemRepository : IItemRepository
    {
        private IhffContext ctx = new IhffContext();
        private DateTime IJKDATUM = new DateTime(2017, 4, 30);

        public IEnumerable<Item> GetAllItems()
        {
            IEnumerable<Item> items = ctx.ITEMS.ToList();
            foreach (Item item in items)
                item.ItemVoorstelling = (from v in ctx.VOORSTELLINGEN
                                         where v.ItemID == item.ItemID
                                         select v).ToList();
            return items;
        }

        public Item GetItem(int itemid)
        {
            Item itm = ctx.ITEMS.SingleOrDefault(i => i.ItemID == itemid);
            return itm;
        }

        public IEnumerable<Highlight> GetAllHighlights()
        {
            List<Highlight> highlights = new List<Highlight>();
            IEnumerable<Movie> movies =      (from i in ctx.MOVIES
                                             where i.Highlight
                                             select i).ToList();
            IEnumerable<Special> specials = (from s in ctx.SPECIALS
                                             where s.Highlight
                                             select s).ToList();
            foreach(Movie m in movies)
            {
                m.ItemAfbeelding = HaalItemAfbeeldingOp2(m, "overview");                
                m.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == m.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(m, null));
            }
            foreach(Special s in specials)
            {
                s.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == s.ItemID && a.Type.Contains("overview"));
                s.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == s.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(null, s));
            }
            return highlights;
        }

        private Afbeelding HaalItemAfbeeldingOp2(Item ItemObject, string soort) 
        {      

            if (ItemObject is Movie)
            {
                Movie movie = ItemObject as Movie;
                movie.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == movie.ItemID && a.Type.Contains(soort));
                return movie.ItemAfbeelding;
            }
            else
            {
                if(ItemObject is Special)
                {
                    Special special = ItemObject as Special;
                    special.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == special.ItemID && a.Type.Contains(soort));
                    return special.ItemAfbeelding;
                }
            }
            return null; // als de afbeelding neit of 
        }

        public IEnumerable<Highlight> GetAllHighlightsBanner()
        {
            List<Highlight> highlights = new List<Highlight>();
            IEnumerable<Movie> movies = (from i in ctx.MOVIES
                                         where i.Highlight
                                         select i).ToList();
            IEnumerable<Special> specials = (from s in ctx.SPECIALS
                                             where s.Highlight
                                             select s).ToList();
            foreach (Movie m in movies)
            {
                m.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == m.ItemID && a.Type.Contains("filmbanner"));
                m.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == m.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(m, null));
            }
            foreach (Special s in specials)
            {
                s.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == s.ItemID && a.Type.Contains("specialbanner"));
                s.Voorstellingen = (from v in ctx.VOORSTELLINGEN
                                    where v.ItemID == s.ItemID
                                    select v).ToList();
                highlights.Add(new Highlight(null, s));
            }
            return highlights;
        }



        
        public IEnumerable<Movie> GetAllMovies()
        {

            IEnumerable<Movie> movies = ctx.MOVIES.ToList();
            // Loop door de lijst heen en vul de afbeeldingen en voorstellingen erin.
            foreach (Movie mov in movies)
            {
                HaalItemAfbeeldingOp(mov, "filmoverview", mov.ItemID);
                HaalItemVoorstellingenOp(mov);
               // mov.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == mov.ItemID select v).ToList();
            }
            return movies;
        }

        //haal 1 movie op met een specifieke id.
        public Movie GetMovie(int id)
        {
            Movie movie = ctx.MOVIES.SingleOrDefault(i => i.ItemID == id);
            HaalItemAfbeeldingOp(movie, "filmbanner", id);
            movie.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v.BeginTijd).ToList();

            return movie;
        }



        private void HaalItemAfbeeldingOp(Item item, string soort, int itemId) // deze methode haalt voor een willekeurige item(special of movie) de afbeeldingen op
        {
            item.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == item.ItemID && a.Type == soort);
        }

        //haal de tijden van de movie op
        //public List<DateTime> GetMovieTijden(Movie movie)
        //{
        //    List<DateTime> tijden = new List<DateTime>();

        //    tijden = (from v in ctx.VOORSTELLINGEN
        //              where v.ItemID == movie.ItemID
        //              select v.BeginTijd).ToList();

        //    return tijden;
        //}

        public List<Movie> getMoviesByDay(int dag)
        {


            List<Movie> moviePerDag = new List<Movie>();

            moviePerDag = (from v in ctx.VOORSTELLINGEN
                           from m in ctx.MOVIES
                           where (DbFunctions.DiffDays(IJKDATUM, v.BeginTijd) % 7 == dag) && v.ItemID == m.ItemID
                           select m).ToList();
            foreach (Movie movie in moviePerDag)
            {
                HaalItemAfbeeldingOp(movie, "filmoverview", movie.ItemID);
                movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            }

            return moviePerDag;
        }
        // hier haal je een movie op op basis van de voorstellingID die deze movie heeft.
        public Movie GetMovieByVoorstellingID(int voorstellingid)
        {
            Movie movie = (from v in ctx.VOORSTELLINGEN
                           from m in ctx.MOVIES
                           where m.ItemID == v.ItemID
                           && v.VoorstellingID == voorstellingid
                           select m).SingleOrDefault();
            HaalItemAfbeeldingOp(movie, "filmbanner", movie.ItemID);
            HaalItemVoorstellingenOp(movie);
           // movie.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == movie.ItemID select v).ToList();
            return movie;
        }

        public void UpdateMovie(Movie movie)
        {
            Movie dbMovie = ctx.MOVIES.SingleOrDefault(m => m.ItemID == movie.ItemID);
            if (dbMovie != null)
            {
                dbMovie.Titel = movie.Titel;
                dbMovie.Writers = movie.Writers;

                dbMovie.Stars = movie.Stars;
                dbMovie.Rating = movie.Rating;
                dbMovie.Omschrijving = movie.Omschrijving;
                dbMovie.ItemAfbeelding.Link = movie.ItemAfbeelding.Link;
                dbMovie.OverviewAfbeelding.Link = movie.OverviewAfbeelding.Link;
                dbMovie.Director = movie.Director;
                dbMovie.Highlight = movie.Highlight;
                ctx.SaveChanges();
            }
        }



        private void HaalItemVoorstellingenOp(Item item)  // deze methode haalt voor een willekeurige item(special of movie) de voorstellingen op
        {
            item.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == item.ItemID select v).ToList();
        }

        public IEnumerable<Special> GetAllSpecials()
        {
            IEnumerable<Special> specials = ctx.SPECIALS.ToList();
            // Loop door de lijst heen en vul de afbeeldingen en voorstellingen erin.
            foreach (Special spec in specials)
            {
                HaalItemAfbeeldingOp(spec, "specialoverview", spec.ItemID);
                // spec.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spec.ItemID && a.Type == "specialoverview");
                // spec.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == spec.ItemID select v).ToList();
                HaalItemVoorstellingenOp(spec);
            }

            return specials;
        }



        public Special GetSpecial(int id)
        {
            Special special = ctx.SPECIALS.SingleOrDefault(i => i.ItemID == id);

            HaalItemAfbeeldingOp(special, "specialbanner", id);
            // spec.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spec.ItemID && a.Type == "specialbanner");
            special.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == special.ItemID select v.BeginTijd).ToList();

            return special;
        }

        //public List<DateTime> GetSpecialTijden(Special special)
        //{
        //    List<DateTime> tijden = new List<DateTime>();

        //    tijden = (from v in ctx.VOORSTELLINGEN
        //              where v.ItemID == special.ItemID
        //              select v.BeginTijd).ToList();

        //    return tijden;
        //}



        public Special GetSpecialByVoorstellingID(int voorstellingid)
        {
            Special special = (from v in ctx.VOORSTELLINGEN
                               from s in ctx.SPECIALS
                               where s.ItemID == v.ItemID
                               && v.VoorstellingID == voorstellingid
                               select s).SingleOrDefault();
            HaalItemAfbeeldingOp(special, "specialbanner", special.ItemID);
            // special.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == special.ItemID && a.Type == "specialbanner");
            //special.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == special.ItemID select v).ToList();
            HaalItemVoorstellingenOp(special);
            return special;
        }


        public List<Special> getSpecialByDay(int dag)
        {

            List<Special> specialPerDag = new List<Special>();

            specialPerDag = (from v in ctx.VOORSTELLINGEN
                           from s in ctx.SPECIALS
                           where (DbFunctions.DiffDays(IJKDATUM, v.BeginTijd) % 7 == dag) && v.ItemID == s.ItemID
                           select s).ToList();
            foreach (Special special in specialPerDag)
            {
                HaalItemAfbeeldingOp(special, "specialoverview", special.ItemID);
                special.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == special.ItemID select v).ToList();
            }

            return specialPerDag;
        }



    }
}