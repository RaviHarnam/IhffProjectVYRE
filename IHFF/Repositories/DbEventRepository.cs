using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbEventRepository : IEventRepository
    {
        IhffContext ctx = new IhffContext();
        public IEnumerable<Event> GetAll()
        {
            IEnumerable<Event> events = (from e in ctx.EVENTS
                                         select e).ToList();

            return events;
        }

        public IEnumerable<Event> GetBybestellingId(int bestellingId)
        {
            IEnumerable<Event> events = (from e in ctx.EVENTS
                                         where e.Bestellingid == bestellingId
                                         select e).ToList();

            return events;
        }

        public Event GetById(int eventId)
        {
            Event eventx = (from e in ctx.EVENTS
                            where e.EventId == eventId
                            select e).SingleOrDefault();

            return eventx;
        }

        public void MakeEvent(Maaltijd maaltijd, int aantal)
        {

        }

        public void MakeEvent(Voorstelling voorstelling, int aantal)
        {
            Event eventx = new Event();
            eventx.VoorstellingId = voorstelling.VoorstellingId;
            eventx.Titel = (from i in ctx.ITEMS
                            where i.ItemID == voorstelling.ItemId
                            select i.Titel).SingleOrDefault();
            eventx.DatumTijd = voorstelling.DatumTijd;
            eventx.Prijs = (from v in ctx.VOORSTELLINGEN
                            where v.VoorstellingId == voorstelling.VoorstellingId
                            select v.Prijs).SingleOrDefault();
            eventx.Aantal = aantal;


            if (HttpContext.Current.Session["cart"] == null)
            {
                HttpContext.Current.Session["cart"] = new List<Event>();
            }

            List<Event> cartlist = (List<Event>)HttpContext.Current.Session["cart"];
            cartlist.Add(eventx);
        }
    }
}