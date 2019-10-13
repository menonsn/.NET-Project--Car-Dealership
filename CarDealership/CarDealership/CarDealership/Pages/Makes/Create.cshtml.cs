using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarDealership.Models;

namespace CarDealership.Pages.Makes
{
    public class CreateModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public CreateModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MakeTypeID"] = new SelectList(_context.MakeType, "ID", "Make_Type");
        ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Make.Add(Make);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}