using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbScheduleRepository : IScheduleRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Voorstelling> getAllVoorstellingen()
        {
            IEnumerable<Voorstelling> voorstellingen = ctx.VOORSTELLINGEN.ToList();
            
            foreach(Voorstelling v in voorstellingen)
            {
                //v.VoorstellingNaam = ctx.ITEMS.SingleOrDefault(i => i.ItemID == v.ItemId).Titel;
                v.VoorstellingLocatie = ctx.LOCATIES.Single(l => l.LocatieID == v.LocatieId);
                v.VoorstellingZaal = ctx.ZALEN.SingleOrDefault(z => z.ZaalID == v.ZaalID);
                v.VoorstellingItem = ctx.ITEMS.SingleOrDefault(i => i.ItemID == v.ItemID);
            }
            return voorstellingen;
        }


    }
}