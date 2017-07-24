using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using architektura.Validation;

namespace architektura.Models
{
    public class EditStylViewModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int idSTYL { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "name")]
        [StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Display(Name = "age")]
        [Validation.Napis(ErrorMessage = "Please correct the age.")]
        public string age { get; set; }


        [Display(Name = "picture")]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string picture { get; set; }

    }

}
