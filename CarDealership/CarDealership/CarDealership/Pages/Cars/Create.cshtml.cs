using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarDealership.Models;

namespace CarDealership.Pages.Cars
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
        ViewData["BranchId"] = new SelectList(_context.Branch, "ID", "Branch_Name");
        ViewData["MakeID"] = new SelectList(_context.Make, "ID", "Name");
        ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Contact_Number");
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["BranchId"] = new SelectList(_context.Branch, "ID", "Branch_Name");
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}