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

        public IEnumerable<Voorstelling> getAllVoorstellingen(DayOfWeek dag)
        {
            IEnumerable<Voorstelling> voorstellingen = ctx.VOORSTELLINGEN.ToList();
            
            return voorstellingen;
        }


    }
}