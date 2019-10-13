using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Display(Name = "Manufacturer Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Input - Manufacturer Name should have a minimum of 2 letters")]
        [Required(ErrorMessage = "Manufacturer Name is Required")]
        public string Name { get; set; }

        public ICollection<Make> Makes { get; set; }
    }
}
