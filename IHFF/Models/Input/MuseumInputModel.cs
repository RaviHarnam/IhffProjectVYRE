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

        [Required(ErrorMessage = "The Name field is required.")]
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The Name field has a maximum size of 50.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "The Summary field is required.")]
        [StringLength(4000, ErrorMessage = "The Summary field has a maximum size of 4000.")]
        public string Omschrijving { get; set; }

        public int LocatieID { get; set; }

        [Required(ErrorMessage = "The Telephone field is required.")]
        [StringLength(1000, ErrorMessage = "The Telephone field has a maximum size of 1000.")]
        [Display(Name = "Telephone")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "The Adults field is required.")]
        [StringLength(40, ErrorMessage = "The Adults field has a maximum size of 40.")]
        public string Adults { get; set; }

        [Required(ErrorMessage = "The Kids field is required.")]
        [StringLength(40, ErrorMessage = "The Kids field has a maximum size of 40.")]
        public string Kids { get; set; }

        [Required(ErrorMessage = "The Website field is required.")]
        [StringLength(100, ErrorMessage = "The Website field has a maximum size of 100.")]
        public string Website { get; set; }

        [Required(ErrorMessage = "The Monday field is required.")]
        [Display(Name = "Monday")]
        [StringLength(20, ErrorMessage = "The Monday field has a maximum size of 20.")]
        public string Maandag { get; set; }

        [Required(ErrorMessage = "The Tuesday field is required.")]
        [Display(Name = "Tuesday")]
        [StringLength(20, ErrorMessage = "The Tuesday field has a maximum size of 20.")]
        public string Dinsdag { get; set; }

        [Required(ErrorMessage = "The Wednesday field is required.")]
        [Display(Name = "Wednesday")]
        [StringLength(20, ErrorMessage = "The Wednesday field has a maximum size of 20.")]
        public string Woensdag { get; set; }

        [Required(ErrorMessage = "The Thursday field is required.")]
        [Display(Name = "Thursday")]
        [StringLength(20, ErrorMessage = "The Thursday field has a maximum size of 20.")]
        public string Donderdag { get; set; }

        [Required(ErrorMessage = "The Friday field is required.")]
        [Display(Name = "Friday")]
        [StringLength(20, ErrorMessage = "The Friday field has a maximum size of 20.")]
        public string Vrijdag { get; set; }

        [Required(ErrorMessage = "The Saturday field is required.")]
        [Display(Name = "Saturday")]
        [StringLength(20, ErrorMessage = "The Saturday field has a maximum size of 20.")]
        public string Zaterdag { get; set; }

        [Required(ErrorMessage = "The Sunday field is required.")]
        [Display(Name = "Sunday")]
        [StringLength(20, ErrorMessage = "The Sunday field has a maximum size of 20.")]
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