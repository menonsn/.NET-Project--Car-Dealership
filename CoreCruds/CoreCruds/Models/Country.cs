using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCruds.Models
{
    public class Country
    {
        public int ID { get; set; }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please input a Country Name!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 60 characters only")]
        [CustomValidation(typeof(Country), "DuplicateCheck")]
        public string CountryName { get; set; }
        public ICollection<Destinations> Destinations { get; set; }

        public static ValidationResult DuplicateCheck(string name, ValidationContext context)
        {
            var obj = context.ObjectInstance as Country;
            if (obj == null)
            {
                return ValidationResult.Success;
            }
            var dbCon = context.GetService(typeof(CoreCrudsContext)) as CoreCrudsContext;
            int duplicatecheck = dbCon.Country.Count(x => x.ID != obj.ID && x.CountryName == name);
            if (duplicatecheck > 0)
            {
                return new ValidationResult("Country Name already exists!");
            }
            return ValidationResult.Success;

        }
    }
    }
