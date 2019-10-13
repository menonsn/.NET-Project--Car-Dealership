using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarPurchaseForm
    {

        
        public CarPurchaseForm ()
        {
            Sale_Date = DateTime.Today;
        }
        public string VIN { get; set; }
        public int CarId { get; set; }

        [Required]
        public int? OwnerId { get; set; }
        public Customer Owner { get; set; }

        public static ValidationResult IsSaleDatenullornotinPast(DateTime? SaleDate, ValidationContext context)
        {
            if (!SaleDate.HasValue)
            {
                return ValidationResult.Success;
            }
            else if (SaleDate >= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Sale Date cannot be in the past");
        } // Basic Custom Validation Rule 
        
        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Car), "IsSaleDatenullornotinPast")]
        public DateTime? Sale_Date { get; set; }
        
    }
}
