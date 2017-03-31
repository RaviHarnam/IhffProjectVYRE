using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Cart
    {
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
    }
}