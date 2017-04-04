using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IHFF.Repositories;

namespace IHFF.Models
{
    public class Cart
    {
        IVoorstellingRepository dbVoorstelling = new DbVoorstellingRepository();
        IItemRepository dbItemRespository = new DbItemRepository();

        public List<Event> Events { get; set; }
        public decimal Korting { get; set; }
        public decimal Totaal { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Payment { get; set; }

        [Required]
        public string Pickup { get; set; }

        public Cart()
        {
            Events = new List<Event>();
        }

        public void BerekenTotaal()
        {
            if (Events != null)
            {
                foreach (Event ev in Events)
                {
                    ev.CartId = Events.IndexOf(ev);
                    if (ev.EventVoorstelling != null)
                    {
                        if (Events.Where(m => m.EventVoorstelling != null).Count() > 1)
                        {
                            if (ev.Prijs > 0)
                            {
                                Korting = (decimal)(5 / (double)100);
                            }
                        }
                    }
                    Totaal += ev.BerekenTotaalPrijs();
                }
            }

            Totaal = Totaal - (Totaal * Korting);
            Totaal = Math.Round(Totaal, 2, MidpointRounding.AwayFromZero);
        }

        public Cart AddItem(int? voorstellingId, int aantal)
        {
            bool eventAlInCart = false;
            Voorstelling v = dbVoorstelling.GetVoorstelling(voorstellingId);
            if (v.GereserveerdePlaatsen < v.MaxPlaatsen)
            {

                Event eventx = ConvertVoorstelling(aantal, v);

                foreach (Event ev in Events)
                {
                    if (ev.VoorstellingID == v.VoorstellingID)
                    {
                        ev.Aantal += eventx.Aantal;
                        eventAlInCart = true;
                        break;
                    }
                }
                if (!eventAlInCart)
                {
                    Events.Add(eventx);
                }
            }

            return this;
        }

        private Event ConvertVoorstelling(int aantal, Voorstelling v)
        {
            Event eventx = new Event();

            Item i = dbItemRespository.GetItem(v.ItemID);
            eventx.Aantal = aantal;
            eventx.DatumTijd = v.BeginTijd;
            eventx.EventEindTijd = v.EindTijd;
            eventx.Prijs = v.Prijs;
            eventx.Titel = i.Titel;
            eventx.EventVoorstelling = v;
            eventx.VoorstellingID = v.VoorstellingID;

            return eventx;
        }

        public Cart DeleteItem(int eventId)
        {

            Event toRemove = null;

            foreach (Event eventx in Events)
                if (eventx.EventID == eventId)
                {
                    toRemove = eventx;
                    break;
                }

            Events.Remove(toRemove);

            return this;
        }
    }
}