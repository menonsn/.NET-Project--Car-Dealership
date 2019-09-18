using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCruds.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;



namespace CoreCruds.Pages
{
    public class CountryProfileModel : PageModel

    {

        private CoreCrudsContext _context;

        public CountryProfileModel(CoreCrudsContext context)

        {

            _context = context;

        }

        public Country country { get; set; }
        public IActionResult OnGet(int? id)
        {
            country = _context.Country.Include(x => x.Destinations).FirstOrDefault(x => x.ID == id);

            return Page();
        }

    }

}