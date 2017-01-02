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
        [NotMapped]
        DbVoorstellingRepository DbVoorstelling = new DbVoorstellingRepository();

        [NotMapped]
        List<Voorstelling> voorstellingen;

        [NotMapped]
        public List<DateTime> Data = new List<DateTime>();

        [NotMapped]
        public SelectList ListItems { get; private set; }

        public MovieViewModel(int ItemId)
        {
            voorstellingen = DbVoorstelling.GetVoorstellingen(ItemId);
            MakeListItems();
        }

        void MakeListItems()
        {

            foreach(Voorstelling v in voorstellingen)
            {
                Data.Add(v.BeginTijd);
            }

            ListItems = new SelectList(Data);
        }
    }
}