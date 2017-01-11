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
        [Required(ErrorMessage = "The Username field is required.")]
        [Display(Name = "Username:")]
        public string Gebruikersnaam { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
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