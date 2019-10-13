using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Branch
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "City is Required")]
        [Display(Name = "City")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Input - City should have a minimum of 2 letters")]
        public string Branch_City { get; set; }      

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is Required")]
        [Range(00001, 999999, ErrorMessage = "Zip Code should be from 00001 to 999999")]
        public int Zip_Code { get; set; }

        //[Not Mapped]
        [Display(Name="Branch Name")]
        public string Branch_Name { get { return (Branch_City + " " + "-" + " " + Zip_Code.ToString()); } }

        [Display(Name = "Operational?")]
        [Required(ErrorMessage = "is Required")]
        public bool IsOperational { get; set; }

        [Display(Name = "Branch Rating")]
        [Range(0, 5, ErrorMessage = "Branch Rating should be from 1 to 5")]
        public int Branch_Rating { get; set; }

        [Display(Name = "Number of Reviews")]
        public int Review_Count { get; set; }

        //[NotMapped]
        [Display(Name = "Average Branch Rating")]
        public decimal Average_Rating
        { get { if (Review_Count == 0) return (0); else return (Branch_Rating / Review_Count); } }
        
        //[NotMapped]
        [Display(Name = "Trusted?")]
        public bool Trusted 
        {
            get { return (Average_Rating >= 3); }
        }

      
        public ICollection<Car> Cars { get; set; }

     
    }
}
