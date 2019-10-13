using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Make
    {
        
        public int ID { get; set; }

        [Display(Name = "Make Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Input - Make Name should have a minimum of 2 letters")]
        [Required(ErrorMessage = "Make Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Make Type")]
        [Required(ErrorMessage = "Make Type is Required")]
        public int MakeTypeID { get; set; }
        public MakeType MakeType { get; set; }

        public int ManufacturerID { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }

    }
}
