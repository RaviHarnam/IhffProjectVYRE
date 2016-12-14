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
            IEnumerable<Culture> cultureEvents = (from c in ctx.MUSEA select c).ToList();
            
            foreach(Item item in items)            
                events.Add(new EventListRepresentation(item));
            
            foreach(Restaurant restaurant in restaurants)            
                events.Add(new EventListRepresentation(restaurant));
            
            foreach(Culture culture in cultureEvents)           
                events.Add(new EventListRepresentation(culture));
            
            return (IEnumerable<EventListRepresentation>)events;
        }

        public Culture GetCultureEvent(int id)
        {
            Culture cult = ctx.MUSEA.SingleOrDefault(c => c.CultureID == id);
            cult.CultureAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.MuseumID == cult.CultureID);
            return cult;
        }

        public Item GetItem(int id)
        {
            Item itm = ctx.ITEMS.SingleOrDefault(i => i.ItemID == id);
            itm.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == itm.ItemID);
            return itm;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant rst = ctx.RESTAURANTS.SingleOrDefault(r => r.RestaurantID == id);
            rst.RestaurantAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.RestaurantID == rst.RestaurantID);
            return rst;
        }
    }
}