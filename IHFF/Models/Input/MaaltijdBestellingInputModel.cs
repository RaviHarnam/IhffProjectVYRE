using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class MaaltijdBestellingInputModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Amount should be higher than 1")]
        public int Aantal { get; set; }

        [Required]
        [Range(1, 59, ErrorMessage = "Minutes must be between 0 and 59")]
        public int minuten { get; set; }

        public MaaltijdBestellingInputModel()
        {

        }
    }
}