using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Input - Customer Name should have a minimum of 2 letters")]
        public string Customer_Name { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact Number is Required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Invalid Input - Phone number hould have 10 digits")]
        [RegularExpression(@"^[0-9]{10}.*")]
        public string Contact_Number { get; set; }

        [Display(Name = "Email ID")]
        [Required(ErrorMessage = "Email ID is Required")]
        [EmailAddress]
        public string Email_ID { get; set; }

        public ICollection<Car> Cars { get; set; }
     

    }
}
