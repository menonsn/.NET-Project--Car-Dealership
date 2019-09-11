using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCruds.Models;

namespace CoreCruds.Pages.Destinaton
{
    public class CreateModel : PageModel
    {
        private readonly CoreCruds.Models.CoreCrudsContext _context;

        public CreateModel(CoreCruds.Models.CoreCrudsContext context)
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