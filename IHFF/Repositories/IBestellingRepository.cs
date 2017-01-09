using IHFF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Repositories
{
    interface IBestellingRepository
    {
        void MaakBestelling(List<Event> events, string payment, string name, string email, string pickup);
        IEnumerable<Bestelling> GetBestellingen();
    }
}