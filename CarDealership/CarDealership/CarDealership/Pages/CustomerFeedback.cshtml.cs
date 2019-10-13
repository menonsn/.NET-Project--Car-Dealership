using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealership.Pages
{
    public class CustomerFeedbackModel : PageModel
    {
        private readonly CarDealershipContext _context;
        public CustomerFeedbackModel(CarDealershipContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomerFeedback FeedbackForm { get; set; }

        public Branch Branch { get; set; }

        public IActionResult OnGet(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Branch = _context.Branch.Find(id);

            if (Branch == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Customer_Name");
            FeedbackForm = new CustomerFeedback();
            FeedbackForm.Branch_Name = Branch.Branch_Name;
            FeedbackForm.BranchId = Branch.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Branch = _context.Branch.Find(FeedbackForm.BranchId);

            if (!ModelState.IsValid)
            {
                ViewData["OwnerId"] = new SelectList(_context.Customer, "ID", "Customer_Name");
                return Page();
            }

            // UPDATE THE AGENT RETRIEVED FROM THE DATABASE
            Branch.Branch_Rating = Branch.Branch_Rating + FeedbackForm.Service_Rating;
            Branch.Review_Count = Branch.Review_Count + 1;
            // TELL THE DATABASE TO SAVE WHATEVER CHANGES WE MADE
            _context.SaveChanges();
            return RedirectToPage("/SearchBranches");

        }
    }
}