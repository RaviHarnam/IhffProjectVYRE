using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Employee
    {
        [Key]
        public int MedewerkerID { get; set; }
        [Required(ErrorMessage = "The field Username is required.")]
        [Display(Name = "Username")]
        public string Gebruikersnaam { get; set; }
        [Required(ErrorMessage = "The field Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Wachtwoord{ get; set; }

        public Employee(string username, string password)
        {
            Gebruikersnaam = username;
            Wachtwoord = password;
        }
        public Employee()
        {

        }


    }
}