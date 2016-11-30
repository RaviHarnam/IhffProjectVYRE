﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ihff_project.Models
{
    public class Culture : Activiteit
    {
        public Culture(string titel, string info, string omschrijving, string datumTijd, double prijs) : base(titel, info, omschrijving, datumTijd, prijs)
        {
        }

        public string Naam { get; set; }
        public string Plaats { get; set; }
    }
}