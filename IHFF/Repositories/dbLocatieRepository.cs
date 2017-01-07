using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHFF.Models;

namespace IHFF.Repositories
{
    public class DbLocatieRepository : ILocatieRepository
    {
        private IhffContext ctx = new IhffContext();

        public IEnumerable<Locatie> GetLocaties()
        {
            IEnumerable<Locatie> locaties = (from l in ctx.LOCATIES
                                             select l).ToList();
            return locaties;
        }
    }
}