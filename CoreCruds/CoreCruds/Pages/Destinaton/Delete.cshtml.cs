using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCruds.Models;

namespace CoreCruds.Pages.Destinaton
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCruds.Models.CoreCrudsContext _context;

        public DeleteModel(CoreCruds.Models.CoreCrudsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destinations Destinations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Destinations = await _context.Destinations
                .Include(d => d.Location).FirstOrDefaultAsync(m => m.ID == id);

            if (Destinations == null)
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

            Destinations = await _context.Destinations.FindAsync(id);

            if (Destinations != null)
            {
                _context.Destinations.Remove(Destinations);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
