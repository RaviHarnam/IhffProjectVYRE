using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class MuseumInputModel
    {
        public int MuseumID { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }

        public int LocatieID { get; set; }
        [Required]
        public string Telefoon { get; set; }
        [Required]
        public string Adults { get; set; }
        [Required]
        public string Kids { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string Maandag { get; set; }
        [Required]
        public string Dinsdag { get; set; }
        [Required]
        public string Woensdag { get; set; }
        [Required]
        public string Donderdag { get; set; }
        [Required]
        public string Vrijdag { get; set; }
        [Required]
        public string Zaterdag { get; set; }
        [Required]
        public string Zondag { get; set; }

        [NotMapped]
        public virtual Afbeelding MuseumAfbeelding { get; set; }
        [NotMapped]
        public virtual Locatie MuseumLocatie { get; set; }

        public MuseumInputModel(string naam, string omschrijving, string adults, string kids, string website, string maandag, string dinsdag, string woensdag, string donderdag, string vrijdag, string zaterdag, string zondag, string telefoon)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Adults = adults;
            Kids = kids;
            Website = website;
            Maandag = maandag;
            Dinsdag = dinsdag;
            Woensdag = woensdag;
            Donderdag = donderdag;
            Vrijdag = vrijdag;
            Zaterdag = zaterdag;
            Zondag = zondag;
            Telefoon = telefoon;
        }
        public MuseumInputModel()
        {

        }
        public void ConvertToMuseumInputModel(Museum m)
        {
            Naam = m.Naam;
            MuseumID = m.MuseumID;
            LocatieID = m.LocatieID;
            Omschrijving = m.Omschrijving;
            Adults = m.Adults;
            Kids = m.Kids;
            Website = m.Website;
            Maandag = m.Maandag;
            Dinsdag = m.Dinsdag;
            Woensdag = m.Woensdag;
            Donderdag = m.Donderdag;
            Vrijdag = m.Vrijdag;
            Zaterdag = m.Zaterdag;
            Zondag = m.Zondag;
            Telefoon = m.Telefoon;
            MuseumAfbeelding = m.MuseumAfbeelding;
            MuseumLocatie = m.MuseumLocatie;
        }
    }
}