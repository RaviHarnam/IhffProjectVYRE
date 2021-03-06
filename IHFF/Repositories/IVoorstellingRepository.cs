﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHFF.Models;

namespace IHFF.Repositories
{
    public interface IVoorstellingRepository
    {
        List<Voorstelling> GetVoorstellingen(int itemId);
        Voorstelling GetVoorstelling(int? voorstellingId);

        Voorstelling GetVoorstelling(int itemId, DateTime Tijd);
    }
}
