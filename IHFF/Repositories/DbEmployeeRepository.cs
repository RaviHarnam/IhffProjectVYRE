using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbEmployeeRepository : IEmployeeRepository
    {
        private IhffContext ctx = new IhffContext();

        public bool EmployeeExist(Employee emp)
        {
            Employee e = (from em in ctx.EMPLOYEES
                          where em.Gebruikersnaam == emp.Gebruikersnaam && em.Wachtwoord == emp.Wachtwoord
                          select em).SingleOrDefault();
            return (e != null);
        }

        public IEnumerable<EventListRepresentation> GetAllEvents()
        {
            List<EventListRepresentation> events = new List<EventListRepresentation>();
            IEnumerable<Item> items = (from i in ctx.ITEMS select i).ToList();
            IEnumerable<Restaurant> restaurants = (from r in ctx.RESTAURANTS select r).ToList();
            IEnumerable<Museum> cultureEvents = (from c in ctx.MUSEA select c).ToList();

            foreach (Item item in items)
                events.Add(new EventListRepresentation(item));

            foreach (Restaurant restaurant in restaurants)
                events.Add(new EventListRepresentation(restaurant));

            foreach (Museum culture in cultureEvents)
                events.Add(new EventListRepresentation(culture));

            return (IEnumerable<EventListRepresentation>)events;
        }

        public Museum GetMuseum(int id)
        {
            Museum cult = ctx.MUSEA.SingleOrDefault(c => c.MuseumID == id);
            //cult.MuseumAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.MuseumID == cult.MuseumID && a.Type == "banner");
            cult.MuseumLocatie = ctx.LOCATIES.SingleOrDefault(l => l.LocatieID == cult.LocatieID);
            return cult;
        }

        public Item GetItem(int id)
        {
            Item itm = ctx.ITEMS.SingleOrDefault(i => i.ItemID == id);
            itm.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == itm.ItemID && a.Type == "itembanner");
            // Locatie
            return itm;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant rst = ctx.RESTAURANTS.SingleOrDefault(r => r.RestaurantID == id);
            rst.RestaurantAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == rst.RestaurantID && a.Type == "restaurantbanner");
            rst.RestaurantLocatie = ctx.LOCATIES.SingleOrDefault(l => l.LocatieID == rst.LocatieID);
            return rst;
        }

        public Movie GetMovie(int id)
        {
            Movie mov = ctx.MOVIES.SingleOrDefault(m => m.ItemID == id);
            mov.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == mov.ItemID && a.Type == "filmbanner");
            return mov;
        }
        public Special GetSpecial(int id)
        {
            Special spc = ctx.SPECIALS.SingleOrDefault(s => s.ItemID == id);
            spc.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == id && a.Type == "specialbanner");
            return spc;
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
                dbMovie.Director = movie.Director;
                dbMovie.Highlight = movie.Highlight;
                ctx.SaveChanges();
            }
        }

        public void UpdateSpecial(Special special)
        {
            Special dbSpecial = ctx.SPECIALS.SingleOrDefault(s => s.ItemID == special.ItemID);
            if (dbSpecial != null)
            {
                dbSpecial.Titel = special.Titel;
                dbSpecial.Speaker = special.Speaker;
                dbSpecial.SpokenLanguage = special.SpokenLanguage;
                dbSpecial.Omschrijving = special.Omschrijving;
                dbSpecial.ItemAfbeelding.Link = special.ItemAfbeelding.Link;
                ctx.SaveChanges();
            }
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            Restaurant dbRestaurant = ctx.RESTAURANTS.SingleOrDefault(r => r.RestaurantID == restaurant.RestaurantID);
            if (dbRestaurant != null)
            {
                dbRestaurant.Telefoon = restaurant.Telefoon;
                dbRestaurant.Email = restaurant.Email;
                dbRestaurant.Website = restaurant.Website;
                dbRestaurant.Naam = restaurant.Naam;
                dbRestaurant.Omschrijving = restaurant.Omschrijving;
                Afbeelding dbAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == restaurant.RestaurantAfbeelding.AfbeeldingID && a.Type == "banner");
                if (dbRestaurant != null)                
                    dbRestaurant.RestaurantAfbeelding.Link = restaurant.RestaurantAfbeelding.Link;
                
                Locatie dbLocatie = ctx.LOCATIES.SingleOrDefault(l => l.LocatieID == restaurant.LocatieID);
                if (dbLocatie != null)
                {
                    dbLocatie.Straat = restaurant.RestaurantLocatie.Straat;
                    dbLocatie.Huisnummer = restaurant.RestaurantLocatie.Huisnummer;
                    dbLocatie.Toevoeging = restaurant.RestaurantLocatie.Toevoeging;
                    dbLocatie.Plaats = restaurant.RestaurantLocatie.Plaats;
                }
                ctx.SaveChanges();
            }
        }

        public void UpdateMuseum(Museum museum)
        {
            Museum dbMuseum = ctx.MUSEA.SingleOrDefault(m => m.MuseumID == museum.MuseumID);
            if (dbMuseum != null)
            {
                dbMuseum.Titel = museum.Titel;
                dbMuseum.Omschrijving = museum.Omschrijving;
                dbMuseum.Maandag = museum.Maandag;
                dbMuseum.Dinsdag = museum.Dinsdag;
                dbMuseum.Woensdag = museum.Woensdag;
                dbMuseum.Donderdag = museum.Donderdag;
                dbMuseum.Vrijdag = museum.Vrijdag;
                dbMuseum.Zaterdag = museum.Vrijdag;
                dbMuseum.Zondag = museum.Zondag;
                dbMuseum.Kids = museum.Kids;
                dbMuseum.Adults = museum.Adults;
                dbMuseum.MuseumAfbeelding.Link = museum.MuseumAfbeelding.Link;
                ctx.SaveChanges();
            }
        }
    }
}