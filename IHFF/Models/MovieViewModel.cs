using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IHFF.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    public class MovieViewModel
    {
        DbVoorstellingRepository DbVoorstelling = new DbVoorstellingRepository();
        List<Voorstelling> voorstellingen;
        [NotMapped]
        public SelectList ListItems { get; private set; }

        public MovieViewModel(int ItemId)
        {
            voorstellingen = DbVoorstelling.GetVoorstellingen(ItemId);
            MakeListItems();
        }

        public void MakeListItems()
        {
            List<DateTime> Data = new List<DateTime>();

            foreach(Voorstelling v in voorstellingen)
            {
                Data.Add(v.DatumTijd);
            }

            ListItems = new SelectList(Data);
        }
    }
}