using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.MakeTypes
{
    public class DeleteModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public DeleteModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MakeType MakeType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MakeType = await _context.MakeType.FirstOrDefaultAsync(m => m.ID == id);

            if (MakeType == null)
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

            MakeType = await _context.MakeType.FindAsync(id);

            if (MakeType != null)
            {
                _context.MakeType.Remove(MakeType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
