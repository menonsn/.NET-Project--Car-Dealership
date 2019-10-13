using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Pages
{
    public class CarsinBranchModel : PageModel
    {

        private CarDealershipContext _context;

        public CarsinBranchModel (CarDealershipContext context)
        {
            _context = context;
        }

        public Branch Branch { get; set; }
        
        public IActionResult OnGet(int? ID)
        {

            if (ID == null || ID == 0)
            {
                return NotFound();
            }

            else
            {
                Branch = _context.Branch
                                        .Include(x => x.Cars)
                                        .ThenInclude(y => y.Make)
                                        .ThenInclude(z => z.Manufacturer)
                                        .FirstOrDefault(x => x.ID == ID);

                if (Branch.IsOperational)
                {
                    return Page();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}