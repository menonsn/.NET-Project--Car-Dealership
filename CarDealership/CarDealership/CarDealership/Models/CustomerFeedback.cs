using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CustomerFeedback
    {
        [Required]
        [Display(Name = "Branch Rating")]
        [Range(0, 5, ErrorMessage = "Branch Rating should be from 1 to 5")]
        public int Service_Rating { get; set; }
        public int BranchId { get; set; }




        [Required]
        public int? OwnerId { get; set; }
        public Customer Owner { get; set; }

        public string Branch_Name { get; set; }

    }
}
