using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Make")]
        [Required(ErrorMessage = "Make is Required")]

        public int MakeID { get; set; }
        public Make Make { get; set; }

       public static ValidationResult IsVINexisting (string VIN, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(VIN))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Car;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            var dbContext = context.GetService(typeof(CarDealershipContext)) as CarDealershipContext;

            var check = dbContext.Car.FirstOrDefault(x => x.VIN == instance.VIN);

            if (check == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The VIN already exists in the database");
        } // Advanced Custom Validation Rule 

        [Display(Name = "VIN")]
        [Required(ErrorMessage = "VIN is Required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Invalid Input - VIN should be 8 Characters in length")]
        [RegularExpression(@"^[0-9]{3}.*")]
        [CustomValidation(typeof(Car), "IsVINexisting")]
        public string VIN { get; set; }

      public static ValidationResult IsManufacturedYearinPast (int Year, ValidationContext context)
        {
           
            if (Year <= DateTime.Today.Year)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Manufactured Year cannot be in the future");
        } // Basic Custom Validation Rule 

        [Display(Name = "Manufactured Year")]
        [Required(ErrorMessage = "Manufactured Year is Required")]
        [Range(2000, 9999, ErrorMessage = "Manufactured Year should be from 2000 to 9999")]
      [CustomValidation(typeof(Car), "IsManufacturedYearinPast")]

        public int Manufactured_Year { get; set; }

        [Display(Name = "Ex-Showroom Price (in Dollars)")]
        [Required(ErrorMessage = "Price is Required")]
        public int Showroom_Price { get; set; }

        //[NotMapped]
        [Display(Name = "Onroad Price")]
        public decimal Onroad_price { get { return decimal.Multiply(Showroom_Price, 1.5m); } }


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

        [Display(Name = " Sale Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Car), "IsSaleDatenullornotinPast")]
        public DateTime? Sale_Date { get; set; }

        //[NotMapped]
       [Display(Name = "Available?")]
       public bool IsAvailable { get { return (!Sale_Date.HasValue); } }

       public int? OwnerId { get ; set; }
        public Customer Owner { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        
    }
}
