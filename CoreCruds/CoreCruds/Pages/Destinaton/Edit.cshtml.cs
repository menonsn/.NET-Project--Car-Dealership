﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreCruds.Models;

namespace CoreCruds.Pages.Destinaton
{
    public class EditModel : PageModel
    {
        private readonly CoreCruds.Models.CoreCrudsContext _context;

        public EditModel(CoreCruds.Models.CoreCrudsContext context)
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
           ViewData["LocationId"] = new SelectList(_context.Country, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Destinations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinationsExists(Destinations.ID))
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

        private bool DestinationsExists(int id)
        {
            return _context.Destinations.Any(e => e.ID == id);
        }
    }
}
