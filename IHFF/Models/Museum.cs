using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Museum 
    {
        [Key]
        public int MuseumID { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }  
        
        public int LocatieID { get; set; }
        public string Telefoon { get; set; }
        public string Adults { get; set; }
        public string Kids { get; set; }
        public string Website { get; set; }
        public string Maandag { get; set; }
        public string Dinsdag { get; set; }
        public string Woensdag { get; set; }
        public string Donderdag { get; set; }
        public string Vrijdag { get; set; }
        public string Zaterdag { get; set; }
        public string Zondag { get; set; }
        [NotMapped]
        public virtual Afbeelding MuseumAfbeelding { get; set; }
        [NotMapped]
        public virtual Locatie MuseumLocatie { get; set; }

        public Museum()
        {

        }

        public Museum(string titel, string omschrijving, string adults, string kids, string website, string maandag, string dinsdag, string woensdag, string donderdag, string vrijdag, string zaterdag, string zondag, string telefoon)
        {
<<<<<<< HEAD
            Titel = naam;
=======
            Titel = titel;
>>>>>>> 0dbee3915970e13a1760e92c9649e72770773b24
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
    }
}