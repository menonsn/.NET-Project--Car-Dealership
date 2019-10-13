using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealership.Models;

namespace CarDealership.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarDealership.Models.CarDealershipContext _context;

        public EditModel(CarDealership.Models.CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                .Include(c => c.Branch)
                .Include(c => c.Make)
                .Include(c => c.Owner).FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
           ViewData["BranchId"] = new SelectList(_context.Branch, "ID", "Branch_Name");
           ViewData["MakeID"] = new SelectList(_context.Make, "ID", "Name");
           ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Contact_Number");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["BranchId"] = new SelectList(_context.Branch, "ID", "Branch_Name");
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
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

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
