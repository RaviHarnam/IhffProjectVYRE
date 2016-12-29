using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHFF.Repositories
{
    interface IScheduleRepository
    {
        IEnumerable<Voorstelling> getAllVoorstellingen(DayOfWeek dag);
    }
}
