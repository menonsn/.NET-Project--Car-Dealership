using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealership.Pages
{
    public class PurchaseCarModel : PageModel
    {

        private readonly CarDealershipContext _context;
        public PurchaseCarModel(CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarPurchaseForm CarPurchaseForm { get; set; }

        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = _context.Car.Find(id);

            if (Car == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Customer_Name");
            CarPurchaseForm = new CarPurchaseForm();
            CarPurchaseForm.VIN = Car.VIN;
            CarPurchaseForm.CarId = Car.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Car = _context.Car.Find(CarPurchaseForm.CarId);

            if (!ModelState.IsValid)
            {
                ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Customer_Name");
                return Page();
            }

            // UPDATE THE AGENT RETRIEVED FROM THE DATABASE
            Car.Sale_Date = CarPurchaseForm.Sale_Date;
            Car.OwnerId = CarPurchaseForm.OwnerId;
            // TELL THE DATABASE TO SAVE WHATEVER CHANGES WE MADE
            _context.SaveChanges();
            return RedirectToPage("/PurchaseCar", new { id = CarPurchaseForm.CarId });
        }
    }
}