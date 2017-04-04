using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IHFF.Enum;


namespace IHFF.Models.Input
{
    public class CartInfoInputModel
    {
        [Required]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        public Payment PaymentMethod { get; set; }

        [Required]
        public PickUp PickupMethod { get; set; }

        public CartInfoInputModel()
        {

        }
    }
}