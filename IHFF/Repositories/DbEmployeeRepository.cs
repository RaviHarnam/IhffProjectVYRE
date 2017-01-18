using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;
using System.Data.Entity;

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

            return events;
        }

        public Museum GetMuseum(int id)
        {
            Museum cult = ctx.MUSEA.SingleOrDefault(c => c.MuseumID == id);
            cult.MuseumAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.MuseumID == cult.MuseumID && a.Type == "museumbanner");
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
            mov.OverviewAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(m => m.ItemID == mov.ItemID && m.Type == "filmoverview");
            mov.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == mov.ItemID select v.BeginTijd).ToList();
            return mov;
        }
        public Special GetSpecial(int id)
        {
            Special spc = ctx.SPECIALS.SingleOrDefault(s => s.ItemID == id);
            spc.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spc.ItemID && a.Type == "specialbanner");
            spc.OverviewAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spc.ItemID && a.Type == "specialoverview");
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
                dbMovie.OverviewAfbeelding.Link = movie.OverviewAfbeelding.Link;
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
                dbSpecial.OverviewAfbeelding.Link = special.OverviewAfbeelding.Link;
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
                    dbLocatie.Postcode = restaurant.RestaurantLocatie.Postcode;
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
                dbMuseum.Naam = museum.Naam;
                dbMuseum.LocatieID = museum.LocatieID;
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
                dbMuseum.Telefoon = museum.Telefoon;
                dbMuseum.Website = museum.Website;

                Afbeelding dbAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.MuseumID == museum.MuseumID && a.Type == "museumbanner");
                if (dbAfbeelding != null)
                    dbAfbeelding.Link = museum.MuseumAfbeelding.Link;

                Locatie dbLocatie = ctx.LOCATIES.SingleOrDefault(l => l.LocatieID == museum.LocatieID);
                ctx.SaveChanges();
            }
        }

        public void DeleteMuseum(int museumid)
        {
            Museum dbMuseum = ctx.MUSEA.SingleOrDefault(m => m.MuseumID == museumid);
            //Locatie dbLocatie = ctx.LOCATIES.SingleOrDefault(m => m.LocatieID == dbMuseum.LocatieID);
            //if (dbLocatie != null) //On delete Cascade betekent dat dit niet meer hoeft
            //    ctx.Entry(dbLocatie).State = EntityState.Deleted;

            IEnumerable<Afbeelding> dbAfbeeldingen = (from a in ctx.AFBEELDINGEN
                                                      where a.MuseumID == museumid
                                                      select a).ToList();
            if (dbAfbeeldingen != null && dbAfbeeldingen.Any())
                foreach (Afbeelding dbAfbeelding in dbAfbeeldingen)
                    ctx.Entry(dbAfbeelding).State = EntityState.Deleted;

          
            if (dbMuseum != null)
                ctx.Entry(dbMuseum).State = EntityState.Deleted;


            ctx.SaveChanges();
        }

        public void DeleteMovie(int movieid)
        {
            Movie dbMovie = ctx.MOVIES.SingleOrDefault(m => m.ItemID == movieid);
            if (dbMovie != null)
                ctx.ITEMS.Remove(dbMovie);
            Item dbItem = ctx.ITEMS.SingleOrDefault(m => m.ItemID == movieid);
            if (dbItem != null)
                ctx.MOVIES.Remove(dbMovie);
            IEnumerable<Afbeelding> dbAfbeeldingen = (from a in ctx.AFBEELDINGEN
                                                      where a.ItemID == movieid
                                                      select a).ToList();
            if (dbAfbeeldingen != null && dbAfbeeldingen.Any())
                foreach (Afbeelding dbAfbeelding in dbAfbeeldingen)
                    ctx.AFBEELDINGEN.Remove(dbAfbeelding);

            IEnumerable<Voorstelling> dbVoorstellingen = (from v in ctx.VOORSTELLINGEN
                                                          where v.ItemID == movieid
                                                          select v).ToList();
            if (dbVoorstellingen != null && dbAfbeeldingen.Any())
                foreach (Voorstelling dbVoorstelling in dbVoorstellingen)
                    ctx.VOORSTELLINGEN.Remove(dbVoorstelling);

            ctx.SaveChanges();
        }

        public void DeleteSpecial(int specialid)
        {
            Special dbSpecial = ctx.SPECIALS.SingleOrDefault(s => s.ItemID == specialid);
            if (dbSpecial != null)
                ctx.SPECIALS.Remove(dbSpecial);
            Item dbItem = ctx.ITEMS.SingleOrDefault(s => s.ItemID == specialid);
            if (dbItem != null)
                ctx.ITEMS.Remove(dbItem);
            IEnumerable<Afbeelding> dbAfbeeldingen = (from a in ctx.AFBEELDINGEN
                                                      where a.ItemID == specialid
                                                      select a).ToList();
            if (dbAfbeeldingen != null && dbAfbeeldingen.Any())
                foreach (Afbeelding dbAfbeelding in dbAfbeeldingen)
                    ctx.AFBEELDINGEN.Remove(dbAfbeelding);
            IEnumerable<Voorstelling> dbVoorstellingen = (from v in ctx.VOORSTELLINGEN
                                                          where v.ItemID == specialid
                                                          select v).ToList();
            if (dbVoorstellingen != null && dbVoorstellingen.Any())
                foreach (Voorstelling dbVoorstelling in dbVoorstellingen)
                    ctx.VOORSTELLINGEN.Remove(dbVoorstelling);

            ctx.SaveChanges();
        }

        public void DeleteRestaurant(int restaurantid)
        {
            Restaurant dbRestaurant = ctx.RESTAURANTS.SingleOrDefault(r => r.RestaurantID == restaurantid);
            if (dbRestaurant != null)
                ctx.RESTAURANTS.Remove(dbRestaurant);
            IEnumerable<Afbeelding> dbAfbeeldingen = (from a in ctx.AFBEELDINGEN
                                                      where a.RestaurantID == restaurantid
                                                      select a).ToList();
            if (dbAfbeeldingen != null && dbAfbeeldingen.Any())
                foreach (Afbeelding dbAfbeelding in dbAfbeeldingen)
                    ctx.AFBEELDINGEN.Remove(dbAfbeelding);

            //On delete cascade will remove this for me
            Locatie dbLocatie = ctx.LOCATIES.SingleOrDefault(l => l.LocatieID == dbRestaurant.LocatieID);
            //if (dbLocatie != null)
            //    ctx.LOCATIES.Remove(dbLocatie);

            ctx.SaveChanges();
        }

        public void AddMovie(Movie m)
        {        
            //Add movie    
            ctx.MOVIES.Add(m);
            ctx.SaveChanges();
            //Add picture(Banner)
            m.ItemAfbeelding.ItemID = m.ItemID;
            ctx.AFBEELDINGEN.Add(m.ItemAfbeelding);
            //Add Overview Picture
            m.OverviewAfbeelding.ItemID = m.ItemID;
            ctx.AFBEELDINGEN.Add(m.OverviewAfbeelding);
            //Save Changes
            ctx.SaveChanges();
        }

        public void AddSpecial(Special s)
        {
            //Add special
            ctx.SPECIALS.Add(s);
            ctx.SaveChanges();
            //Add picture(banner)
            s.ItemAfbeelding.ItemID = s.ItemID;
            ctx.AFBEELDINGEN.Add(s.ItemAfbeelding);
            //Add picture(overview)
            s.OverviewAfbeelding.ItemID = s.ItemID;
            ctx.AFBEELDINGEN.Add(s.OverviewAfbeelding);
            //Save Changes
            ctx.SaveChanges();
        }

        public void AddMuseum(Museum m)
        {
            //Add location
            ctx.LOCATIES.Add(m.MuseumLocatie);
            ctx.SaveChanges();
            m.LocatieID = m.MuseumLocatie.LocatieID;
            //Add Museum
            ctx.MUSEA.Add(m);
            ctx.SaveChanges();
            //Add Picture
            m.MuseumAfbeelding.MuseumID = m.MuseumID;
            ctx.AFBEELDINGEN.Add(m.MuseumAfbeelding);
            ctx.SaveChanges();
        }

        public void AddRestaurant(Restaurant r)
        {
            //Add location
            ctx.LOCATIES.Add(r.RestaurantLocatie);
            ctx.SaveChanges();
            //Add restaurant
            r.LocatieID = r.RestaurantLocatie.LocatieID;
            ctx.RESTAURANTS.Add(r);
            ctx.SaveChanges();
            //Add picture
            r.RestaurantAfbeelding.RestaurantID = r.RestaurantID;
            ctx.AFBEELDINGEN.Add(r.RestaurantAfbeelding);
            ctx.SaveChanges();
        }

        public void AddHotel(Hotel h)
        {

            ctx.HOTEL.Add(h);
            ctx.SaveChanges();
            int hotelId = (from hot in ctx.HOTEL
                         where h.Naam == hot.Naam
                         select hot.HotelId).ToList()[0];
            h.HotelAfbeelding.HotelID = hotelId;
            h.HotelOverviewAfbeelding.HotelID = hotelId;
            ctx.AFBEELDINGEN.Add(h.HotelAfbeelding);
            ctx.SaveChanges();
            ctx.AFBEELDINGEN.Add(h.HotelOverviewAfbeelding);
            ctx.SaveChanges();

        }
    }
}