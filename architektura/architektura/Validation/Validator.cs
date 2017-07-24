using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace architektura.Validation
{
    public class Napis : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string napis = (String)value;

            bool flaga = true;
            foreach (var znak in napis) if (znak != 'X' && znak != 'I' && znak != 'x' && znak != 'i') flaga = false;
            if (flaga == true) return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
