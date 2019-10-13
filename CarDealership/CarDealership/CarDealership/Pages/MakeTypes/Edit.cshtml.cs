using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.MakeTypes
{
    public class EditModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public EditModel(CarDealership.Models.CarDealershipContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MakeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeTypeExists(MakeType.ID))
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

        private bool MakeTypeExists(int id)
        {
            return _context.MakeType.Any(e => e.ID == id);
        }
    }
}
