using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        IEnumerable<Event> GetBybestellingId(int bestellingId);
        Event GetById(int eventId);
        void MakeEvent(Voorstelling voorstelling, int aantal);
        void MakeEvent(Maaltijd maaltijd, int aantal);

    }
}
