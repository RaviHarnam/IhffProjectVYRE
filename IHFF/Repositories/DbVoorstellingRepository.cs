using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbVoorstellingRepository : IVoorstellingRepository
    {
        IhffContext ctx = new IhffContext();

        public Voorstelling GetVoorstelling(int voorstellingId)
        {
            Voorstelling voorstelling = (from v in ctx.VOORSTELLINGEN
                                         where v.VoorstellingID == voorstellingId
                                         select v).SingleOrDefault();

            return voorstelling;
        }

        public Voorstelling GetVoorstelling(int itemId, DateTime DatumTijd)
        {
            Voorstelling voorstelling = (from v in ctx.VOORSTELLINGEN
                                         where v.ItemID == itemId && v.BeginTijd == DatumTijd
                                         select v).SingleOrDefault();

            return voorstelling;
        }

        public List<Voorstelling> GetVoorstellingen (int itemId)
        {
            List<Voorstelling> voorstellingen = (from v in ctx.VOORSTELLINGEN
                                         where v.ItemID == itemId
                                         select v).ToList();

            return voorstellingen;
        }
    }
}