using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IHFF.Models.Input
{
    public class ItemBestellingInputModel
    {
        [Required(ErrorMessage = "Fill in an amount")]
        [Display(Name = "Give a valid amount")]
        [Range(1,1000,ErrorMessage ="Give an amount bigger than 0")]
        public int Aantal { get; set; }
        
        public ItemBestellingInputModel(int aantal)
        {
            Aantal = aantal;
        }
        public ItemBestellingInputModel()
        {

        }
    }
}