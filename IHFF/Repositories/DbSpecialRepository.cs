using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    public class DbSpecialRepository : ISpecialRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Special> GetAllSpecials()
        {
            IEnumerable<Special> specials = ctx.SPECIALS.ToList();
            // Loop door de lijst heen en vul de afbeeldingen en voorstellingen erin.
            foreach (Special spec in specials)
            {
                spec.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spec.ItemID && a.Type == "specialoverview");
                spec.Voorstellingen = (from v in ctx.VOORSTELLINGEN where v.ItemID == spec.ItemID select v).ToList();
            }

            return specials;
        }

        public Special GetSpecial(int id)
        {
            Special spec = ctx.SPECIALS.SingleOrDefault(i => i.ItemID == id);

            spec.ItemAfbeelding = ctx.AFBEELDINGEN.SingleOrDefault(a => a.ItemID == spec.ItemID && a.Type == "specialbanner");
            spec.Tijden = (from v in ctx.VOORSTELLINGEN where v.ItemID == spec.ItemID select v.BeginTijd).ToList();

            return spec;
        }

        public List<DateTime> GetMovieTijden(Movie movie)
        {
            List<DateTime> tijden = new List<DateTime>();

            tijden = (from v in ctx.VOORSTELLINGEN
                      where v.ItemID == movie.ItemID
                      select v.BeginTijd).ToList();

            return tijden;
        }
    }
}