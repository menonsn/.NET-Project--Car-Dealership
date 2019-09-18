using System;
using System.Collections.Generic;
using System.Linq;
using CoreCruds.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCruds.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrudsContext _context;
        public int destinationsindia;
        public int destinationschina;
        public int destinationsgermany;
        public int destinationsfrance;
        public IndexModel(CoreCrudsContext context)
        {
            _context = context;
        }

        //stats
        public IActionResult OnGet()
        {
            destinationsindia = _context.Destinations.Where(x => x.ID == 1).Count();
            destinationschina = _context.Destinations.Where(x => x.ID == 3).Count();
            destinationsgermany = _context.Destinations.Where(x => x.ID == 6).Count();
            destinationsfrance = _context.Destinations.Where(x => x.ID == 14).Count();
            return Page();
        }


    }
}
