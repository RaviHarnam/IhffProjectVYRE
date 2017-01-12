using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbBestellingRepository : IBestellingRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Bestelling> GetBestellingen() //Ophalen van bestellingen
        {
            IEnumerable<Bestelling> bestellingen = ctx.BESTELLINGEN.ToList();
            return bestellingen;
        }

        public void MaakBestelling(List<Event> events, string payment, string name, string email, string pickup)
        {
            //Add Klant
            Klant k = new Klant(email, name);
            ctx.KLANTEN.Add(k);
            ctx.SaveChanges();
            //Add Bestelling
            Bestelling b = new Bestelling(pickup, payment);
            b.KlantID = k.KlantID;
            ctx.BESTELLINGEN.Add(b);
            ctx.SaveChanges();
            //Add Events
            foreach (Event ev in events)
            {
                ev.BestellingID = b.BestellingID; //Vullen bestellingID in de event
                ctx.EVENTS.Add(ev); //Adden van events
                if (ev.VoorstellingID != null) //Update voorstelling plaatsen
                {
                    Voorstelling v = ctx.VOORSTELLINGEN.SingleOrDefault(m => m.VoorstellingID == ev.VoorstellingID.Value);
                    v.GereserveerdePlaatsen = v.GereserveerdePlaatsen + ev.Aantal;
                }
                if(ev.MaaltijdID != null) //Update Maaltijd plaatsen
                {
                    Maaltijd m = ctx.MAALTIJD.SingleOrDefault(c => c.MaaltijdID == ev.MaaltijdID.Value);
                    m.GereserveerdePlaatsen = m.GereserveerdePlaatsen + ev.Aantal;
                }
            }
            ctx.SaveChanges(); //Sla de bestelling, plus events en klant op en update plaatsen
        }
    }
}