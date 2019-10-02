using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCruds.Models
{
    public class Destinations
    {
        public int ID { get; set; }

        [Display(Name = "Destination Name")]
        [Required(ErrorMessage = "Please input a Destination Name!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 60 characters only")]
        public string DestinationName { get; set; }

        [Required]
        [Display(Name = "Altitude of the Destination")]
        public decimal Altitude { get; set; }

        [Required]
        [Display(Name = "Estimated Cost of Trip")]
        [Range(10, 99999, ErrorMessage = "Estimated cost cannot be this high!")]
        public double? CostOfTrip { get; set; }
        [Display(Name = "Main Attraction")]
        public string MainAttraction { get; set; }
        [Required]
        [Display(Name = "Equatorial Weather?")]
        [CustomValidation(typeof(Destinations), "CheckEquatorial")]
        public bool EquatorialWeather { get; set; }
        [Required]
        [Display(Name = "Expected Date of Travel")]
        [CustomValidation(typeof(Destinations), "DateOfTravel")]
        public DateTime DateOfVisit { get; set; }


        public int LocationId { get; set; }
        public Country Location { get; set; }

        public static ValidationResult CheckEquatorial(decimal Altitude, ValidationContext context)

        {
            if (Altitude < 500)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Destinations with Altitude>500 can't have equatorial weather");
            }
        }

        public static ValidationResult DateOfTravel(DateTime DateOfVisit, ValidationContext context)

        {
            var obj = context.ObjectInstance as Destinations;
            if (obj.DestinationName != null && DateOfVisit < DateTime.Today)
            {
                return new ValidationResult("Please enter a valid Date of Travel.You have entered a past date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        [NotMapped]
        public bool ischeap { get { if (CostOfTrip < 1222) { return true; } return false; } }
    }
}
