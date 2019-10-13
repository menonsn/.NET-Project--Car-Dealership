using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Branches
{
    public class DetailsModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public DetailsModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        public Branch Branch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Branch = await _context.Branch.FirstOrDefaultAsync(m => m.ID == id);

            if (Branch == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
