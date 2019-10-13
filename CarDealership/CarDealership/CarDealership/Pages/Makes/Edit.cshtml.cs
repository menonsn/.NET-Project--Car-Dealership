using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Makes
{
    public class EditModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public EditModel(CarDealership.Models.CarDealershipContext context)
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
           ViewData["MakeTypeID"] = new SelectList(_context.MakeType, "ID", "Make_Type");
           ViewData["ManufacturerID"] = new SelectList(_context.Manufacturer, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Make).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(Make.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MakeExists(int id)
        {
            return _context.Make.Any(e => e.ID == id);
        }
    }
}
