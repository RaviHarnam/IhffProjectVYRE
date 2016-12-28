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
            foreach (Voorstelling voorstelling in voorstellingen)
            {
                //switch (voorstelling.DatumTijd.DayOfWeek)
                //{
                //    case DayOfWeek.Monday:
                //        voorstelling.day = Enum.Weekday.Maandag;
                //        break;
                //    case DayOfWeek.Tuesday:
                //        voorstelling.day = Enum.Weekday.Dinsdag;
                //        break;
                //    case DayOfWeek.Wednesday:
                //        voorstelling.day = Enum.Weekday.Woensdag;
                //        break;
                //    case DayOfWeek.Thursday:
                //        voorstelling.day = Enum.Weekday.Donderdag;
                //        break;
                //    case DayOfWeek.Friday:
                //        voorstelling.day = Enum.Weekday.Vrijdag;
                //        break;
                //    case DayOfWeek.Saturday:
                //        voorstelling.day = Enum.Weekday.Zaterdag;
                //        break;
                //    case DayOfWeek.Sunday:
                //        voorstelling.day = Enum.Weekday.Zondag;
                //        break;
                //}
            }
            return voorstellingen;
        }


    }
}