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
        [Required]
        [Display(Name = "Username")]
        public string Gebruikersnaam { get; set; }
        [Required]
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