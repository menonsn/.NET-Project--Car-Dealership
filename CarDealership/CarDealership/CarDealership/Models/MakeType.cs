using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class MakeType
    {
        public int ID { get; set; }

        [Display(Name = "Make Type")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Input - Make Type should have a minimum of 3 letters")]
        [Required(ErrorMessage = "Make Type is Required")]
        public string Make_Type { get; set; }

        public ICollection<Make> Makes { get; set; }
    }
}
