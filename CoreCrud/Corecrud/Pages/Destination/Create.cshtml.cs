using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Corecrud.Models;

namespace Corecrud.Pages.Destination
{
    public class CreateModel : PageModel
    {
        private readonly Corecrud.Models.CorecrudContext _context;

        public CreateModel(Corecrud.Models.CorecrudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["LocationId"] = new SelectList(_context.Country, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Destinations Destinations { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Destinations.Add(Destinations);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}