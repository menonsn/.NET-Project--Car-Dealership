using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public DeleteModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Make
                .Include(m => m.MakeType)
                .Include(m => m.Manufacturer).FirstOrDefaultAsync(m => m.ID == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Make.FindAsync(id);

            if (Make != null)
            {
                _context.Make.Remove(Make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
